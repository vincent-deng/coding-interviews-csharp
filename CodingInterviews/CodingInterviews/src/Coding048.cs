using System;
using System.Collections.Generic;
using System.Text;

namespace CodingInterviews
{
    public class Coding048
    {
        public static int SumRecursion(int n)
        {
            Console.WriteLine(n);
            int sum = n;
            //当n>0为假的时候，右边将不执行
            bool ans = (n > 0) && ((sum += SumRecursion(n - 1)) > 0);
            //或者下面，短路与（&&）和短路或（||）
            //bool ans = (n <= 0) || ((sum += SumRecursion(n - 1)) > 0);
            return sum;
        }
    }
}
