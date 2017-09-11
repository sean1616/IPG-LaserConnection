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
        int i, j, n, Distance, Half_Distance;        
        float expand_x, expand_y, half_point, Real_X, Real_Y;
        Matrix mymatrix = new Matrix();

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
            Half_Distance = Length / 2;

            for (i=0; i<Matrix; i++)
            {
                for (j = 0; j< Matrix; j++)
                {
                    ArrayX[i,j] = Convert.ToString((Half_Distance-(i*Distance))*NewCal);
                    ArrayY[i,j] = Convert.ToString((Half_Distance-(j*Distance))*NewCal);
                    ArrayXY[i, j] = ArrayX[i, j] + "  " + ArrayY[i,j];                   
                }                    
            }

            return ArrayXY[a,b];
                         
        }
        
        //實際座標+Offset+Expand+Shift
        public string CorRealXY(int Length, int Matrix, float OffsetX, float OffsetY, float ExpandX, float ExpandY, 
            int I, int J, float RotatedAngle, float Final_Rotation)
        {
            n = 0;           
            
            half_point = (Matrix-1) / 2; //半邊的點數            

            //建立存取矩陣
            string[,] ArrayRX = new string[Matrix, Matrix];
            string[,] ArrayRY = new string[Matrix, Matrix];
            string[,] ArrayRXY = new string[Matrix, Matrix];

            #region 旋轉計算
            //點陣列
            PointF[] PointArray = new PointF[Matrix * Matrix];

            //建立旋轉矩陣
            Matrix Rotation_matrix = new Matrix();
            Matrix Final_Rotation_matrix = new Matrix();
            Rotation_matrix.Rotate(RotatedAngle * -1); //以原點旋轉    
            Final_Rotation_matrix.Rotate(Final_Rotation * -1);
            //mymatrix.TransformPoints(PointArray);//對點陣列預先旋轉theta角(依振鏡擺放方向)

            //填入點至點陣列
            for (i = 0; i < Matrix; i++)
            {
                for (j = 0; j < Matrix; j++)
                {
                    Real_X = Half_Distance - (i * Distance);
                    Real_Y = Half_Distance - (j * Distance);

                    PointArray[n] = new PointF(Real_X, Real_Y);

                    n++;
                }
            }

            //對點陣列進行旋轉theta角
            Rotation_matrix.TransformPoints(PointArray);

            n = 0;

            //轉換格式(point to string)
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
            #endregion


            #region 位移計算
            Distance = Length / (Matrix - 1); //相鄰點間距
            Half_Distance = Length / 2; //半邊長
            n = 0;

            for (i = 0; i < Matrix; i++)
            {
                for (j = 0; j < Matrix; j++)
                {
                    expand_x = ExpandX - (i * ExpandX / half_point); //點的擴/縮量
                    expand_y = ExpandY - (j * ExpandY / half_point);

                    //Real_X = (Half_Distance - (i * Distance) + OffsetX + expand_x);
                    //Real_Y = (Half_Distance - (j * Distance) - OffsetY + expand_y);

                    //點的總位移量
                    Real_X = (PointArray[n].X + (i * Distance) - OffsetX + expand_x); 
                    Real_Y = (PointArray[n].Y + (j * Distance) - OffsetY + expand_y); 

                    //ArrayRX[i, j] = Convert.ToString(Real_X);
                    //ArrayRY[i, j] = Convert.ToString(Real_Y);
                    //ArrayRXY[i, j] = ArrayRX[i, j] + "  " + ArrayRY[i, j];

                    n++;
                }
            }
            #endregion

            //填入點至點陣列
            n = 0;
            for (i = 0; i < Matrix; i++)
            {
                for (j = 0; j < Matrix; j++)
                {            
                    PointArray[n] = new PointF(Real_X, Real_Y);
                    n++;
                }
            }
            Final_Rotation_matrix.TransformPoints(PointArray);

            n = 0;

            for (i = 0; i < Matrix; i++)
            {
                for (j = 0; j < Matrix; j++)
                {
                   
                    //Real_X = (Half_Distance - (i * Distance) + OffsetX + expand_x);
                    //Real_Y = (Half_Distance - (j * Distance) - OffsetY + expand_y);

                    //點的總位移量
                    Real_X = PointArray[n].X;
                    Real_Y = PointArray[n].Y;

                    ArrayRX[i, j] = Convert.ToString(Real_X);
                    ArrayRY[i, j] = Convert.ToString(Real_Y);
                    ArrayRXY[i, j] = ArrayRX[i, j] + "  " + ArrayRY[i, j];

                    n++;
                }
            }

            return ArrayRXY[I, J];
        }

        //旋轉座標
        public string CorRXY_Rotation (int Length, int Matrix, int a, int b, float RotatedAngle)
        {
            int m = Matrix;
            float d;

            d = (Matrix - 1) / 2; //半邊的點數            

            //建立存取矩陣
            float RX, RY;
            int n = 0;
            string[,] ArrayRX = new string[Matrix, Matrix];
            string[,] ArrayRY = new string[Matrix, Matrix];
            string[,] ArrayRXY = new string[Matrix, Matrix];
            
            //點陣列
            PointF[] PointArray = new PointF[Matrix * Matrix];
            
            //建立旋轉矩陣
            Matrix mymatrix = new Matrix();
            mymatrix.Rotate(RotatedAngle*-1); //以原點旋轉
            //mymatrix.TransformPoints(PointArray); //對點陣列進行旋轉theta角
            
            Distance = Length / (Matrix - 1); //相鄰點間距
            Half_Distance = Length / 2; //半邊長

            //填入點至點陣列
            for (i = 0; i < Matrix; i++)
            {
                for (j = 0; j < Matrix; j++)
                {                    
                    RX = Half_Distance - (i * Distance);
                    RY = Half_Distance - (j * Distance);
                    
                    PointArray[n] = new PointF(RX, RY);

                    n++;
                }                
            }

            //對點陣列進行旋轉theta角
            mymatrix.TransformPoints(PointArray);
            
            n = 0;

            //轉換格式
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
