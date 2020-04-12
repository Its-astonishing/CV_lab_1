using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CV_lab_1
{
    class MedianFilter : IFilter
    {
        private float[] arrayR = null;
        private float[] arrayG = null;
        private float[] arrayB = null;
        public MedianFilter()
        {
            arrayR = new float[9];
            arrayG = new float[9];
            arrayB = new float[9];
        }
        protected override Color getNewPixelColor(Bitmap sourseImage, int x, int y)
        {
            int count = 0;
            for (int l = -1; l <= 1; l++)
                for (int k = -1; k <= 1; k++, count++)
                {
                    int idX = clamp(x + k, 0, sourseImage.Width - 1); // номерация с нуля, контроль границ
                    int idY = clamp(y + l, 0, sourseImage.Height - 1); // номерация с нуля, контроль границ
                    Color neighborColor = sourseImage.GetPixel(idX, idY);
                    arrayR[count] = neighborColor.R;
                    arrayG[count] = neighborColor.G;
                    arrayB[count] = neighborColor.B;
                }
            Array.Sort(arrayR); Array.Sort(arrayG); Array.Sort(arrayB);
            return Color.FromArgb(clamp((int)arrayR[4], 0, 255), clamp((int)arrayG[4], 0, 255), clamp((int)arrayB[4], 0, 255));
        }
    }
}
