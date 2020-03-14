using System.Drawing;

namespace CV_lab_1
{
    class InvertFilter : IFilter
    {
        protected override Color getNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);

            Color resultColor = Color.FromArgb(255 - sourceColor.R,
                                               255 - sourceColor.G,
                                               255 - sourceColor.B);

            return resultColor;
        }
    }
}
