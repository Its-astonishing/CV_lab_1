using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CV_lab_1
{
    class Opening : IMorphology
    {

        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            Erosion erosion = new Erosion();
            Dilation dilation = new Dilation();

            resultImage = erosion.processImage(sourceImage, worker);
            resultImage = dilation.processImage(sourceImage, worker);

            return resultImage;
        }

        protected override Color getNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            return Color.FromArgb(0,0,0);
        }
    }
}
