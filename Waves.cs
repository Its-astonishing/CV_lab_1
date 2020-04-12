using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CV_lab_1
{
    class Waves1 : IFilter
    {
        protected override Color getNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int new_x = (int)(x + (20 * Math.Sin(2 * Math.PI * y / 60)));
            int new_y = y;

            if (new_x < 0 || sourceImage.Width <= new_x)
            {
                return Color.FromArgb(0, 0, 0);
            }

            return sourceImage.GetPixel(new_x, new_y);
        }
    }

    class Waves2 : IFilter
    {
        protected override Color getNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int new_x = (int)(x + (20 * Math.Sin(2 * Math.PI * y / 30)));
            int new_y = y;

            if (new_x < 0 || sourceImage.Width <= new_x)
            {
                return Color.FromArgb(0, 0, 0);
            }

            return sourceImage.GetPixel(new_x, new_y);
        }
    }
}
