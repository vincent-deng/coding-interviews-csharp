using System;
using System.Collections.Generic;
using System.Text;

namespace CodingInterviews
{
    /// <summary>
    /// 位运算:二进制中1的个数
    /// 输入一个整数，输出该数二进制表示中1的个数。其中负数用补码表示。
    /// </summary>
    public class Coding011
    {
        /// <summary>
        /// 针对正整数(负数不会走)
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int SimpleNumberOf1(int n) {
            int count = 0;
            while (n > 0) { //右移的处理，
                if ((n & 1) == 1) {
                    count++;
                }
                n = n >> 1;
            }
            return count;
        }

        /// <summary>
        /// 新颖解法：
        /// 把一个整数减去1，再和原整数做与运算，会把该整数最右边一个1变成0。
        /// 那么一个整数的二进制表示中有多少个1，就可以进行多少次这样的操作。
        /// 很多二进制的处理都可以用这种方法。
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int NumberOf1(int n) {
            int count = 0;
            while (n != 0) {
                count++;
                n = (n - 1) & n;
            }
            return count;
        }

    }
}
