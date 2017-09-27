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
using System.Net.Sockets;
using System.IO.Ports;
using System.IO;
using System.Globalization;
using System.Net;
using System.Threading;
using EthernetConnection.Pages;

namespace EthernetConnection
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {        
        public MainWindow()
        {
            InitializeComponent();          
        }

        private void RS232_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                //SerialPort mySerialPort = new SerialPort("COM2");

                //mySerialPort.BaudRate = 9600;
                //mySerialPort.Parity = Parity.None;
                //mySerialPort.StopBits = StopBits.One;
                //mySerialPort.DataBits = 8;
                //mySerialPort.Handshake = Handshake.None;
                //mySerialPort.RtsEnable = true;

                //mySerialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);

                //mySerialPort.Open();

                //Console.WriteLine("Press any key to continue...");
                //Console.WriteLine();   

                //port = new SerialPort("COM2", 9600, Parity.None, 8, StopBits.One); //Set port,. Boudrate
                //port.RtsEnable = true;
                //port.DtrEnable = true;

                //port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
                //Console.WriteLine("Incoming Data:");

                // Attach a method to be called when there is data waiting in the port's buffer
                //port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);

                // Begin communications
                //port.Open();

                //Connect_message.Text = "Connected";
            }
            catch
            {
                MessageBox.Show("Connect Error");
            }
        }

        private void Ethernet_Checked(object sender, RoutedEventArgs e)
        {
            //tcpClient = new TcpClient(); //re-initial
            //try
            //{
            //    Console.WriteLine("Connecting.....");
            //    try
            //    {
            //        #region 廣播
            //        //// 伺服器的 IP 與 Port
            //        //IPEndPoint servrIP = new IPEndPoint(IPAddress.Parse("169.254.180.86"), 58176);
            //        //// 自訂要監聽的 Port
            //        //IPEndPoint myIP = new IPEndPoint(IPAddress.Any, 4444);
            //        //uc = new UdpClient(myIP.Port);
            //        //string receive;
            //        //byte[] b;

            //        //// 從伺服器取得目前電腦的IP：
            //        //string myPublicIP = System.Text.Encoding.UTF8.GetString(uc.Receive(ref servrIP));
            //        //Console.WriteLine("目前電腦的IP：" + myPublicIP);
            //        //Console.WriteLine("\n|-----------------------------------|\n");

            //        //// 從伺服器取得對方IP：
            //        //receive = System.Text.Encoding.UTF8.GetString(uc.Receive(ref servrIP));
            //        //otherIP = new IPEndPoint(IPAddress.Parse(receive.Split(':')[0]), int.Parse(receive));

            //        ////預設主機IP
            //        //string hostIP = "169.254.180.86";

            //        ////先建立IPAddress物件,IP為欲連線主機之IP
            //        //IPAddress ipa = IPAddress.Parse(hostIP);

            //        ////建立IPEndPoint
            //        //IPEndPoint ipe = new IPEndPoint(ipa, 58176);
            //        #endregion

            //        //SPI HS重啟後，IP可能改變
            //        if (tcpClient.Connected != true)
            //        {
            //            //tcpClient.Connect(ipe);
            //            //tcpClient.ConnectAsync(ipa,58176);
            //            tcpClient.Connect("169.254.180.86", 58176); //58176
            //            //tcpClient.Connect("169.254.67.79", 58176); //58176
            //            IP_text.Text = "169.254.180.86";
            //        }

            //        if (tcpClient.Connected != true)
            //        {
            //            //tcpClient.Connect("169.254.180.87", 58176);
            //            IP_text.Text = "169.254.180.87";
            //        }

            //        Port_text.Text = "58176";
            //    }
            //    catch
            //    {
            //        Connect_message.Text = "IP Error";
            //    }

            //    netStream = tcpClient.GetStream();

            //    Console.WriteLine("Connected");
            //    Connect_message.Text = "Connected";
            //}

            //catch (Exception a)
            //{
            //    Console.WriteLine("Error..... " + a.StackTrace);
            //    Connect_message.Text = "Connect Error";
            //}
        }

        #region RS232 event
        //        private void RS232_Write_btn_Click(object sender, RoutedEventArgs e)
        //        {
        //            string localIP;
        //            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
        //            {
        //                socket.Connect("8.8.8.8", 65530);
        //                IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
        //                localIP = endPoint.Address.ToString();
        //                //MessageBox.Show(localIP);
        //                Console.WriteLine(localIP);
        //            }

        //            #region testRegion
        //            String strHostName = Dns.GetHostName();                                     //先讀取本機名稱

        //            IPHostEntry iphostentry = Dns.GetHostByName(strHostName);   //取得本機的 IpHostEntry 類別實體
        //            string ip = "";
        //            foreach (IPAddress ipaddress in iphostentry.AddressList)
        //            {
        //                Console.WriteLine(ipaddress.ToString());                               //使用了兩種方式都可以讀取出IP位置

        //                ip = ip + ipaddress.ToString();
        //            }
        //            Console.WriteLine(ip);
        //            Console.ReadLine();
        //            #endregion

        //            UdpClient oUDPClient = new UdpClient();
        //            IPEndPoint endPoint4Receiving = new IPEndPoint(IPAddress.Any, 0);
        //            //監聽&接收資料
        //            //String rcvMsg = Encoding.Default.GetString(oUDPClient.Receive(ref endPoint4Receiving));
        //            //這就是發送資料(遠端)的IP
        //            Console.WriteLine(endPoint4Receiving.Address);
        ////這就是發送資料(遠端)的Port
        ////endPoint4Receiving.Port

        //            //port.Open();
        //            ////port.Write("123");
        //            //port.Write(new byte[] { 0x02, 0x00, 0x00, 0x00, 0x00, 0x02 }, 0, 6);
        //        }

        //        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        //        {
        //            //讀入字串
        //            string data = port.ReadExisting();
        //            Console.WriteLine("Receive: " + data);
        //            /*
        //             //讀入位元組
        //            int bytes = port.BytesToRead;
        //            byte[] comBuffer = new byte[bytes];
        //            port.Read(comBuffer, 0, bytes);
        //            Console.WriteLine(comBuffer);
        //            */
        //        }

        //        private void Close_port_Click(object sender, RoutedEventArgs e)
        //        {
        //            if (Command_Combox.Text== "Get Status")
        //            {
        //                MessageBox.Show("Get Status");
        //            }

        //            //port.Close();
        //        }
        #endregion

        #region Ethernet event
        //private void Connect_btn_Click(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        Console.WriteLine("Connecting.....");                

        //        //IPEndPoint tIPEndPoint = new IPEndPoint(IPAddress.Parse(IPv4Address), Port);
        //        if (tcpClient.Connected != true)
        //        {
        //            try
        //            {                        
        //                tcpClient.Connect("169.254.180.86", 58176);
        //                IP_text.Text = "169.254.180.86";
        //            }
        //            catch
        //            {
        //                tcpClient.Connect("169.254.180.87", 58176);
        //                IP_text.Text = "169.254.180.87";
        //                //Console.WriteLine("Error..... " + a.StackTrace);
        //                //Connect_message.Text = "IP Error";
        //            }
        //            finally
        //            {
        //                Port_text.Text = "58176";
        //            }
        //        }                
        //        netStream = tcpClient.GetStream();
        //        // use the ipaddress as in the server program
        //        netStream = tcpClient.GetStream();
        //        Console.WriteLine("Connected");
        //        Connect_message.Text = "Connected";

        //        //string str = Command.Text;

        //        //ASCIIEncoding asen = new ASCIIEncoding();
        //        //byte[] ba = asen.GetBytes(str);
        //        //Console.WriteLine("Transmitting.....");

        //        //netStream.Write(ba, 0, ba.Length);
        //        //tcpclnt.Close();
        //    }

        //    catch (Exception a)
        //    {
        //        Console.WriteLine("Error..... " + a.StackTrace);
        //        Connect_message.Text = "Connect Error";
        //    }
        //}

        //private void Console_btn_Click(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        if (netStream.CanWrite)
        //        {
        //            byte[] TransmitCommand = new byte[ByteAmount];
        //            //command_case=1;
        //            //switch (command_case)
        //            //{
        //            //    //case = command no.
        //            //    case (int)Cmd.GetStatus:

        //            //        TransmitCommand = new byte[ByteAmount];                           

        //            //        for (int n=0 ; n < ByteAmount ; n++)
        //            //        {
        //            //            if (n == 0)
        //            //            {
        //            //                TransmitCommand[n] = (byte)BitCmd.StartByte;
        //            //            }
        //            //            else if (n == 1)
        //            //            {
        //            //                TransmitCommand[n] = (byte)NoOfCommand;
        //            //            }
        //            //            else if (n == 2)
        //            //            {
        //            //                TransmitCommand[n] = byte.Parse(command_case.ToString("X"), NumberStyles.HexNumber);
        //            //            }
        //            //            else if (n <= NoOfCommand+1 & n != 2)
        //            //            {

        //            //            }
        //            //            else if (n == ByteAmount-2)
        //            //            {
        //            //                TransmitCommand[n] = (byte)BitCmd.StopByte;
        //            //            }
        //            //            else if (n == ByteAmount - 1)
        //            //            {
        //            //                for (int c = 0; c < ByteAmount-1; c++)
        //            //                {
        //            //                    int crcvalue = (TransmitCommand[n] + TransmitCommand[c]);

        //            //                    TransmitCommand[n] = (byte)crcvalue;
        //            //                }
        //            //            }
        //            //        }                            
        //            //        MessageBox.Show("case1");
        //            //        break;
        //            //}

        //            TransmitCommand[0] = byte.Parse(str1, NumberStyles.HexNumber);
        //            TransmitCommand[1] = byte.Parse(str2, NumberStyles.HexNumber);
        //            TransmitCommand[2] = byte.Parse(str3, NumberStyles.HexNumber);
        //            TransmitCommand[3] = byte.Parse(str4, NumberStyles.HexNumber);
        //            TransmitCommand[4] = byte.Parse(str5, NumberStyles.HexNumber);
        //            TransmitCommand[5] = byte.Parse(str6, NumberStyles.HexNumber);

        //            //byte[] ba = asen.GetBytes(str);

        //            //stm = tcpclnt.GetStream(); //取得資料流

        //            netStream.Write(TransmitCommand, 0, TransmitCommand.Length); //寫入資料流

        //            //System.Threading.Thread.Sleep(1000);

        //            if (netStream.CanRead)
        //            {
        //                string[] returndata = new string[9];
        //                // Reads NetworkStream into a byte buffer.
        //                //byte[] bytes = new byte[tcpClient.ReceiveBufferSize];
        //                byte[] bytes = new byte[9];

        //                // Read can return anything from 0 to numBytesToRead. 
        //                // This method blocks until at least one byte is read.
        //                //netStream.Read(bytes, 0, (int)tcpClient.ReceiveBufferSize);
        //                netStream.Read(bytes, 0, 9);

        //                // Returns the data received from the host to the console.
        //                //returndata = Encoding.UTF8.GetString(bytes);
        //                for (int i = 0; i != bytes.Length; i++)
        //                {
        //                    returndata[i] = bytes[i].ToString("Y");
        //                }

        //                //Show return data
        //                RByte1.Text = returndata[0];
        //                RByte2.Text = returndata[1];
        //                RByte3.Text = returndata[2];
        //                RByte4.Text = returndata[3];
        //                RByte5.Text = returndata[4];
        //                RByte6.Text = returndata[5];
        //                RByte7.Text = returndata[6];
        //                RByte8.Text = returndata[7];
        //                RByte9.Text = returndata[8];

        //                Console.WriteLine("This is what the host returned to you: " + returndata);

        //            }
        //            else
        //            {
        //                Console.WriteLine("You cannot read data from this stream.");                        

        //                // Closing the tcpClient instance does not close the network stream.
        //                netStream.Close();
        //                tcpClient.Close();
        //                return;
        //            }

        //        }
        //    }


        //    catch (Exception a)
        //    {
        //        Console.WriteLine("You cannot transmit data to laser.");
        //        tcpClient.Close();                
        //        return;
        //    }

        //    // String str = Console.ReadLine();

        //    //Console.WriteLine("Transmitting.....");



        //    //byte[] bb = new byte[10];
        //    //int k = stm.Read(bb, 0, 10);

        //    //for (int i = 0; i < 5; i++)
        //    //    Console.Write(Convert.ToChar(bb[i]));

        //    //tcpclnt.Close();
        //    //Console.WriteLine("Connected");
        //    //Console.ReadKey();
        //}

        //private void Disconnect_Click(object sender, RoutedEventArgs e)
        //{           
        //    netStream.Close();
        //    //tcpClient.Client.Disconnect(true);
        //    tcpClient.Close();
        //}

        #endregion

        //private void Command_Combox_KeyUp(object sender, KeyEventArgs e)
        //{
        //    ComboBox cmb = (ComboBox)sender;
        //    CollectionView itemsViewOriginal = (CollectionView)CollectionViewSource.GetDefaultView(cmb.ItemsSource);

        //    itemsViewOriginal.Filter = ((o) =>
        //    {
        //        if (string.IsNullOrEmpty(cmb.Text)) return false;
        //        else
        //        {
        //            if (((string)o).StartsWith(cmb.Text)) return true;
        //            else return false;
        //        }
        //    });

        //    cmb.IsDropDownOpen = true;
        //    itemsViewOriginal.Refresh();
        //}

        //private void Command_Combox_DropDownClosed(object sender, EventArgs e)
        //{
        //    if (Command_Combox.Text != null)
        //    {
        //        if (Command_Combox.Text == "Get Status")
        //        {
        //            command_case = 1;
        //            ByteAmount = 5;
        //            MessageBox.Show(command_case.ToString());
        //        }
        //    }
        //}

        //private void RadioButton_Checked(object sender, RoutedEventArgs e)
        //{
        //    //SPI_Page spi_page = new SPI_Page();
        //    //Frame_page.Content = spi_page;
        //}
    }
}
