﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CV_lab_1
{
    class GrayScaleFilter : IFilter
    {
        protected override Color getNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            float R = sourceImage.GetPixel(x, y).R;
            float G = sourceImage.GetPixel(x, y).G;
            float B = sourceImage.GetPixel(x, y).B;
            int intensity = clamp((int)(0.299f * R + 0.587f * G + 0.144f * B), 0, 255);
     
            return Color.FromArgb(intensity, intensity, intensity);
        }
    }
}
