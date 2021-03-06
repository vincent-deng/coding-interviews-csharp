﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CodingInterviews
{
    class Coding034
    {
        public int GetUglyNumber(int index)
        {
            if (index <= 0)
            {
                return 0;
            }

            int[] uglyNumbers = new int[index];
            uglyNumbers[0] = 1;
            int nextUglyIndex = 1;

            int multiply2 = 0;
            int multiply3 = 0;
            int multiply5 = 0;
            int min = 0;

            while (nextUglyIndex < index)
            {
                min = Min(uglyNumbers[multiply2] * 2, uglyNumbers[multiply3] * 3, uglyNumbers[multiply5] * 5);
                uglyNumbers[nextUglyIndex] = min;

                while (uglyNumbers[multiply2] * 2 <= uglyNumbers[nextUglyIndex])
                {
                    multiply2++;
                }

                while (uglyNumbers[multiply3] * 3 <= uglyNumbers[nextUglyIndex])
                {
                    multiply3++;
                }

                while (uglyNumbers[multiply5] * 5 <= uglyNumbers[nextUglyIndex])
                {
                    multiply5++;
                }

                nextUglyIndex++;
            }

            int result = uglyNumbers[index - 1];
            uglyNumbers = null;

            return result;
        }

        private int Min(int num1, int num2, int num3)
        {
            int min = num1 < num2 ? num1 : num2;
            min = min < num3 ? min : num3;

            return min;
        }
    }
}
