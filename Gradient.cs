using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CV_lab_1
{
    class Gradient : IMorphology
    {

        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            Bitmap erosionImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            Bitmap dilationImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            Erosion erosion = new Erosion();
            Dilation dilation = new Dilation();

            dilationImage = dilation.processImage(sourceImage, worker);
            erosionImage = erosion.processImage(sourceImage, worker);

            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);

            for (int i = 0; i < sourceImage.Width; i++)
            {
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    int red = dilationImage.GetPixel(i, j).R - erosionImage.GetPixel(i, j).R;
                    red = clamp(red, 0, 255);

                    int green = dilationImage.GetPixel(i, j).G - erosionImage.GetPixel(i, j).G;
                    green = clamp(green, 0, 255);

                    int blue = dilationImage.GetPixel(i, j).B - erosionImage.GetPixel(i, j).B;
                    blue = clamp(blue, 0, 255);

                    resultImage.SetPixel(i, j, Color.FromArgb(red, green, blue));
                }
            }

            return resultImage;
        }

        protected override Color getNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            return Color.FromArgb(0, 0, 0);
        }
    }
}
