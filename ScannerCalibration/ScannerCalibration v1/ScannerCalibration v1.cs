using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Drawing.Drawing2D;


namespace ScannerCalibration
{
    public partial class Form1 : Form
    {        
        string a, b, c, d, f, g, h, NewName_text, Current_Position;
        int I, J, M, Length_Value, Matrix_Value, NewCal_Value;
               
        float OffsetX_value, OffsetY_value, ExpansionX_value, ExpansionY_value, Rotation_value, Offset_Rotation;
        Stopwatch stopwatch = new Stopwatch();
        count CountProcess;
        Text t = new Text();

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {
            string Type_case = toolStripComboBox1.Text;
            switch (Type_case)
            {
                case "AMP-160":
                    Oldfile.Text = "D2_1251";
                    NewCal.Value = 4000;
                    Length.Value = 160;                    
                    break;

                case "AMP-250":
                    Oldfile.Text = "D3_1386";
                    NewCal.Value = 3120;
                    Length.Value = 250;
                    break;

                case "AMP-500":
                    Oldfile.Text = "D2_1075";
                    NewCal.Value = 2496;
                    Length.Value = 250;
                    break;

                default:
                    Oldfile.Text = "D3_1386";
                    NewCal.Value = 3120;
                    Length.Value = 250;
                    break;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string direction_case = Direction_combo.Text;
            switch (direction_case)
            {
                case "Right (AMP-250)":
                    Offset_Rotation = 90;
                    StatusLabel2.Text = "Right";
                    break;

                case "Back (AMP-160)":
                    Offset_Rotation = 0;
                    StatusLabel2.Text = "Back";
                    break;

                case "Left":
                    Offset_Rotation = -90;
                    StatusLabel2.Text = "Left";
                    break;

                default:
                    Offset_Rotation = 90;
                    break;
            }
            
        }

        private void Initial_Value()
        {
            Length_Value = (int)Length.Value; //length
            Matrix_Value = (int)Matrix.Value; //matrix
            NewCal_Value = (int)NewCal.Value; //Newcal

            #region Initial Value 判斷輸入格中是否為0

            if (OffsetX.Text == "")
            {
                // If the value in the numeric updown is an empty string, replace with 0.
                OffsetX.Text = "0";
            }

            if (OffsetY.Text == "")
            {
                // If the value in the numeric updown is an empty string, replace with 0.
                OffsetY.Text = "0";
            }
            if (ExpandX.Text == "")
            {
                // If the value in the numeric updown is an empty string, replace with 0.
                ExpandX.Text = "0";
            }
            if (ExpandY.Text == "")
            {
                // If the value in the numeric updown is an empty string, replace with 0.
                ExpandY.Text = "0";
            }
            #endregion

            //float OXV = (float) OffsetX.Value;
            //float OYV = (float)OffsetY.Value;
            OffsetX_value = (float)OffsetX.Value;  //X, Y對調處!!!!!!
            OffsetY_value = (float)OffsetY.Value;  //X, Y對調處!!!!!!
            ExpansionX_value = (float)ExpandX.Value;
            ExpansionY_value = (float)ExpandY.Value;
            Rotation_value = (float)Rotation_angle.Value;
        }

        public Form1()
        {
            InitializeComponent();             
        }

        private void Dat_btn_Click(object sender, EventArgs e)
        {
            stopwatch.Reset();//碼表歸零
            stopwatch.Start();//碼表開始計時
                        
            NewName_text = Newname.Text;
            int M_sqrt = (int)Matrix.Value * (int)Matrix.Value;

            #region 參數設定
            a = "OLDCTFILE = " + Oldfile.Text + ".ct5" + " 		// file name of the correction file used for marking the measured points" + Environment.NewLine;
            b = "NEWCTFILE = " + Newname.Text + ".ct5" + " 		// file name of the new correction file" + Environment.NewLine;
            c = "TOLERANCE = " + Tolerance.Value + " 		// allowed deviation from measured points in um" + Environment.NewLine;
            d = "NEWCAL = " + NewCal.Value + " 		// new calibration factor [bit/mm] used for the new correction file" + Environment.NewLine;
            f = "FITORDER = " + FitOrder.Value + " 		// limits the order of the fit to this number" + Environment.NewLine;

            g = t.text_g(CheckL.Checked, (int)Limitvalue.Value);
            h = t.text_h(CheckPL.Checked, (int)Plimitvalue.Value);
            #endregion

            //讀取目前路徑
            Current_Position = Directory.GetCurrentDirectory();

            //建立新.dat檔
            using (StreamWriter file = new StreamWriter(@Current_Position + "\\" + NewName_text + ".dat", true))
            {
                file.WriteLine(a + b + c + d + f);
            }
            //刪除.dat檔
            File.Delete(@Current_Position + "\\" + NewName_text + ".dat");

            //建立.dat檔 
            using (StreamWriter file = new StreamWriter(@Current_Position + "\\" + NewName_text + ".dat", true))
            {
                file.WriteLine(a + b + "\r\n" + c + "\r\n" + d + "\r\n" + f + "\r\n" + g + h); //參數設定

                file.WriteLine("// RTC-X [bit] RTC-Y[bit] REAL-X[mm] REAL-Y[mm]" + "\r\n"); //座標說明
                                
                Initial_Value(); //判斷輸入格中是否為0 並 初始化使用參數   

                CountProcess = new count((int)Length_Value, (int)Matrix.Value);

                for (int N=0; N < M_sqrt; N++)
                {
                    //Console.Write(CountProcess.CorXY(NewCal_Value, N) +"    ");
                    //Console.WriteLine(CountProcess.Cor_Real_XY(OffsetX_value, OffsetY_value, ExpansionX_value, ExpansionY_value, Rotation_value, Final_Rotation, N));

                    file.WriteLine(CountProcess.CorXY(NewCal_Value, N) + "     " + CountProcess.Cor_Real_XY(OffsetX_value, OffsetY_value, ExpansionX_value, ExpansionY_value, Rotation_value, Offset_Rotation, N));
                }

                for (I = 0; I < (int)Matrix.Value; I++)
                {
                    for (J = 0; J < (int)Matrix.Value; J++)
                    {


                        //輸出所有點
                        //file.WriteLine((CountProcess.CorXY(Length_Value, Matrix_Value, NewCal_Value, I, J)) //RTC_XY
                        //    + "    " + (CountProcess.Cor_Real_XY(Length_Value, Matrix_Value,
                        //    OffsetX_value, OffsetY_value, ExpansionX_value, ExpansionY_value, I, J, Rotation_value, Final_Rotation))); //Real_XY
                    }
                }
            }

            Process.Start(@Current_Position + "\\" + NewName_text + ".dat"); //開啟.dat檔

            stopwatch.Stop();//碼錶停止

            string result1 = stopwatch.Elapsed.Milliseconds.ToString();

            toolstrip1.Text = "TimeSpan: " + result1 + " ms";//印出所花費的總豪秒數 

            GC.Collect();
        }
        
        private void Matrix_ValueChanged(object sender, EventArgs e)
        {
            Matrix2.Value = Matrix.Value;

            if (Matrix.Value % 2 == 0)
            {
                MessageBox.Show("矩陣數建議為奇數");
            }
        }                

        private void Correxion_btn_Click(object sender, EventArgs e)
        {
            string waytocorrexion = Directory.GetCurrentDirectory();
            
            Process.Start(@waytocorrexion+"\\"+ "ScannerCalibration v1"+"\\" + "correxion5"+"\\"+"correXionPro.exe");
        }
        
    }
}
