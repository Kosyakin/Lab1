using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class SepiaFilter:Filters
    {

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int k = 30;
            Color sourceColor = sourceImage.GetPixel(x, y);
            int a = Convert.ToInt32(0.36 * sourceColor.R) + Convert.ToInt32(0.53 * sourceColor.G) + Convert.ToInt32(0.11 * sourceColor.B);
            Color resultColor = Color.FromArgb(Clamp((int)(a + 2 * k), 0, 255),
                Clamp((int)Convert.ToInt32(a + 0.5 * k), 0, 255),
                Clamp((int)(a - 1 * k), 0, 255));



            return resultColor;
        }
    }
}
