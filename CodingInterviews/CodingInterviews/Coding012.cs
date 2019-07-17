using System;
using System.Collections.Generic;
using System.Text;

namespace CodingInterviews
{
    /// <summary>
    /// 代码的完整性:数值的整数次方
    /// 给定一个double类型的浮点数base和int类型的整数exponent。求base的exponent次方。
    /// </summary>
    public class Coding012
    {
        public static double Pow(double baseData, int exponent)
        {
            if (baseData == 0)
            {
                return 0;
            }

            bool isPositive = exponent > 0;//是否是正数
            exponent = isPositive ? exponent : -exponent;
            double result = 1;
            for (int i = 0; i < exponent; i++)
            {
                result = result * baseData;
            }
            result = isPositive ? result : (1 / result);
            return result;
        }

    }
}
