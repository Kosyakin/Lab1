using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class GrayScaleFilter:Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            int a= Convert.ToInt32(0.36 * sourceColor.R)+Convert.ToInt32(0.53 * sourceColor.G) + Convert.ToInt32(0.11 * sourceColor.B);
            Color resultColor = Color.FromArgb(a,a,a);

            return resultColor;
        }
    }
}
