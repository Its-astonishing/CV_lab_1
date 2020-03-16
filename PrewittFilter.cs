using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CV_lab_1
{
    class PrewittFilter : IFilter
    {
        int[,] gx = new int[,] { { -1, 0, 1 }, { -1, 0, 1 }, { -1, 0, 1 } };
        int[,] gy = new int[,] { { -1, -1, -1 }, { 0, 0, 0 }, { 1, 1, 1 } };

        protected override Color getNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int new_rx = 0, new_ry = 0;
            int new_gx = 0, new_gy = 0;
            int new_bx = 0, new_by = 0;
            int rc, gc, bc;

            for (int l = -1; l <= 1; l++)
            {
                for (int k = -1; k <= 1; k++)
                {

                    int idx = clamp(x + k, 0, sourceImage.Width - 1);
                    int idy = clamp(y + l, 0, sourceImage.Height - 1);
                    Color neighborColor = sourceImage.GetPixel(idx, idy);
                    rc = neighborColor.R;
                    new_rx += gx[k + 1, l + 1] * rc;
                    new_ry += gy[k + 1, l + 1] * rc;

                    gc = neighborColor.G;
                    new_gx += gx[k + 1, l + 1] * gc;
                    new_gy += gy[k + 1, l + 1] * gc;

                    bc = neighborColor.B;
                    new_bx += gx[k + 1, l + 1] * bc;
                    new_by += gy[k + 1, l + 1] * bc;
                }
            }
            if (new_rx * new_rx + new_ry * new_ry > 128 * 128 || new_gx * new_gx + new_gy * new_gy > 128 * 128 || new_bx * new_bx + new_by * new_by > 128 * 128)
                return Color.Black;
            else
                return Color.White;
        }
    }
}
