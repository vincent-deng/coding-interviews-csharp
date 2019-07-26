using System;
using System.Collections.Generic;
using System.Text;

namespace CodingInterviews
{
    class Coding052
    {
        public static int[] multiply(int[] data)
        {
            int length = data.Length;
            int[] res = new int[length];
            // C[i] = A[0] * A[1] * ... *A[i - 1]=1*2*3*4*5
            for (int i = 0, temp = 1; i < length; i++)
            {
                res[i] = temp;
                temp *= data[i];
            }

            // D[i] = A[i + 1] * A[i + 2] * ... *A[n - 1]=
            for (int i = length - 1, temp = 1; i >= 0; i--)
            {
                res[i] *= temp;
                temp *= data[i];

            }
            return res;
        }
    }
}

