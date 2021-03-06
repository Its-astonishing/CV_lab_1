﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CV_lab_1
{
    class TisnenieFilter : IFilter
    {
        int [,] kernel = new int[,] { { 0, 1, 0 }, { 1, 0, -1 }, { 0, -1, 0 } };
        protected override Color getNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int radiusX = kernel.GetLength(0) / 2;
            int radiusY = kernel.GetLength(1) / 2;
            float resultR = 0;
            float resultG = 0;
            float resultB = 0;
            for (int l = -radiusY; l <= radiusY; l++)
                for (int k = -radiusX; k <= radiusX; k++)
                {
                    int idx = clamp(x + k, 0, sourceImage.Width - 1);
                    int idy = clamp(y + l, 0, sourceImage.Height - 1);
                    Color neighborColor = sourceImage.GetPixel(idx, idy);
                    resultR += neighborColor.R * kernel[k + radiusX, l + radiusY];
                    resultG += neighborColor.G * kernel[k + radiusX, l + radiusY];
                    resultB += neighborColor.B * kernel[k + radiusX, l + radiusY];
                }
            resultR += 255;
            resultG += 255;
            resultB += 255;

            resultR /= 2.0f;
            resultG /= 2.0f;
            resultB /= 2.0f;

            return Color.FromArgb(clamp((int)resultR, 0, 255),
                                  clamp((int)resultG, 0, 255),
                                  clamp((int)resultB, 0, 255));
        }
    }
}
