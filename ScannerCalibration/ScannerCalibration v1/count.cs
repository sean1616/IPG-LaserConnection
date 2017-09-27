using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;


namespace ScannerCalibration
{
    class count
    {
        int i, j, n, Half_Distance, matrix;
        float expand_x, expand_y, half_point, Distance;
        decimal Real_X, Real_Y;       
        string arrary_rtc5, array_rtc5_x, array_rtc5_y;
        Matrix Rotation_matrix, Offset_Rotation_matrix;
        PointF[] PointArray;                

        public count(int Length, int Matrix)
        {
            //建立理想點位陣列
            matrix = Matrix;
            half_point = (Matrix - 1) / 2; //半邊的點數
            decimal Distance = Math.Round((decimal)Length / (Matrix - 1), 6); //相鄰點間距(注意小數問題)
            decimal Half_Distance = Length / 2; //半邊長

            //點陣列(計算/顯示用)
            PointArray = new PointF[matrix * matrix];            
            
            //填入理想點至點陣列
            for (i = 0; i < Matrix; i++)
            {
                for (j = 0; j < Matrix; j++)
                {
                    Real_X = Half_Distance - (i * Distance);
                    Real_Y = Half_Distance - (j * Distance);

                    PointArray[n] = new PointF(Convert.ToSingle(Real_X), Convert.ToSingle(Real_Y));

                    n++;
                }
            }
        }

        //振鏡坐標 (RTC5)
        public string CorXY(int NewCal, int n)
        {               
            array_rtc5_x = Math.Round(PointArray[n].X * NewCal).ToString();
            array_rtc5_y = Math.Round(PointArray[n].Y * NewCal).ToString();
            arrary_rtc5 = array_rtc5_x + "   " + array_rtc5_y;

            return arrary_rtc5;
        }

        public string Cor_Real_XY(float OffsetX, float OffsetY, float ExpandX, float ExpandY,
            float RotatedAngle, float Offset_Rotation, int n)
        {
            //理想量測值
            string array_rtc5_x = Math.Round(PointArray[n].X,4).ToString();
            string array_rtc5_y = Math.Round(PointArray[n].Y,4).ToString();


            //建立旋轉矩陣
            Rotation_matrix = new Matrix();
            Rotation_matrix.Rotate(RotatedAngle * -1); //以原點旋轉 (RotatedAngle) degree

            Offset_Rotation_matrix = new Matrix();
            Offset_Rotation_matrix.Rotate(Offset_Rotation);

            //量測點陣列旋轉theta角
            Rotation_matrix.TransformPoints(PointArray);

            //點的擴張/收縮量
            expand_x = ExpandX - (i * ExpandX / half_point); 
            expand_y = ExpandY - (j * ExpandY / half_point);

            //旋轉平移量 for不同振鏡擺放方式
            PointF[] offset = new PointF[1];
            offset[0].X = OffsetX;
            offset[0].Y = OffsetY;
            Offset_Rotation_matrix.TransformPoints(offset);

            //點的總平移量
            float x_movement = expand_x - offset[0].X;
            float y_movement = expand_y - offset[0].Y;

            string real_x = Math.Round(PointArray[n].X + x_movement, 4).ToString();
            string real_y = Math.Round(PointArray[n].Y + y_movement, 4).ToString(); //位移完
        
            string arrary_rtc5 = real_x + "   " + real_y;
            
            return arrary_rtc5;
        }                
    }
}
