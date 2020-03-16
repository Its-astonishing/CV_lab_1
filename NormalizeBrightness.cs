using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CV_lab_1
{
    class NormalizeBrightness : IFilter
    {
        protected override Color getNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);

            if (!indexes_calculated)
            {

                minIndexRed = getMinIndex(sourceImage, (Color color) => { return color.R; });
                minIndexGreen = getMinIndex(sourceImage, (Color color) => { return color.G; });
                minIndexBlue = getMinIndex(sourceImage, (Color color) => { return color.B; });

                maxIndexRed = getMaxIndex(sourceImage, (Color color) => { return color.R; });
                maxIndexGreen = getMaxIndex(sourceImage, (Color color) => { return color.G; });
                maxIndexBlue = getMaxIndex(sourceImage, (Color color) => { return color.B; });

                indexes_calculated = true;
            }

            int red = sourceColor.R;
            int green = sourceColor.G;
            int blue = sourceColor.B;

            int resultRed = clamp((int)((0xff * (double)(red - minIndexRed)) / (double)(clamp(maxIndexRed - minIndexRed, 1, 0xff))), 0, 0xff);
            int resultGreen = clamp((int)((0xff * (double)(green - minIndexGreen)) / (double)(clamp(maxIndexGreen - minIndexGreen, 1, 0xff))), 0, 0xff);
            int resultBlue = clamp((int)((0xff * (double)(blue - minIndexBlue)) / (double)(clamp(maxIndexBlue - minIndexBlue, 1, 0xff))), 0, 0xff);

            return Color.FromArgb(resultRed, resultGreen, resultBlue);

        }

        delegate int getColor(Color color);

        private int getMinIndex(Bitmap sourceImage, getColor func)
        {
            int min_index = 0;

            for (int i = 0; i < sourceImage.Width; i++)
            {
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    Color currentColor = sourceImage.GetPixel(i, j);

                    int value = func(currentColor);

                    if (0 != value)
                    {
                        min_index = j + i * sourceImage.Width;
                        return min_index;
                    }
                }
            }

            return min_index;
        }
        private int getMaxIndex(Bitmap sourceImage, getColor func)
        {
            int max_index = 0;

            for (int i = sourceImage.Width - 1; i > 0; i--)
            {
                for (int j = sourceImage.Height - 1; j > 0; j--)
                {
                    Color currentColor = sourceImage.GetPixel(i, j);
                    int value = func(currentColor);

                    if (0 != value)
                    {
                        max_index = j + i * sourceImage.Width;
                        return max_index;
                    }
                }
            }

            return max_index;
        }

        int minIndexRed;
        int minIndexGreen;
        int minIndexBlue;

        int maxIndexRed;
        int maxIndexGreen;
        int maxIndexBlue;

        bool indexes_calculated = false;
    }
}
