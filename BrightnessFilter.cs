using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CV_lab_1
{
    class BrightnessFilter : IFilter
    {
        protected int constant = 0;

        public BrightnessFilter(int _c)
        {
            constant = _c;
        }

        public BrightnessFilter()
        {
            constant = 0;
        }
            
        protected override Color getNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int R = sourceImage.GetPixel(x, y).R;
            int G = sourceImage.GetPixel(x, y).G;
            int B = sourceImage.GetPixel(x, y).B;

            R += constant;
            G += constant;
            B += constant;

            R = clamp(R, 0, 255);
            G = clamp(G, 0, 255);
            B = clamp(B, 0, 255);

            return Color.FromArgb(R, G, B);
        }
    }
}
