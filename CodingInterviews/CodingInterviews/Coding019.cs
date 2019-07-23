using System;
using System.Collections.Generic;
using System.Text;

namespace CodingInterviews
{
    /// <summary>
    /// 画图让抽象形象化:顺时针打印矩阵
    ///  1 2 3 4 
    ///  5 6 7 8 
    ///  9 10 11 12 
    ///  13 14 15 16
    ///  则依次打印出数字:1,2,3,4,8,12,16,15,14,13,9,5,6,7,11,10
    ///  解题思路：
    ///  从左到右，left 《= right
    ///  从上到下，终止行要大于起始行，bottom 》 top
    ///  从右到左，至少要有两行两列才会有第三步，right 》 left && bottom 》 top
    ///  从下到上，至少要有三行两列才会执行第四步，right》left && bottom-1 》 top
    ///  依次进行此操作,每次数据都在减少
    ///  
    /// </summary>
    public class Coding019
    {
        public static List<int> HandleArray(int[,] array)
        {
            List<int> data = new List<int>();
            if (array == null) return data;
            int row = array.GetLength(0);
            int col = array.GetLength(1);
            if (row == 0 || col == 0) return data;
            int left = 0, right = col - 1, top = 0, bottom = row - 1;
            while (left <= right && bottom >= top)
            {
                //从左到右
                for (int i = left; i <= right; i++)
                {
                    data.Add(array[top, i]); //行不变列变
                }
                top++;

                //从上到下
                if (bottom >= top)
                {
                    for (int i = top; i <= bottom; i++)
                    {
                        data.Add(array[i, right]); //行变列不变
                    }
                    right--;
                }

                //从右到左
                if (right >= left && bottom >= top)
                {
                    for (int i = right; i >= left; i--)
                    {
                        data.Add(array[bottom, i]); //列变行不变
                    }
                    bottom--;
                }

                //从下到上
                if (right >= left && bottom >= top)
                {
                    for (int i = bottom; i >= top; i--)
                    {
                        data.Add(array[i, left]);//行变列不变
                    }
                    left++;
                }
            }

            return data;
        }
    }
}
