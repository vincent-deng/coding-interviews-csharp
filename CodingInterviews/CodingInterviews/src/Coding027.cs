using System;
using System.Collections.Generic;
using System.Text;

namespace CodingInterviews
{
    /// <summary>
    /// 字符串的排列
    /// </summary>
    public class Coding027
    {
        public static List<string> Permutation(string str)
        {
            if (str == null)
            {
                return null;
            }

            var c = str.ToCharArray();
            List<string> data = new List<string>();
            Permutation(c, c, 0, data);
            return data;
        }

        public static void Permutation(char[] str, char[] begin, int startIndex, List<string> data)
        {
            if (startIndex == str.Length)
            {
                data.Add(new string(str));
            }
            else
            {
                for (int i = startIndex; i < str.Length; i++)
                {
                    //交换
                    char temp = begin[i];
                    begin[i] = begin[startIndex];
                    begin[startIndex] = temp;

                    Permutation(str, begin, startIndex + 1, data);

                    //还原
                    temp = begin[i];
                    begin[i] = begin[startIndex];
                    begin[startIndex] = temp;
                }
            }
        }
    }
}
