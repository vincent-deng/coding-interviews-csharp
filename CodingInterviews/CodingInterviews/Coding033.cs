using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodingInterviews
{
    public class Coding033
    {
        public static string PrintMinNumber(int[] numbers)
        {
            string result = "";
            ///将整数转换成字符串
            List<string> strNum = numbers.Select(x => x.ToString()).ToList();
            strNum.Sort();
            strNum.ForEach(x => result = result + x);
            return result;
        }
    }
}
