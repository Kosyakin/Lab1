using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class ContrastFilter:Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int k = 30;
            Color sourceColor = sourceImage.GetPixel(x, y);
            int R = Convert.ToInt32(sourceColor.R * 2);
            int G = Convert.ToInt32(sourceColor.G * 2);
            int B = Convert.ToInt32(sourceColor.B * 2);
            Color resultColor = Color.FromArgb(Clamp((int)(R), 0, 255), Clamp((int)(G), 0, 255), Clamp((int)(B), 0, 255));

            
            return resultColor;
        }
    }
}
