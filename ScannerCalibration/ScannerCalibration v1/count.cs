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
        int Distance;
        int HalfD;
        int i,j;
        

        public int cc()
        {
            return 1;
        }
        //振鏡坐標
        public string CorXY ( int Length,  int Matrix, int NewCal, int a, int b)
        {
            int m = Matrix;

            string[,] ArrayX = new string[m,m];
            string[,] ArrayY = new string[m,m];
            string[,] ArrayXY = new string[m,m];
            
            Distance = Length / (Matrix-1);
            HalfD = Length / 2;

            for (i=0; i<Matrix; i++)
            {
                for (j = 0; j< Matrix; j++)
                {
                    ArrayX[i,j] = Convert.ToString((HalfD-(i*Distance))*NewCal);
                    ArrayY[i,j] = Convert.ToString((HalfD-(j*Distance))*NewCal);
                    ArrayXY[i, j] = ArrayX[i, j] + "  " + ArrayY[i,j];                   
                }                    
            }

            return ArrayXY[a,b];
                         
        }

        //實際座標+Offset+Expand+Shift
        public string CorRXY(int Length, int Matrix, float OffsetX, float OffsetY, float ExpandX, float ExpandY, 
            float ShiftX, float shiftY, int a, int b)
        {
            int m = Matrix;
            float cx, cy, sx,sy,d;

            d = (Matrix-1) / 2; //半邊的點數            

            //建立存取矩陣
            float RX, RY;

            string[,] ArrayRX = new string[m, m];
            string[,] ArrayRY = new string[m, m];
            string[,] ArrayRXY = new string[m, m];                              
                                    
            Distance = Length / (Matrix-1); //相鄰點間距
            HalfD = Length / 2; //半邊長

            for (i = 0; i < Matrix; i++)
            {
                for (j = 0; j < Matrix; j++)
                {
                    cx = ExpandX - (i * ExpandX / d); //每個點的擴/縮量
                    cy = ExpandY - (j * ExpandY / d);

                    sx = Math.Abs(ShiftX - (i * ShiftX / d));
                    sy = Math.Abs(shiftY - (j * shiftY / d));

                    RX = (HalfD - (i * Distance) + OffsetX + cx + sx);
                    RY = (HalfD - (j * Distance) - OffsetY + cy + sy);                   
                                        
                    ArrayRX[i, j] = Convert.ToString(RX);
                    ArrayRY[i, j] = Convert.ToString(RY);                    
                    ArrayRXY[i, j] = ArrayRX[i, j] + "  " + ArrayRY[i, j];                                        
                }
            }           
                        
            return ArrayRXY[a, b];
        }

        public string CorRXY_Rotation (int Length, int Matrix, int a, int b, float RotatedAngle)
        {
            int m = Matrix;
            float d;

            d = (Matrix - 1) / 2; //半邊的點數            

            //建立存取矩陣
            float RX, RY;
            int n = 0;
            string[,] ArrayRX = new string[m, m];
            string[,] ArrayRY = new string[m, m];
            string[,] ArrayRXY = new string[m, m];
            
            PointF[] PointArray = new PointF[m * m];
            
            //建立旋轉矩陣
            Matrix mymatrix = new Matrix();
            mymatrix.Rotate(RotatedAngle*-1); //以原點旋轉
            mymatrix.TransformPoints(PointArray); //對點陣列進行旋轉theta角
            
            Distance = Length / (Matrix - 1); //相鄰點間距
            HalfD = Length / 2; //半邊長

            for (i = 0; i < Matrix; i++)
            {
                for (j = 0; j < Matrix; j++)
                {                    
                    RX = HalfD - (i * Distance);
                    RY = HalfD - (j * Distance);
                    
                    PointArray[n] = new PointF(RX, RY);

                    n++;
                }                
            }

            //點矩陣旋轉
            mymatrix.TransformPoints(PointArray);
            
            n = 0;

            for (i = 0; i < Matrix; i++)
            {
                for (j = 0; j < Matrix; j++)
                {                   
                    ArrayRX[i, j] = Convert.ToString(PointArray[n].X);
                    ArrayRY[i, j] = Convert.ToString(PointArray[n].Y);

                    ArrayRXY[i, j] = ArrayRX[i, j] + "  " + ArrayRY[i, j];

                    n++;
                }
            }

            return ArrayRXY[a, b];
        }


    }
}
