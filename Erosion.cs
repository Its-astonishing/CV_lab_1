using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CV_lab_1
{
    class Erosion : IMorphology
    {
        protected override Color getNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int xCenter = IMorphology.m_x / 2;
            int yCenter = IMorphology.m_y / 2;

            if (((xCenter <= x) && (sourceImage.Width - xCenter) > x) &&
               ((yCenter <= y) && (sourceImage.Height - yCenter) > y))
            {
                return findMin(sourceImage, x, y);
            }

            return sourceImage.GetPixel(x, y);
        }
    }
}
