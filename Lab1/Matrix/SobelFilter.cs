using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class SobelFilter : MatrixFilter
    {
        public SobelFilter() {
            int sizeX = 3;
            int sizeY = 3;
            int a = 0;
            int b = 0;
            kernel = new float[sizeX, sizeY];
            for (int i = 0; i < sizeX; i++)
            {
                switch (i)
                {
                    case 0:
                        a = -1;
                        break;
                    case 1:
                        a = 0;
                        break;
                    case 2:
                        a = 1;
                        break;
                }
                for (int j = 0; j < sizeY; j++)
                {
                    switch (i)
                    {
                        case 0:
                            b = 1;
                            break;
                        case 1:
                            b = 2;
                            break;
                        case 2:
                            b = 1;
                            break;
                    }
                    kernel[i, j] = b * a;
                }
            }
        }
    }
}
