using System;
using System.Collections.Generic;
using System.Text;

namespace CodingInterviews
{
    /// <summary>
    /// 递归和循环:变态跳台阶
    /// 一只青蛙一次可以跳上1级台阶，也可以跳上2级……它也可以跳上n级。求该青蛙跳上一个n级的台阶总共有多少种跳法。
    /// </summary>
    public class Coding009
    {
        /// <summary>
        /// 变态跳台阶
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int Jump(int n) {
            if (n <= 1) {
                return n;
            }

            int first = 1;
            int result = 0;
            for (int i = 2; i <= n; i++) {
                result = 2 * first;
                first = result;
            }

            return result;
        }

    }
}
