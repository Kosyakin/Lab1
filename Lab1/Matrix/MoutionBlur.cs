using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class MoutionBlur:MatrixFilter
    {
        public MoutionBlur(int n) 
        {
            
            int sizeX = 3;
            int sizeY = 3;
            kernel = new float[n, n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++) {
                    if (i == j) { kernel[i, j] = (float)1/n; }
                       
                    else { kernel[i, j] = 0; } 
                }
        }
        
    }
}
