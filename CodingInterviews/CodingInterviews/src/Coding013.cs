using System;
using System.Collections.Generic;
using System.Text;

namespace CodingInterviews
{
    /// <summary>
    /// 代码的完整性:调整数组顺序使奇数位于偶数前面
    /// 输入一个整数数组，实现一个函数来调整该数组中数字的顺序，使得所有的奇数位于数组的前半部分，
    /// 所有的偶数位于数组的后半部分，并保证奇数和奇数，偶数和偶数之间的相对位置不变。
    /// </summary>
    public class Coding013
    {
        public static int[] HandleArray(int[] array) {
            if (array == null) return null;
            int[] temp = new int[array.Length];
            int i = 0;
            //奇数
            foreach (var t in array) {
                if (t % 2 == 1) {
                    temp[i] = t;
                    i++;
                }
            }
            //偶数
            foreach (var t in array)
            {
                if (t % 2 == 0)
                {
                    temp[i] = t;
                    i++;
                }
            }
            return temp;
        }

        /// <summary>
        /// 不考略相对位置的
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static int[] HandleArray2(int[] array)
        {
            if (array == null) return null;

            int left = 0;
            int right = array.Length - 1;
            while (left < right)
            {
                //奇数
                while (array[left] % 2 == 1)
                {
                    left++;
                }

                //偶数
                while (left < right && array[right] % 2 == 0)
                {
                    right--;
                }

                //交换
                if (left < right)
                {
                    var temp = array[left];
                    array[left] = array[right];
                    array[right] = temp;
                }

            }
            return array;
        }

    }
}
