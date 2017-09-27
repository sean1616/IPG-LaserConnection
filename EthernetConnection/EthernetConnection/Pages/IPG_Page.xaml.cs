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
using System.Management;

namespace EthernetConnection.Pages
{
    /// <summary>
    /// IPG_Page.xaml 的互動邏輯
    /// </summary>
    public partial class IPG_Page : Page
    {
        TcpClient tcpClient;
        NetworkStream netStream;

        public IPG_Page()
        {
            InitializeComponent();
        }
                              
        public void setIP(string ip_address, string subnet_mask)
        {
            ManagementClass objMC = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection objMOC = objMC.GetInstances();

            foreach (ManagementObject objMO in objMOC)
            {
                if ((bool)objMO["IPEnabled"])
                {
                    try
                    {
                        ManagementBaseObject setIP;
                        ManagementBaseObject newIP =
                            objMO.GetMethodParameters("EnableStatic");

                        newIP["IPAddress"] = new string[] { ip_address };
                        newIP["SubnetMask"] = new string[] { subnet_mask };

                        setIP = objMO.InvokeMethod("EnableStatic", newIP, null);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Set IP failed");
                        throw;
                    }
                }
            }
        }
        string[] SArray;

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {                                  
            //setIP("192.168.3.231","255.255.240.0");

            

            
        }

        #region Command
        private void Read_Device_Status()
        {
            ASCIIEncoding asen = new ASCIIEncoding();
            byte[] command_code = asen.GetBytes("STA" + '\r');

            Console.WriteLine("Transmitting.....");

            netStream.Write(command_code, 0, command_code.Length);

            if (netStream.CanRead)
            {
                string returndata;
                // Reads NetworkStream into a byte buffer.
                byte[] bytes = new byte[15];
                //byte[] bytes = new byte[32];
                                       
                //讀取回傳值
                //The status is reported as a bit encoded 32-bit word.
                netStream.Read(bytes, 0, bytes.Length);

                //去除字串頭 ""STA: "
                byte[] Bytes = new byte[9];
                for (int i=0;i<9;i++)
                {
                    Bytes[i] = bytes[i + 5];
                }

                // Returns the data received from the host.

                returndata = Encoding.ASCII.GetString(Bytes); //convert bytes to string
                                                              
                int Returndata = Convert.ToInt32(returndata); //convert string to int

                #region 轉換回傳值
                int l;                
                string binary_string = Convert.ToString(Returndata, 2); //decimal to binary
                l = binary_string.Length; //位元字串長度
                char[] sarray = new char[l]; //建立陣列

                //將位元置入陣列
                foreach (var cha in binary_string)
                {
                    l--;
                    sarray[l] = cha;
                }
                #endregion                               

                //Show return data
                //GuideBeam_btn.Content = returndata;
                GuideBeam_btn.Content = sarray[8];
            }
            else
            {
                MessageBox.Show("Read failed");
            }
        }

        private void GuideBeam_btn_Click(object sender, RoutedEventArgs e)
        {
            ASCIIEncoding asen = new ASCIIEncoding();
            byte[] command_code = asen.GetBytes("ABN"+'\r');

            Console.WriteLine("Transmitting.....");

            netStream.Write(command_code, 0, command_code.Length);
        }
        #endregion

        private void Connect_btn_Click(object sender, RoutedEventArgs e)
        {
            tcpClient = new TcpClient();

            #region Ethernet connect
            try
            {
                Console.WriteLine("Connecting.....");

                if (tcpClient.Connected != true)
                {
                    try
                    {
                        tcpClient.Connect("192.168.3.230", 10001);
                        //IP_text.Text = "169.254.180.86";
                        //Port_text.Text = "10001";
                    }
                    catch
                    {
                        MessageBox.Show("UnConnected");
                        //Console.WriteLine("Error..... " + a.StackTrace);
                        //Connect_message.Text = "IP Error";
                    }
                }
                netStream = tcpClient.GetStream();

                //Console.WriteLine("Connected");
                MessageBox.Show("Connected");
            }

            catch
            {
                //Console.WriteLine("Error..... " + a.StackTrace);
                //Connect_message.Text = "Connect Error";
            }
            #endregion
        }

        private void Read_btn_Click(object sender, RoutedEventArgs e)
        {
            //取讀雷射狀態
            Read_Device_Status();
        }
    }
}
