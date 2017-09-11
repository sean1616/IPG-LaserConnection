using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScannerCalibration_v1
{
    class Text
    {
        public string text_g(bool Chkg,int L)
        {
            string g;

            if (Chkg == true)
            {
                g = "LIMITS = "+ Convert.ToString(L) + " 		// limits the correction file to the rectangle containing the measured points (enlarged by the given value in %)" + "\r\n";
            }

            else
            {
                g = "//LIMITS = 1" + " 		// limits the correction file to the rectangle containing the measured points (enlarged by the given value in %)" + "\r\n";
            }

            return g;
        }
        
            public string text_h(bool Chkf, int P)
            {
                string h;

                if (Chkf == true)
                {
                    h = "POLYLIMITS = "+ Convert.ToString(P) + " 		// use this parameter instead of LIMITS to limit the correction file to more complex regions (enlarged by the given value in %)" + "\r\n";
                }

                else
                {
                    h = "//POLYLIMITS = 5" + " 		// use this parameter instead of LIMITS to limit the correction file to more complex regions (enlarged by the given value in %)" + "\r\n";
                }

                return h;
            }

        
    }
}
