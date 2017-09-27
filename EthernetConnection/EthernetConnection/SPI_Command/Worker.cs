using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Net.Sockets;
using EthernetConnection.GlobalChannel;
using System.Threading;

namespace EthernetConnection.SPI_Command
{
    public class Worker
    {
        byte[] bytes;
        byte[] Read_Status;
        bool m_continue=true;
        string input, input_1, input_2, LSB, MSB, Total_Power;
        byte[] Read_Status_1, Read_Status_2;
        int RLS=0, readstatus_key = 0;
        byte data_byte_1;
        TcpClient tcpClient;
        NetworkStream netStream;

        int ByteAmount;
        int command_case;
        int ByteAmount_Read;
        byte[] command_data;

        public BackgroundWorker m_worker;

        public Worker(TcpClient TcpClient, NetworkStream NetStream, byte Data_Byte_1)
        {
            tcpClient = TcpClient;
            netStream = tcpClient.GetStream();
            data_byte_1 = Data_Byte_1;
            BackgroundWorker_setting();
            //ET_GlobalChannel.Et_vm.BW = m_worker;
        }
        
        private void BackgroundWorker_setting()
        {
            m_worker = new BackgroundWorker();
            m_worker.WorkerReportsProgress = true;
            m_worker.WorkerSupportsCancellation = true;

            m_worker.DoWork += m_worker_DoWork;
            m_worker.ProgressChanged += m_worker_ProgressChanged;
            m_worker.RunWorkerCompleted += m_worker_AfterWork;
        }

        #region BackgroundWorker arg
        private void m_worker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (tcpClient.Connected)
            {
                try
                {
                    #region Get status 0x01

                    ByteAmount = 5;
                    command_case = 1;
                    ByteAmount_Read = 7;

                    if (netStream.CanWrite)
                    {
                        command_data = ET_GlobalChannel.command_cal.Command(ByteAmount, command_case, data_byte_1);
                        netStream.Write(command_data, 0, command_data.Length);
                    }

                    Thread.Sleep(100);
                    
                    if (netStream.CanRead)
                    {
                        bytes = new byte[ByteAmount_Read];

                        netStream.Read(bytes, 0, bytes.Length);

                        
                    }

                    #endregion
                    
                    Thread.Sleep(100);
                    m_worker.ReportProgress(1);
                    #region I/O status 0x02

                    ByteAmount = 5; //Different command has different number of bytes
                    command_case = 2;
                    ByteAmount_Read = 13;

                    if (netStream.CanWrite)
                    {
                        command_data = ET_GlobalChannel.command_cal.Command(ByteAmount, command_case, data_byte_1);
                        netStream.Write(command_data, 0, command_data.Length);
                    }
                    Thread.Sleep(100);
                    //讀取回傳資料
                    if (netStream.CanRead)
                    {
                        byte[] bytes = new byte[ByteAmount_Read];

                        netStream.Read(bytes, 0, ByteAmount_Read);

                        #region Data Convertor
                        //input = Convert.ToString(bytes[3], 2);
                        //int numOfBytes = input.Length;

                        //Read_Status = new byte[numOfBytes];
                        //for (int i = 0; i < numOfBytes; ++i)
                        //{
                        //    Read_Status[i] = Convert.ToByte(input.Substring(i, 1), 2);
                        //}
                        #endregion
                    }

                    #endregion

                    Thread.Sleep(100);

                    #region 如果電話亭: key off
                    //if (readstatus_key == 0)
                    //{
                    //    if (netStream.CanWrite)
                    //    {
                    //        #region 開啟權限
                    //        int byteamount_level = 9;
                    //        int cmd_case = 9;
                    //        ByteAmount_Read = 7;
                    //        command_data = ET_GlobalChannel.command_cal.Command(byteamount_level, cmd_case, data_byte_1);
                    //        netStream.Write(command_data, 0, command_data.Length); //寫入資料流

                    //        //讀取回傳資料
                    //        if (netStream.CanRead)
                    //        {
                    //            byte[] bytes = new byte[ByteAmount_Read];
                    //            netStream.Read(bytes, 0, ByteAmount_Read);
                    //        }
                    //        #endregion

                    //        #region 打開水閥
                    //        //byteamount_level = 7;
                    //        //cmd_case = 14;
                    //        //ByteAmount_Read = 8;
                    //        //command_data = ET_GlobalChannel.command_cal.Command(byteamount_level, cmd_case, data_byte_1);
                    //        //netStream.Write(command_data, 0, command_data.Length);
                    //        ////讀取回傳資料
                    //        //if (netStream.CanRead)
                    //        //{
                    //        //    string[] returndata = new string[ByteAmount_Read];

                    //        //    // Reads NetworkStream into a byte buffer.
                    //        //    byte[] bytes = new byte[ByteAmount_Read];

                    //        //    netStream.Read(bytes, 0, ByteAmount_Read);

                    //        //    // Returns the data received from the host to the console.                            
                    //        //    for (int i = 0; i != bytes.Length; i++)
                    //        //    {
                    //        //        returndata[i] = bytes[i].ToString("X");
                    //        //    }

                    //        //    input = Convert.ToString(bytes[3], 2);
                    //        //    int numOfBytes = input.Length;

                    //        //    Read_Status = new byte[numOfBytes];
                    //        //    for (int i = 0; i < numOfBytes; ++i)
                    //        //    {
                    //        //        Read_Status[i] = Convert.ToByte(input.Substring(i, 1), 2);
                    //        //    }

                    //        //    Console.WriteLine("This is what the host returned to you: " + returndata);
                    //        //}
                    //        //else
                    //        //{
                    //        //    Console.WriteLine("You cannot read data from this stream.");

                    //        //    // Closing the tcpClient instance does not close the network stream.
                    //        //    netStream.Close();
                    //        //    tcpClient.Close();
                    //        //    return;
                    //        //}
                    //        #endregion
                    //    }
                    //}
                    #endregion         

                    #region Get Analog Input
                    //ByteAmount = 6; //Different command has different number of bytes
                    //command_case = 3;
                    //ByteAmount_Read = 9;

                    //command_data = ET_GlobalChannel.command_cal.Command(ByteAmount, command_case, data_byte_1);
                    //netStream.Write(command_data, 0, command_data.Length);
                    ////一定要讀取回傳資料
                    //if (netStream.CanRead)
                    //{
                    //    string[] returndata = new string[ByteAmount_Read];

                    //    // Reads NetworkStream into a byte buffer.
                    //    byte[] bytes = new byte[ByteAmount_Read];

                    //    netStream.Read(bytes, 0, ByteAmount_Read);

                    //    // Returns the data received from the host to the console.                            
                    //    for (int i = 0; i != bytes.Length; i++)
                    //    {
                    //        returndata[i] = bytes[i].ToString("X");
                    //    }

                    //    input = Convert.ToString(bytes[3], 2);
                    //    int numOfBytes = input.Length;

                    //    Read_Status = new byte[numOfBytes];
                    //    for (int i = 0; i < numOfBytes; ++i)
                    //    {
                    //        Read_Status[i] = Convert.ToByte(input.Substring(i, 1), 2);
                    //    }
                    //    readstatus_key = Read_Status[6];
                    //}
                    //else
                    //{
                    //    Console.WriteLine("You cannot read data from this stream.");

                    //    // Closing the tcpClient instance does not close the network stream.
                    //    netStream.Close();
                    //    tcpClient.Close();
                    //    return;
                    //}
                    #endregion                                        

                    #region Get Output Power 0x0B

                    ByteAmount = 5;
                    command_case = 11;
                    ByteAmount_Read = 8;

                    if (netStream.CanWrite)
                    {
                        command_data = ET_GlobalChannel.command_cal.Command(ByteAmount, command_case, data_byte_1);
                        netStream.Write(command_data, 0, command_data.Length);
                    }
                    Thread.Sleep(100);
                    if (netStream.CanRead)
                    {
                        // Reads NetworkStream into a byte buffer.
                        byte[] bytes = new byte[ByteAmount_Read];

                        netStream.Read(bytes, 0, ByteAmount_Read);

                        LSB = Convert.ToString(bytes[4] / 2);
                        MSB = Convert.ToString(bytes[5]);
                        Total_Power = (Convert.ToDouble(LSB) + Convert.ToDouble(MSB) * 128).ToString();
                    }

                    #endregion
                    
                    Thread.Sleep(200); 

                    if (ET_GlobalChannel.Et_vm.Worker.CancellationPending)
                    {
                        e.Cancel = true; //CancellationPending只在DoWork內有作用，要在WorkComplete中作用則需透過e.Cancel!
                    }

                    //m_worker.ReportProgress(1); //一定要用ReportProgress才能激發ProgressChanged事件!!!                                                
                }

                catch
                {                    
                    MessageBox.Show("Command Error");
                    return;
                }
            }
        }

        //private void m_worker_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    while (m_continue)
        //    {
        //        if (tcpClient.Connected == true)  //Is tcpClient Connected or not
        //        {
        //            //netStream = tcpClient.GetStream();

        //            try
        //            {
        //                if (netStream.CanWrite)
        //                {
        //                    //權限開啟 //failed!!
        //                    int byteamount_level = 9;
        //                    int cmd_case = 9;
        //                    int ByteAmount_Read = 7;
        //                    netStream.Write(Command(byteamount_level, cmd_case), 0, Command(byteamount_level, cmd_case).Length); //寫入資料流

        //                    //一定要讀取回傳資料
        //                    if (netStream.CanRead)
        //                    {
        //                        string[] returndata = new string[ByteAmount_Read];

        //                        // Reads NetworkStream into a byte buffer.
        //                        byte[] bytes = new byte[ByteAmount_Read];

        //                        netStream.Read(bytes, 0, ByteAmount_Read);

        //                        // Returns the data received from the host to the console.                            
        //                        for (int i = 0; i != bytes.Length; i++)
        //                        {
        //                            returndata[i] = bytes[i].ToString("X");
        //                        }

        //                        input = Convert.ToString(bytes[3], 2);
        //                        int numOfBytes = input.Length;

        //                        Read_Status = new byte[numOfBytes];
        //                        for (int i = 0; i < numOfBytes; ++i)
        //                        {
        //                            Read_Status[i] = Convert.ToByte(input.Substring(i, 1), 2);
        //                        }


        //                        Console.WriteLine("This is what the host returned to you: " + returndata);
        //                    }
        //                    else
        //                    {
        //                        Console.WriteLine("You cannot read data from this stream.");

        //                        // Closing the tcpClient instance does not close the network stream.
        //                        netStream.Close();
        //                        tcpClient.Close();
        //                        return;
        //                    }

        //                    //打開水閥
        //                    byteamount_level = 7;
        //                    cmd_case = 14;
        //                    ByteAmount_Read = 8;
        //                    netStream.Write(Command(byteamount_level, cmd_case), 0, Command(byteamount_level, cmd_case).Length); //寫入資料流

        //                    //一定要讀取回傳資料
        //                    if (netStream.CanRead)
        //                    {
        //                        string[] returndata = new string[ByteAmount_Read];

        //                        // Reads NetworkStream into a byte buffer.
        //                        byte[] bytes = new byte[ByteAmount_Read];

        //                        netStream.Read(bytes, 0, ByteAmount_Read);

        //                        // Returns the data received from the host to the console.                            
        //                        for (int i = 0; i != bytes.Length; i++)
        //                        {
        //                            returndata[i] = bytes[i].ToString("X");
        //                        }

        //                        input = Convert.ToString(bytes[3], 2);
        //                        int numOfBytes = input.Length;

        //                        Read_Status = new byte[numOfBytes];
        //                        for (int i = 0; i < numOfBytes; ++i)
        //                        {
        //                            Read_Status[i] = Convert.ToByte(input.Substring(i, 1), 2);
        //                        }

        //                        Console.WriteLine("This is what the host returned to you: " + returndata);
        //                    }
        //                    else
        //                    {
        //                        Console.WriteLine("You cannot read data from this stream.");

        //                        // Closing the tcpClient instance does not close the network stream.
        //                        netStream.Close();
        //                        tcpClient.Close();
        //                        return;
        //                    }

        //                    //Target Laser
        //                    int ByteAmount_IO = 5; //Different command has different number of bytes
        //                    int command_case = 2;
        //                    ByteAmount_Read = 13;

        //                    netStream.Write(Command(ByteAmount_IO, command_case), 0, Command(ByteAmount_IO, command_case).Length); //寫入資料流

        //                    //一定要讀取回傳資料
        //                    if (netStream.CanRead)
        //                    {
        //                        string[] returndata = new string[ByteAmount_Read];

        //                        // Reads NetworkStream into a byte buffer.
        //                        byte[] bytes = new byte[ByteAmount_Read];

        //                        netStream.Read(bytes, 0, ByteAmount_Read);

        //                        // Returns the data received from the host to the console.                            
        //                        for (int i = 0; i != bytes.Length; i++)
        //                        {
        //                            returndata[i] = bytes[i].ToString("X");
        //                        }

        //                        input = Convert.ToString(bytes[3], 2);
        //                        int numOfBytes = input.Length;

        //                        Read_Status = new byte[numOfBytes];
        //                        for (int i = 0; i < numOfBytes; ++i)
        //                        {
        //                            Read_Status[i] = Convert.ToByte(input.Substring(i, 1), 2);
        //                        }
        //                        readstatus = Read_Status[6];

        //                        Console.WriteLine("This is what the host returned to you: " + returndata);
        //                    }
        //                    else
        //                    {
        //                        Console.WriteLine("You cannot read data from this stream.");

        //                        // Closing the tcpClient instance does not close the network stream.
        //                        netStream.Close();
        //                        tcpClient.Close();
        //                        return;
        //                    }

        //                }

        //                //Thread.Sleep(500);
        //                m_worker.ReportProgress(1); //一定要用ReportProgress才能激發ProgressChanged事件!!!

        //                m_continue = false;
        //                m_worker.CancelAsync();
        //                Thread.Sleep(500);
        //                M_continue = true;
        //                M_worker.RunWorkerAsync();
        //                Thread.Sleep(500);
        //            }

        //            catch (Exception a)
        //            {
        //                Console.WriteLine("You cannot transmit data to laser.");
        //                tcpClient.Close();
        //                return;
        //            }

        //        }
        //    }

        //}

        private void m_worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            #region Data Convertor
            string[] input = { Convert.ToString(bytes[3], 2), Convert.ToString(bytes[4], 2) };

            int[] numOfBytes = { input[0].Length, input[1].Length };

            int n = 7;
            Read_Status_1 = new byte[8];
            for (int i = numOfBytes[0] - 1; i >= 0; i--)
            {
                Read_Status_1[n] = Convert.ToByte(input[0].Substring(i, 1), 2);
                n--;
            }

            RLS = Read_Status_1[4];

            n = 7;
            Read_Status_2 = new byte[8];
            for (int i = numOfBytes[1] - 1; i >= 0; i--)
            {
                Read_Status_2[n] = Convert.ToByte(input[1].Substring(i, 1), 2);
                n--;
            }
            readstatus_key = Read_Status_2[1];
            #endregion

            if (RLS == 1)
                ET_GlobalChannel.Et_vm.Pilot_status = true;
            else
                ET_GlobalChannel.Et_vm.Pilot_status = false;

            if (readstatus_key == 0)
                ET_GlobalChannel.Et_vm.Key = "Off";
            else
                ET_GlobalChannel.Et_vm.Key = "On";

            ET_GlobalChannel.Et_vm.Watt_str = Total_Power;                        
        }

        private void m_worker_AfterWork(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!ET_GlobalChannel.Et_vm.Worker.CancellationPending && !e.Cancelled)
            {
                ET_GlobalChannel.Et_vm.Worker.RunWorkerAsync();
            }                      
        }

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

        private void Netstream_Write(byte data_byte_1)
        {
            if (netStream.CanWrite)
            {
                command_data = ET_GlobalChannel.command_cal.Command(ByteAmount, command_case, data_byte_1);
                netStream.Write(command_data, 0, command_data.Length);
            }            
        }

        private void Netstream_Read(NetworkStream netStream, int ByteAmount, int command_case)
        {
            if (netStream.CanRead)
            {
                byte[] bytes = new byte[ByteAmount_Read];

                netStream.Read(bytes, 0, ByteAmount_Read);

                LSB = Convert.ToString(bytes[4] / 2);
                MSB = Convert.ToString(bytes[5]);
                Total_Power = (Convert.ToDouble(LSB) + Convert.ToDouble(MSB) * 128).ToString();
            }
        }

        #endregion
    }
}
