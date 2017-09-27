using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows;
using EthernetConnection.GlobalChannel;
using EthernetConnection.Pages;
using System.Net;
using EthernetConnection.SPI_Command;

namespace EthernetConnection.ViewModel
{
    public class ET_Presenter : INotifyPropertyChanged
    {
        bool a=true;
        #region Page instance
        
        
        #endregion

        #region ICommand
        public ICommand SPI_Page_Command
        {
            get { return new ET_Delegatecommand(SPI_Page_Change); }
        }
        public ICommand IPG_Page_Command
        {
            get { return new ET_Delegatecommand(IPG_Page_Change); }
        }

        public ICommand SPI_RS232_Checked_Command
        {
            get { return new ET_Delegatecommand(SPI_RS232_Checked); }
        }

        public ICommand SPI_Ethernet_Checked_Command
        {
            get { return new ET_Delegatecommand(SPI_Ethernet_Checked); }
        }
        
        public ICommand Emit_btn_PreviewMouseDown_Command
        {
            get { return new ET_Delegatecommand(Emit_btn_PreviewMouseDown); }
        }       

        //Exit action
        public ICommand ExitCommand
        {
            get { return new ET_Delegatecommand(Exit); }
        }

        #endregion

        #region command
        private void SPI_Page_Change()
        {
            GlobalChannel.ET_GlobalChannel.Et_vm.Page = new SPI_Page();
        }

        private void IPG_Page_Change()
        {
            GlobalChannel.ET_GlobalChannel.Et_vm.Page = new IPG_Page();
        }

        private void SPI_RS232_Checked()
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

        private void SPI_Ethernet_Checked()
        {
            try
            {
                Console.WriteLine("Connecting.....");
                try
                {
                    IPEndPoint SPI_IP;

                    #region UDP
                    //// 伺服器的 IP 與 Port
                    //IPEndPoint servrIP = new IPEndPoint(IPAddress.Parse("169.254.180.86"), 58176);
                    //// 自訂要監聽的 Port
                    //IPEndPoint myIP = new IPEndPoint(IPAddress.Any, 4444);
                    //uc = new UdpClient(myIP.Port);
                    //string receive;
                    //byte[] b;

                    //// 從伺服器取得目前電腦的IP：
                    //string myPublicIP = System.Text.Encoding.UTF8.GetString(uc.Receive(ref servrIP));
                    //Console.WriteLine("目前電腦的IP：" + myPublicIP);
                    //Console.WriteLine("\n|-----------------------------------|\n");

                    //// 從伺服器取得對方IP：
                    //receive = System.Text.Encoding.UTF8.GetString(uc.Receive(ref servrIP));
                    //otherIP = new IPEndPoint(IPAddress.Parse(receive.Split(':')[0]), int.Parse(receive));

                    ////預設主機IP
                    //string hostIP = "169.254.180.86";

                    ////先建立IPAddress物件,IP為欲連線主機之IP
                    //IPAddress ipa = IPAddress.Parse(hostIP);

                    ////建立IPEndPoint
                    //IPEndPoint ipe = new IPEndPoint(ipa, 58176);
                    #endregion

                    //SPI HS重啟後，IP可能改變
                    try
                    {
                        if (ET_GlobalChannel.Et_vm.Tcpclient.Connected != true)
                        {
                            //ET_GlobalChannel.Et_vm.Tcpclient.Connect(ipe);
                            //ET_GlobalChannel.Et_vm.Tcpclient.ConnectAsync(ipa,58176);
                            SPI_IP = new IPEndPoint(IPAddress.Parse("169.254.180.86"), 58176);
                            ET_GlobalChannel.Et_vm.Tcpclient.Connect(SPI_IP); //58176

                            //ET_GlobalChannel.Et_vm.Tcpclient.Connect("169.254.67.79", 58176); //58176
                            ET_GlobalChannel.Et_vm.IP_str = SPI_IP.Address.ToString();
                        }
                    }
                    catch
                    {
                        if (ET_GlobalChannel.Et_vm.Tcpclient.Connected != true)
                        {
                            SPI_IP = new IPEndPoint(IPAddress.Parse("169.254.180.87"), 58176);
                            ET_GlobalChannel.Et_vm.Tcpclient.Connect(SPI_IP);

                            ET_GlobalChannel.Et_vm.IP_str = SPI_IP.Address.ToString();
                        }
                    }
                    finally
                    {
                        ET_GlobalChannel.Et_vm.Port_str = "58176";
                    }
                }
                catch
                {
                    ET_GlobalChannel.Et_vm.Status_str = "Error";
                }

                ET_GlobalChannel.Et_vm.Netstream = ET_GlobalChannel.Et_vm.Tcpclient.GetStream();
                //netStream = ET_GlobalChannel.Et_vm.Tcpclient.GetStream();

                Console.WriteLine("Connected");
                ET_GlobalChannel.Et_vm.Status_str = "Connected";
            }

            catch (Exception a)
            {
                Console.WriteLine("Error..... " + a.StackTrace);
                ET_GlobalChannel.Et_vm.Status_str = "Connect Error";
            }

            #region Backgroundworker-Read Status
            if (a)
            {
                Worker W1 = new Worker(ET_GlobalChannel.Et_vm.Tcpclient, ET_GlobalChannel.Et_vm.Tcpclient.GetStream(), 0x00);
                ET_GlobalChannel.Et_vm.Worker = W1.m_worker;
                //ET_GlobalChannel.Et_vm.Worker.RunWorkerAsync();
                a = false;
            }
            
            //ET_GlobalChannel.Et_vm.Worker.CancelAsync();
            #endregion
        }

        private void Emit_btn_PreviewMouseDown()
        {
            if (ET_GlobalChannel.Et_vm.Tcpclient.Connected)
            {
                ET_GlobalChannel.Et_vm.IR_status = true; //因UI執行緒在Click事件中時會暫停，因此將UI動作與Click提前分離
            }
        }        

        private void Exit()
        {
            if (MessageBox.Show("Sure to close the application?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
            else
                return;
        }
        #endregion

        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

    }
}
