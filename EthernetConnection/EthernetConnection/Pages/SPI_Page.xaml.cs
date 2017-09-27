using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using EthernetConnection.GlobalChannel;
using EthernetConnection.SPI_Command;
using System.Threading;
using System.ComponentModel;
using System.Globalization;
using System.Net;
using System.Net.Sockets;
using System.IO.Ports;


namespace EthernetConnection.Pages
{
    /// <summary>
    /// SPI_Page.xaml 的互動邏輯
    /// </summary>
    public partial class SPI_Page : Page
    {
        #region RS232
        private SerialPort port;
        #endregion

        enum BitCmd
        {
            StartByte = 0x1B,
            StopByte = 0x0D,
        }

        enum Cmd
        {
            GetStatus = 1,
            GetDigitalIO = 2,
            Get_Analog_Input = 3,
            Set_Access_Level = 9,
            Maintenance = 14,
            Red_Targeting_Laser_Control = 16,
        }
                 
        public string str_1, str_2, str_3, str_4, str_5, str_6, str_7, str_8;
        int command_case, NoOfCommand, ByteAmount_Read, ByteAmount = 5;
        byte[] Read_Status;
        string input, sp;
        byte data_byte_1 = 0x00;     
        bool J = false;
        int pulsewidth;
        byte[] command_data;

        TcpClient tcpClient = ET_GlobalChannel.Et_vm.Tcpclient;
        NetworkStream netStream;
        Command_cal command_cal = ET_GlobalChannel.command_cal;
        BackgroundWorker worker;
        Worker W1;
        public static UdpClient uc = null;
        public static IPEndPoint otherIP = null;
        TcpClient client;
        TcpListener server;

        public SPI_Page()
        {
            InitializeComponent();

            this.DataContext = this;

            List<string> itemNames = GetItemsName();//準備資料
            Command_Combox.ItemsSource = itemNames;  //
            Read_Status = new byte[8];              
        }

        private List<string> GetItemsName()
        {
            List<string> list = new List<string>();
            list.Add("Get Status"); //1
            list.Add("Get_Digital_I/O");  //2
            list.Add("Get_Analog_Input"); //3
            //list.Add("Get Alarms & Warnings");
            //list.Add("Reset Alarms");
            //list.Add("Calibrate");
            //list.Add("Set Current Mode");
            list.Add("Set_Access_Level");  //9
            list.Add("Set_Required_Power_Level"); //10
            list.Add("Get_Output_Power_Level");  //11
            //list.Add("Get Model & Version");
            list.Add("Maintenance");  //14
            //list.Add("Internal Pulse Generation");
            list.Add("Red_Targeting_Laser_Control"); //16
            //list.Add("Read Log");
            //list.Add("Get On Times");
            //list.Add("Get Output Power and Pulse width");
            //list.Add("Get Settings");
            //list.Add("Set Settings");
            //list.Add("Clear Output Power Alarm");
            //list.Add("Set Pump Driver PSE Level");
            //list.Add("Set XPR Mode");
            //list.Add("Enable Feature");
            //list.Add("Get string description");
            //list.Add("User Clear All Alarms");
            //list.Add("Get Humidity Information");
            return list;
        }

        #region RS232 event
        private void RS232_Write_btn_Click(object sender, RoutedEventArgs e)
        {
            byte[] TransmitCommand = new byte[6];

            TransmitCommand[0] = byte.Parse(TByte1.Text, NumberStyles.HexNumber);
            TransmitCommand[1] = byte.Parse(TByte2.Text, NumberStyles.HexNumber);
            TransmitCommand[2] = byte.Parse(TByte3.Text, NumberStyles.HexNumber);
            TransmitCommand[3] = byte.Parse(TByte4.Text, NumberStyles.HexNumber);
            TransmitCommand[4] = byte.Parse(TByte5.Text, NumberStyles.HexNumber);
            TransmitCommand[5] = byte.Parse(TByte6.Text, NumberStyles.HexNumber);

            port.Write(TransmitCommand, 0, TransmitCommand.Length);
        }



        private void Close_port_Click(object sender, RoutedEventArgs e)
        {
            if (Command_Combox.Text == "Get Status")
            {
                MessageBox.Show("Get Status");
            }

            //port.Close();
        }
        #endregion

        #region Connect event       

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // 自訂要監聽的 Port
            IPEndPoint myIP = new IPEndPoint(IPAddress.Any, 27015);

            UdpClient udpclient = new UdpClient(myIP.Port);

            // 廣播的 IP 與 Port
            IPEndPoint remoteIP = new IPEndPoint(IPAddress.Parse("255.255.255.255"), 58175);

            byte[] pushdata = new byte[23]; //定義要送出的封包大小            

            while (true)
            {
                #region 發送訊號
                //依電鯊訊號分析得出的結果如下
                pushdata[0] = 0x1b;
                pushdata[15] = 0x6e;
                pushdata[16] = 0x09;
                pushdata[17] = 0xa4;
                pushdata[18] = 0xa9;
                pushdata[22] = 0xdf;

                udpclient.Send(pushdata, pushdata.Length, remoteIP);
                #endregion

                #region 接收訊號
                ////應先進行監聽動作
                //Console.WriteLine("這是伺服器...\n");

                //IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 58175);
                //UdpClient uc = new UdpClient(ipep.Port);

                //int i = 0;
                //while (true)
                //{
                //    Console.WriteLine(System.Text.Encoding.UTF8.GetString(uc.Receive(ref ipep)));
                //    byte[] b = System.Text.Encoding.UTF8.GetBytes("這是'伺服器'回傳的訊息 ~ " + i++);
                //    uc.Send(b, b.Length, ipep);
                //}

                try
                {
                    //Blocks until a message returns on this socket from a remote host.
                    byte[] receiveBytes = udpclient.Receive(ref remoteIP);

                    string[] returnData = new string[receiveBytes.Length];

                    for (int n = 0; n < receiveBytes.Length; n++)
                    {
                        returnData[n] = receiveBytes[n].ToString("X");
                    }

                    Console.WriteLine("This is the message you received " +
                                                 returnData[26] + returnData[27] + returnData[28] + returnData[29]);

                    //Console.WriteLine("This is the message you received " +
                    //                             returnData[26] + returnData[27] + returnData[28] + returnData[29]);

                }
                catch (Exception s)
                {
                    MessageBox.Show("Receive Failed");
                }
                #endregion

                Thread.Sleep(1000); //每秒發送一次
            }

            //IPEndPoint remoteIP = new IPEndPoint(IPAddress.Parse("255.255.255.255"), 58175); //可自行定義廣播區域跟Port
            //Socket Server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp); //定義發送的格式及有效區域
            //Server.EnableBroadcast = true;
            //Server.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, true);

            //byte[] pushdata = new byte[1024]; //定義要送出的封包大小

            //while (true)
            //{
            //    pushdata = Encoding.UTF8.GetBytes(""); //把要送出的資料轉成byte型態
            //    Server.SendTo(pushdata, remoteIP); //送出的資料跟目的
            //    Thread.Sleep(1000); //每秒發送一次
            //}
        }

        private void ListenForPing(UdpClient udpclient)
        {
            while (true)
            {
                var deserializer = new ASCIIEncoding();
                IPEndPoint anyIP = new IPEndPoint(IPAddress.Any, 0);
                byte[] recData = udpclient.Receive(ref anyIP);
                string ping = deserializer.GetString(recData);
                if (ping == "ping")
                {
                    Console.WriteLine("Ping received.");
                    //InvokePingReceiveEvent();
                }
            }
        }

        

        #endregion

        #region Command

        private void Go_btn_Click(object sender, RoutedEventArgs e)
        {        
            if (tcpClient.Connected)  //Is tcpClient Connected or not
            {
                netStream = tcpClient.GetStream();
                try
                {
                    if (netStream.CanWrite)
                    {                        
                        command_data = command_cal.Command(ByteAmount, command_case, data_byte_1);
                        //寫入資料流
                        netStream.Write(command_data, 0, command_data.Length);                        
                    }

                    //讀取回傳資料
                    if (netStream.CanRead)
                    {
                        byte[] bytes = new byte[ByteAmount_Read];

                        netStream.Read(bytes, 0, ByteAmount_Read);

                        //Show return data on HMI
                        ReturnData_HMI(ByteAmount, command_data, ByteAmount_Read, bytes);
                    }                    

                    
                }

                catch (Exception a)
                {
                    Console.WriteLine("You cannot transmit data to laser." + a);
                    netStream.Close();
                    return;
                }
            }

            else
            {
                MessageBox.Show("Unconnected");
            }
        }
                
        private void Pilot_Laser_Click(object sender, RoutedEventArgs e)
        {            
            ByteAmount = 6;
            ByteAmount_Read = 6;

            if (J == false)
            {
                command_case = 16;
                ByteAmount = 6;
                ByteAmount_Read = 6;
                data_byte_1 = 0x01;
                J = true;                
            }
            else
            {
                command_case = 16;
                ByteAmount = 6;
                ByteAmount_Read = 6;
                data_byte_1 = 0x00;
                J = false;                
            }                       

            if (tcpClient.Connected == true)
            {
                netStream = tcpClient.GetStream();
                try
                {
                    if (netStream.CanWrite)
                    {
                        byte[] command_data = command_cal.Command(ByteAmount, command_case, data_byte_1);

                        //寫入資料流
                        netStream.Write(command_data, 0, command_data.Length);

                        //讀取回傳資料
                        if (netStream.CanRead)
                        {
                            string[] returndata = new string[ByteAmount_Read];
                            
                            byte[] bytes = new byte[ByteAmount_Read];

                            netStream.Read(bytes, 0, ByteAmount_Read);                                                        

                            ReturnData_HMI(ByteAmount, command_data, ByteAmount_Read, bytes);                            
                        }
                        else
                        {
                            Console.WriteLine("You cannot read data from this stream.");
                            return;
                        }
                    }
                }

                catch (Exception a)
                {
                    Console.WriteLine("You cannot transmit data to laser.");
                    MessageBox.Show("TcpClient Error");
                    tcpClient.Close();
                    return;
                }
            }

            else
            {
                MessageBox.Show("Unconnected");
            }            
        }

        private void Emit_btn_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            //ET_GlobalChannel.Et_vm.IR_status = true; //因UI執行緒在Click事件中時會暫停，因此將UI動作與Click提前分離
            //ET_GlobalChannel.Et_vm.Worker.CancelAsync();
        }

        private void Emit_btn_Click(object sender, RoutedEventArgs e)
        {            
            //Turn on Laser
            if (tcpClient.Connected)  //Is tcpClient Connected or not
            {
                netStream = tcpClient.GetStream();
                try
                {
                    if (netStream.CanWrite)
                    {
                        command_data = command_cal.Command(ByteAmount, command_case, data_byte_1);
                        netStream.Write(command_data, 0, command_data.Length);
                    }

                    if (netStream.CanRead)
                    {            
                        byte[] bytes = new byte[ByteAmount_Read];

                        netStream.Read(bytes, 0, ByteAmount_Read);

                        //Show return data on HMI
                        ReturnData_HMI(ByteAmount, command_data, ByteAmount_Read, bytes);
                    }                    
                }

                catch (Exception a)
                {
                    Console.WriteLine("You cannot transmit data to laser." + a);
                    //netStream.Close();
                    return;
                }
            }
            else
            {
                MessageBox.Show("Unconnected");
            }

            //Pulse width                        
            pulsewidth = (int)(float.Parse(ET_GlobalChannel.Et_vm.Pulse_width) * 1000);
            Thread.Sleep(pulsewidth);

            //Turn off Laser
            if (tcpClient.Connected)  //Is tcpClient Connected or not
            {
                for (int i=0;i<15;i++)
                {
                    try
                    {
                        if (netStream.CanWrite)
                        {
                            sp = ET_GlobalChannel.Et_vm.Set_power;
                            ET_GlobalChannel.Et_vm.Set_power = "0"; //設定功率為0

                            command_data = ET_GlobalChannel.command_cal.Command(ByteAmount, command_case, data_byte_1);
                            //寫入資料流
                            netStream.Write(command_data, 0, command_data.Length);
                        }

                        if (netStream.CanRead)
                        {
                            byte[] bytes = new byte[ByteAmount_Read];
                            netStream.Read(bytes, 0, ByteAmount_Read);

                            //Show return data on HMI
                            ReturnData_HMI(ByteAmount, command_data, ByteAmount_Read, bytes);

                            ET_GlobalChannel.Et_vm.Set_power = sp; //回復功率設定  
                            ET_GlobalChannel.Et_vm.IR_status = false; //回復IR狀態顯示      
                        }
                    }

                    catch (Exception a)
                    {
                        Console.WriteLine("You cannot transmit data to laser." + a);
                        //netStream.Close();
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show("Unconnected");
            }                        
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {           
            ET_GlobalChannel.Et_vm.Worker.RunWorkerAsync();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ET_GlobalChannel.Et_vm.Worker.CancelAsync();            
        }

        private void Clear_power_Click(object sender, RoutedEventArgs e)
        {
            ET_GlobalChannel.Et_vm.Set_power = "0"; //設定功率為0

            //Turn off Laser
            if (tcpClient.Connected)
            {
                try
                {
                    netStream = tcpClient.GetStream();
                    if (netStream.CanWrite)
                    {
                        byte[] command_data = command_cal.Command(ByteAmount, command_case, data_byte_1);
                        //寫入資料流
                        netStream.Write(command_data, 0, command_data.Length);

                        //讀取回傳資料
                        if (netStream.CanRead)
                        {
                            byte[] bytes = new byte[ByteAmount_Read];

                            netStream.Read(bytes, 0, ByteAmount_Read);

                            //Show return data on HMI
                            ReturnData_HMI(ByteAmount, command_data, ByteAmount_Read, bytes);
                        }
                        else
                        {
                            Console.WriteLine("You cannot read data from this stream.");
                            return;
                        }
                    }
                }

                catch (Exception a)
                {
                    Console.WriteLine("You cannot transmit data to laser.");
                    tcpClient.Close();
                    return;
                }
            }
            else
            {
                MessageBox.Show("Unconnected");
            }

        }

        private void Disconnect_Click(object sender, RoutedEventArgs e)
        {
            if (tcpClient.Connected == true)
            {
                netStream.Close();
                //tcpClient.Client.Disconnect(true);
                tcpClient.Client.Dispose();
                tcpClient.Close();
            }

        }

        private void Drain_Click(object sender, RoutedEventArgs e)
        {
            #region Backgroundworker
            //Worker W1 = new Worker(tcpClient, tcpClient.GetStream(), data_byte_1);

            //worker = W1.m_worker;

            //worker.RunWorkerAsync();
            #endregion                     

            if (tcpClient.Connected)
            {
                netStream = tcpClient.GetStream();
                try
                {
                    if (netStream.CanWrite)
                    {
                        byte[] command_data;

                        #region 開啟權限
                        command_case = 9;
                        ByteAmount = 9;
                        ByteAmount_Read = 7;      
                        command_data = command_cal.Command(ByteAmount, command_case, data_byte_1);
                        netStream.Write(command_data, 0, command_data.Length);                        
                        #endregion

                        #region 打開水閥
                        command_case = 14;
                        ByteAmount = 7;                        
                        ByteAmount_Read = 8;
                        command_data = ET_GlobalChannel.command_cal.Command(ByteAmount, command_case, data_byte_1);
                        netStream.Write(command_data, 0, command_data.Length);                        
                        #endregion
                    }
                }
                catch (Exception a)
                {
                    Console.WriteLine("You cannot transmit data to laser.");
                    MessageBox.Show("TcpClient Error");
                    tcpClient.Close();
                    return;
                }
            }

            else
            {
                MessageBox.Show("Unconnected");
            }
        }                

        private byte[] Command(int ByteAmount, int command_case)
        {
            byte[] TransmitCommand = new byte[ByteAmount];

            //填入指令
            for (int N = 0; N < ByteAmount; N++)
            {
                if (N == 0) //StartByte
                {
                    TransmitCommand[N] = (byte)BitCmd.StartByte;
                }
                else if (N == 1)
                {
                    NoOfCommand = ByteAmount - 4; //No of command
                    TransmitCommand[N] = (byte)NoOfCommand;
                }
                else if (N == 2)
                {
                    TransmitCommand[N] = byte.Parse(command_case.ToString("X"), NumberStyles.HexNumber);
                }

                else if (N == ByteAmount - 2) //StopByte
                {
                    TransmitCommand[N] = (byte)BitCmd.StopByte;
                }
                else if (N == ByteAmount - 1)
                {
                    for (int count = 0; count < ByteAmount - 1; count++)
                    {
                        int crcvalue = (TransmitCommand[N] + TransmitCommand[count]);

                        TransmitCommand[N] = (byte)crcvalue;
                    }
                }

                else
                {
                    switch (command_case)
                    {
                        //case = command no.
                        case (int)Cmd.GetStatus:
                            for (N = 3; N < ByteAmount - 2; N++)
                            {

                            }
                            break;

                        case (int)Cmd.GetDigitalIO:
                            for (N = 3; N < ByteAmount - 2; N++)
                            {

                            }
                            break;

                        case (int)Cmd.Get_Analog_Input:
                            for (N = 3; N < ByteAmount - 2; N++)
                            {
                                TransmitCommand[N] = 0x05; //Ambient Temperature
                            }
                            break;

                        case (int)Cmd.Set_Access_Level:
                            for (N = 3; N < ByteAmount - 2; N++)
                            {
                                if (N == 3)  //Password: K7K6
                                {
                                    TransmitCommand[N] = 75;
                                }
                                else if (N == 4)  //Password: K7K6
                                {
                                    TransmitCommand[N] = 55;
                                }
                                else if (N == 5)  //Password: K7K6
                                {
                                    TransmitCommand[N] = 75;
                                }
                                else if (N == 6)  //Password: K7K6
                                {
                                    TransmitCommand[N] = 54;
                                }
                            }
                            break;

                        case (int)Cmd.Maintenance:
                            for (N = 3; N < ByteAmount - 2; N++)
                            {

                            }
                            break;

                        case (int)Cmd.Red_Targeting_Laser_Control:
                            for (N = 3; N < ByteAmount - 2; N++)
                            {
                                TransmitCommand[N] = 0x01;
                            }
                            break;
                    }
                    N = N - 1;
                }
            }

            return TransmitCommand;
        }
        #endregion

        #region Combox
        private void Command_Combox_KeyUp(object sender, KeyEventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            CollectionView itemsViewOriginal = (CollectionView)CollectionViewSource.GetDefaultView(cmb.ItemsSource);

            itemsViewOriginal.Filter = ((o) =>
            {
                if (string.IsNullOrEmpty(cmb.Text)) return false;
                else
                {
                    if (((string)o).StartsWith(cmb.Text)) return true;
                    else return false;
                }
            });

            cmb.IsDropDownOpen = true;
            itemsViewOriginal.Refresh();
        }

        private void Command_Combox_DropDownClosed(object sender, EventArgs e)
        {
            if (Command_Combox.Text != null)
            {
                switch (Command_Combox.Text)
                {
                    case "Get Status":
                        command_case = 1;
                        ByteAmount = 5;
                        ByteAmount_Read = 7;
                        break;

                    case "Get_Digital_I/O":
                        command_case = 2;
                        ByteAmount = 5;
                        ByteAmount_Read = 13;
                        break;

                    case "Get_Analog_Input":
                        command_case = 3;
                        ByteAmount = 6;
                        ByteAmount_Read = 9;
                        break;

                    case "Set_Access_Level":
                        command_case = 9;
                        ByteAmount = 7;
                        break;

                    case "Set_Required_Power_Level":
                        command_case = 10;
                        ByteAmount = 7;
                        ByteAmount_Read = 6;
                        break;

                    case "Get_Output_Power_Level":
                        command_case = 11;
                        ByteAmount = 5;
                        ByteAmount_Read = 8;
                        break;

                    case "Maintenance":
                        command_case = 14;
                        ByteAmount = 7;
                        break;

                    case "Red_Targeting_Laser_Control":
                        command_case = 16;
                        ByteAmount = 6;
                        ByteAmount_Read = 6;
                        data_byte_1 = 0x01;
                        break;

                }
            }
        }
        #endregion

        private void ReturnData_HMI(int ByteAmount, byte[] command_data, int ByteAmount_Read, byte[] bytes)
        {
            string[] tstr_array = new string[ByteAmount];
            for (int n = 0; n < ByteAmount; n++)
            {
                tstr_array[n] = command_data[n].ToString("X");
            }

            string[] str_array = new string[ByteAmount_Read];
            for (int n = 0; n < ByteAmount_Read; n++)
            {
                str_array[n] = bytes[n].ToString("X");
            }

            ET_GlobalChannel.Et_vm.TStr = tstr_array;
            ET_GlobalChannel.Et_vm.Str = str_array;
        }

        private void Connect_RS232_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private static void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string indata = sp.ReadExisting();
            Console.WriteLine("Data Received:");
            Console.Write(indata);
        }

        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //讀入字串
            int data = 0;
            if (data == 0)
            {
                //data = port.ReadExisting();
                //Console.WriteLine("Receive: " + data);
                string[] returndata = new string[7];
                byte[] bytes = new byte[7];
                port.Read(bytes, 0, 7);


                // Returns the data received from the host to the console.                
                for (int i = 0; i != bytes.Length; i++)
                {
                    returndata[i] = bytes[i].ToString();
                    Console.WriteLine(returndata[i]);
                    //RByte1.Text = returndata[i];
                }

                //    //Show return data, timer's thread is not available to xaml conttrol items here!
                //RByte1.Text = returndata[0];
                //RByte2.Text = returndata[1];
                //RByte3.Text = returndata[2];
                //RByte4.Text = returndata[3];
                //RByte5.Text = returndata[4];
                //RByte6.Text = returndata[5];
                //RByte7.Text = returndata[6];
                //RByte8.Text = returndata[7];
                //RByte9.Text = returndata[8];

                Console.WriteLine("This is what the Laser returned to you: " + returndata);

                System.Threading.Thread.Sleep(1000);
            }


            /*
             //讀入位元組
            int bytes = port.BytesToRead;
            byte[] comBuffer = new byte[bytes];
            port.Read(comBuffer, 0, bytes);
            Console.WriteLine(comBuffer);
            */
        }

        private void RS232_Console_btn_Click(object sender, RoutedEventArgs e)
        {
            byte[] TransmitCommand = new byte[ByteAmount];
            //command_case=1;
            switch (command_case)
            {
                //case = command no.
                case (int)Cmd.GetStatus:

                    TransmitCommand = new byte[ByteAmount];

                    for (int n = 0; n < ByteAmount; n++)
                    {
                        if (n == 0)
                        {
                            TransmitCommand[n] = (byte)BitCmd.StartByte;
                        }
                        else if (n == 1)
                        {
                            NoOfCommand = ByteAmount - 4; //No of command
                            TransmitCommand[n] = (byte)NoOfCommand;
                        }
                        else if (n == 2)
                        {
                            TransmitCommand[n] = byte.Parse(command_case.ToString("X"), NumberStyles.HexNumber);
                        }
                        else if (n <= NoOfCommand + 1 & n != 2)
                        {

                        }
                        else if (n == ByteAmount - 2)
                        {
                            TransmitCommand[n] = (byte)BitCmd.StopByte;
                        }
                        else if (n == ByteAmount - 1)
                        {
                            for (int c = 0; c < ByteAmount - 1; c++)
                            {
                                int crcvalue = (TransmitCommand[n] + TransmitCommand[c]);

                                TransmitCommand[n] = (byte)crcvalue;
                            }
                        }
                    }

                    TByte1.Text = TransmitCommand[0].ToString("X");
                    TByte2.Text = TransmitCommand[1].ToString("X");
                    TByte3.Text = TransmitCommand[2].ToString("X");
                    TByte4.Text = TransmitCommand[3].ToString("X");
                    TByte5.Text = TransmitCommand[4].ToString("X");
                    //TByte1.Text = TransmitCommand[0].ToString();
                    //MessageBox.Show("case1");
                    break;

                case (int)Cmd.Red_Targeting_Laser_Control:

                    TransmitCommand = new byte[ByteAmount];

                    for (int n = 0; n < ByteAmount; n++)
                    {
                        if (n == 0)
                        {
                            TransmitCommand[n] = (byte)BitCmd.StartByte;
                        }
                        else if (n == 1)
                        {
                            NoOfCommand = ByteAmount - 4; //No of command
                            TransmitCommand[n] = (byte)NoOfCommand;
                        }
                        else if (n == 2)
                        {
                            TransmitCommand[n] = 16;
                            //TransmitCommand[n] = byte.Parse(command_case.ToString("X"), NumberStyles.HexNumber);
                        }
                        else if (n == 3)
                        {
                            TransmitCommand[n] = 0x01;
                        }
                        else if (n <= NoOfCommand + 1 & n != 2)
                        {

                        }
                        else if (n == ByteAmount - 2)
                        {
                            TransmitCommand[n] = (byte)BitCmd.StopByte;
                        }
                        else if (n == ByteAmount - 1)
                        {
                            for (int c = 0; c < ByteAmount - 1; c++)
                            {
                                int crcvalue = (TransmitCommand[n] + TransmitCommand[c]);

                                TransmitCommand[n] = (byte)crcvalue;
                            }
                        }
                    }

                    TByte1.Text = TransmitCommand[0].ToString("X");
                    TByte2.Text = TransmitCommand[1].ToString("X");
                    TByte3.Text = TransmitCommand[2].ToString("X");
                    TByte4.Text = TransmitCommand[3].ToString("X");
                    TByte5.Text = TransmitCommand[4].ToString("X");
                    TByte6.Text = TransmitCommand[5].ToString("X");

                    break;
            }


            port.Write(TransmitCommand, 0, TransmitCommand.Length);//寫入資料流

            //netStream.Write(TransmitCommand, 0, TransmitCommand.Length); 

            System.Threading.Thread.Sleep(1000);

            //Read streams from Laser
            if (true)
            {
                string[] returndata = new string[7];
                // Reads NetworkStream into a byte buffer.                
                byte[] bytes = new byte[7];

                // Read can return anything from 0 to numBytesToRead. 
                port.Read(bytes, 0, bytes.Length);
                //string ss = port.ReadExisting();

                // Returns the data received from the host to the console.                
                for (int i = 0; i != bytes.Length; i++)
                {
                    returndata[i] = bytes[i].ToString("X");
                }

                //Show return data
                RByte1.Text = returndata[0];
                RByte2.Text = returndata[1];
                RByte3.Text = returndata[2];
                RByte4.Text = returndata[3];
                RByte5.Text = returndata[4];
                RByte6.Text = returndata[5];
                //RByte7.Text = returndata[6];
                //RByte8.Text = returndata[7];
                //RByte9.Text = returndata[8];

                Console.WriteLine("This is what the Laser returned to you: " + returndata);

            }
            else
            {
                //Console.WriteLine("You cannot read data from this SerialPort.");

                return;
            }
        }
    }
}
