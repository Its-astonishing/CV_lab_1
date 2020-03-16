using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CV_lab_1
{
    class GaussianFilter : MatrixFilter
    {
        public void createGaussianKernel(int radius, float sigma)
        {
            int size = 2 * radius + 1;
            kernel = new float[size, size];
            float norm = 0; // koef normirovki
            for(int i = -radius; i<= radius; i++) 
                for(int j = -radius;j <= radius;j++)
                {
                    kernel[i + radius, j + radius] = (float)(Math.Exp(-(i * i + j * j) / (2 * sigma * sigma)));
                    norm += kernel[i + radius, j + radius];
                }

            //normirovka
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    kernel[i, j] /= norm;
        }
        public GaussianFilter()
        {
            createGaussianKernel(3, 2);
        }
        public GaussianFilter(int radius, int sigma)
        {
            createGaussianKernel(radius, sigma);
        }
    }
}
