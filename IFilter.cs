using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.ComponentModel;

namespace CV_lab_1
{
    abstract class IFilter
    {
        protected abstract Color getNewPixelColor(Bitmap sourceImage, int x, int y);

        public Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);

            for (int i = 0; i < sourceImage.Width; i++)
            {
                worker.ReportProgress((int)((float)i / sourceImage.Width * 100));

                if (worker.CancellationPending)
                    return null;

                for (int j = 0; j < sourceImage.Height; j++)
                {
                    resultImage.SetPixel(i, j, getNewPixelColor(sourceImage, i, j));
                }
            }

            return resultImage;
        }

        public int clamp(int value, int max, int min)
        {
            if (value < min)
                return min;
            else
                if (value > max)
                    return max;
                else
                    return value;
        }
    }
}
