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
        Stopwatch stopwatch = new Stopwatch();//引用stopwatch物件
        string a, b, c, d, f, g, h, NewName_text, Current_Position;
        int I, J, M, Length_Value, Matrix_Value, NewCal_Value;

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
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string direction_case = Direction_combo.Text;
            switch (direction_case)
            {
                case "Right (AMP-250)":
                    Final_Rotation = 270;
                    StatusLabel2.Text = "Right";
                    break;

                case "Back (AMP-160)":
                    Final_Rotation = 0;
                    StatusLabel2.Text = "Back";
                    break;

                case "Left":
                    Final_Rotation = 90;
                    StatusLabel2.Text = "Left";
                    break;
            }
        }

        float OffsetX_value, OffsetY_value, ExpansionX_value, ExpansionY_value, Rotation_value, Final_Rotation;                        
        count CountProcess;
        Text t = new Text();

        public Form1()
        {
            InitializeComponent();

            CountProcess = new count();

            Final_Rotation = 0;
        }

        private void Dat_btn_Click(object sender, EventArgs e)
        {
            stopwatch.Reset();//碼表歸零
            stopwatch.Start();//碼表開始計時

            NewName_text = Newname.Text;
            M = (int)Matrix.Value;

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
                                
                Initial_Value(); //判斷輸入格中是否為0                               

                for (I = 0; I < M; I++)
                {
                    for (J = 0; J < M; J++)
                    {
                        //輸出所有點
                        file.WriteLine((CountProcess.CorXY(Length_Value, Matrix_Value, NewCal_Value, I, J)) //RTC_XY
                            + "    " + (CountProcess.CorRealXY(Length_Value, Matrix_Value,
                            OffsetX_value, OffsetY_value, ExpansionX_value, ExpansionY_value, I, J, Rotation_value, Final_Rotation))); //Real_XY
                    }
                }
            }

            Process.Start(@Current_Position + "\\" + NewName_text + ".dat"); //開啟.dat檔

            stopwatch.Stop();//碼錶停止

            string result1 = stopwatch.Elapsed.Milliseconds.ToString();

            toolstrip1.Text = "TimeSpan: " + result1 + " ms";//印出所花費的總豪秒數 

            GC.Collect();
        }

        //private void RotateButton_Click(object sender, EventArgs e)
        //{
        //    System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();//引用stopwatch物件
        //    sw.Reset();//碼表歸零
        //    sw.Start();//碼表開始計時

        //    string Nn = Newname.Text;
        //    int I, J, M = (int)Matrix.Value;

        //    count CountRotation = new count();
        //    Text t = new Text();

        //    string a = "OLDCTFILE = " + Oldfile.Text + ".ct5" + " 		// file name of the correction file used for marking the measured points" + Environment.NewLine;
        //    string b = "NEWCTFILE = " + Newname.Text + ".ct5" + " 		// file name of the new correction file" + Environment.NewLine;
        //    string c = "TOLERANCE = " + Tolerance.Value + " 		// allowed deviation from measured points in um" + Environment.NewLine;
        //    string d = "NEWCAL = " + NewCal.Value + " 		// new calibration factor [bit/mm] used for the new correction file" + Environment.NewLine;
        //    string f = "FITORDER = " + FitOrder.Value + " 		// limits the order of the fit to this number" + Environment.NewLine;

        //    string g = t.text_g(CheckL.Checked, (int)Limitvalue.Value);
        //    string h = t.text_h(CheckPL.Checked, (int)Plimitvalue.Value);

        //    //讀取目前路徑
        //    string L = Directory.GetCurrentDirectory();
        //    //建立新.dat檔
        //    using (StreamWriter file = new StreamWriter(@L + "\\" + Nn + ".dat", true))
        //    {
        //        file.WriteLine(a + b + c + d + f);
        //    }
        //    //刪除.dat檔
        //    File.Delete(@L + "\\" + Nn + ".dat");

        //    //建立.dat檔 
        //    using (StreamWriter file = new StreamWriter(@L + "\\" + Nn + ".dat", true))
        //    {
        //        file.WriteLine(a + b + "\r\n" + c + "\r\n" + d + "\r\n" + f + "\r\n" + g + h);

        //        file.WriteLine("// RTC-X [bit] RTC-Y[bit] REAL-X[mm] REAL-Y[mm]" + "\r\n");

        //        int LV = (int)Length.Value; //length
        //        int MV = (int)Matrix.Value; //matrix
        //        int NC = (int)NewCal.Value; //Newcal

        //        Initial_Value(); //判斷輸入格中是否為0             

        //        //float OXV = (float) OffsetX.Value;
        //        //float OYV = (float)OffsetY.Value;
        //        float OYV = (float)OffsetX.Value;
        //        float OXV = (float)OffsetY.Value;
        //        float EXY = (float)ExpandX.Value;
        //        float EYY = (float)ExpandY.Value;                
        //        float RotationAngle = (float)Rotation_angle.Value;

        //        for (I = 0; I < M; I++)
        //        {
        //            for (J = 0; J < M; J++)
        //            {
        //                //輸出所有點
        //                file.WriteLine((CountRotation.CorXY(LV, MV, NC, I, J)) //RTC_XY
        //                    + "    " + (CountRotation.CorRXY_Rotation(LV, MV, I, J, RotationAngle))); //Real_XY
        //            }
        //        }
        //    }


        //    Process.Start(@L + "\\" + Nn + ".dat"); //開啟.dat檔

        //    sw.Stop();//碼錶停止

        //    string result1 = sw.Elapsed.Milliseconds.ToString();

        //    toolstrip1.Text = "TimeSpan: " + result1 + " ms";//印出所花費的總豪秒數 
        //}

        private void Matrix_ValueChanged(object sender, EventArgs e)
        {
            Matrix2.Value = Matrix.Value;

            if (Matrix.Value % 2 == 0)
            {
                MessageBox.Show("矩陣數建議為奇數");
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

        private void Correxion_btn_Click(object sender, EventArgs e)
        {
            string waytocorrexion = Directory.GetCurrentDirectory();
            
            Process.Start(@waytocorrexion+"\\"+ "ScannerCalibration v1"+"\\" + "correxion5"+"\\"+"correXionPro.exe");
        }
        
    }
}
