using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using EthernetConnection.ViewModel;
using EthernetConnection.GlobalChannel;

namespace EthernetConnection.SPI_Command
{
    public class Command_cal
    {        
        int setpower, a, b;
        byte A, B;

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
            Set_Required_Power_Level=10,
            Get_Output_Power_Level=11,
            Maintenance = 14,
            Red_Targeting_Laser_Control = 16,
        }

        #region Command
        public byte[] Command(int ByteAmount, int command_case, byte data_byte_1)
        {
            byte[] TransmitCommand = new byte[ByteAmount];
            a = ByteAmount - 2;
            
            //填入指令
            TransmitCommand[0] = (byte)BitCmd.StartByte;
            TransmitCommand[1] = (byte)(ByteAmount - 4);
            TransmitCommand[2] = byte.Parse(command_case.ToString("X"), NumberStyles.HexNumber);

            for (int N = 3; N < ByteAmount; N++)
            {
                if (N == ByteAmount - 2) //StopByte
                {
                    TransmitCommand[N] = (byte)BitCmd.StopByte;
                }
                else if (N == ByteAmount - 1)  //CRC byte (Addition of bytes 1 through 6)
                {
                    for (int count = 0; count < ByteAmount - 1; count++)
                    {
                        int crcvalue = (TransmitCommand[N] + TransmitCommand[count]);

                        TransmitCommand[N] = (byte)crcvalue;
                    }
                }

                else //Command Case 
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
                                //TransmitCommand[N] = 0x01; //Internal required set power
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
                                else if (N == 4)  
                                {
                                    TransmitCommand[N] = 55;
                                }
                                else if (N == 5)  
                                {
                                    TransmitCommand[N] = 75;
                                }
                                else if (N == 6) 
                                {
                                    TransmitCommand[N] = 54;
                                }
                            }
                            break;

                        case (int)Cmd.Set_Required_Power_Level:
                            for (N = 3; N < ByteAmount - 2; N++)
                            {
                                setpower = (int)float.Parse(ET_GlobalChannel.Et_vm.Set_power) * 10; //string to int 小數進位
                                a = setpower % 256;
                                b = setpower / 256;
                                A = Convert.ToByte(a); //LSB
                                B = Convert.ToByte(b); //MSB

                                if (N == 3)  //LSB
                                {                                                                                                  
                                    TransmitCommand[N] = A;
                                }
                                else if (N == 4)  //MSB
                                {
                                    TransmitCommand[N] = B;                                       
                                }                                
                            }
                            break;

                        case (int)Cmd.Maintenance:
                            for (N = 3; N < ByteAmount - 2; N++)
                            {
                            }
                            break;

                        case (int)Cmd.Get_Output_Power_Level:
                            for (N = 3; N < ByteAmount - 2; N++)
                            {
                            }
                            break;

                        case (int)Cmd.Red_Targeting_Laser_Control:
                            for (N = 3; N < ByteAmount - 2; N++)
                            {
                                TransmitCommand[N] = data_byte_1;
                            }
                            break;
                    }
                    N = N - 1;                    
                }
            }
            
            return TransmitCommand;
        }                       
        
        #endregion
    }
}
