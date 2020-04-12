using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CV_lab_1
{
    abstract class IMorphology : IFilter
    { 
        protected int getGrayscale(Color color)
        {
            return (color.R + color.G + color.B) / 3;
        }

        protected Color findMax(Bitmap sourceImage, int x, int y)
        {
            Color max = Color.FromArgb(0, 0, 0);

            for (int i = x - IMorphology.m_x / 2; i < x + IMorphology.m_x / 2; ++i)
            {
                for (int j = y - IMorphology.m_y / 2; j < y + IMorphology.m_y / 2; ++j)
                {
                    int currentColor = getGrayscale(sourceImage.GetPixel(i, j));

                    if (currentColor > getGrayscale(max))
                    {
                        max = sourceImage.GetPixel(i, j);
                    }
                }
            }

            return max;
        }

        protected Color findMin(Bitmap sourceImage, int x, int y)
        {
            Color min = Color.FromArgb(0xff, 0xff, 0xff);

            for (int i = x - IMorphology.m_x / 2; i < x + IMorphology.m_x / 2; ++i)
            {
                for (int j = y - IMorphology.m_y / 2; j < y + IMorphology.m_y / 2; ++j)
                {
                    int currentColor = getGrayscale(sourceImage.GetPixel(i, j));

                    if (currentColor < getGrayscale(min))
                    {
                        min = sourceImage.GetPixel(i, j);
                    }
                }
            }

            return min;
        }

        public static int m_x = 3;
        public static int m_y = 3;
    }
}
