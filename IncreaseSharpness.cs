using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CV_lab_1
{
    class IncreaseSharpness : MatrixFilter
    {
        public IncreaseSharpness()
        {
            kernel = new float[,] { { 0, -1, 0 }, { -1, 5, -1 }, { 0, -1, 0 } };
        }
    }
}
