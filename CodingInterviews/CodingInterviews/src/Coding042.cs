using System;
using System.Collections.Generic;
using System.Text;

namespace CodingInterviews
{
    class Coding042
    {
        public static List<string> FindContinuousSequence(int sum)
        {
            List<string> list = new List<string>();
            int begin = 1;
            int end = 2;
            int mid = (sum + 1) >> 1;
            int curSum = begin + end;

            while (begin < end && end <= mid)
            {
                if (curSum == sum)
                {
                    list.Add($"{begin} - {end}");
                }

                if (curSum > sum) //当前值大于sum，缩小范围
                {
                    curSum -= begin;
                    begin++;
                }
                else //前值小于sum，增大范围
                {

                    end++;
                    curSum += end;
                }

            }
            return list;
        }
    }
}
