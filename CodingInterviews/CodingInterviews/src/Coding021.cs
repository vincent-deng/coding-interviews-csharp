using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodingInterviews
{
    /// <summary>
    /// 栈的压入、弹出序列
    /// </summary>
    public class Coding021
    {
        public static bool IsPopOrder(int[] pushOrder, int[] popOrder)
        {
            bool possible = false;
            if (pushOrder != null && popOrder != null && pushOrder.Count() == popOrder.Count())
            {
                int nextPush = 0; // 指向下一个要push的元素的index
                int nextPop = 0;  // 指向下一个要pop的元素的index
                int length = pushOrder.Count();
                Stack<int> stackData = new Stack<int>();

                while (nextPush < length)
                {
                    // 当辅助栈的栈顶元素不是要弹出的元素,先压入一些数字入栈
                    while (stackData.Count == 0 || stackData.Peek() != popOrder[nextPop])
                    {
                        // 如果所有数字都压入辅助栈了，退出循环
                        if (nextPush == (length - 1))
                        {
                            break;
                        }

                        stackData.Push(pushOrder[nextPush]);
                        nextPush++;
                    }

                    // 说明没有匹配成功
                    if (stackData.Peek() != popOrder[nextPop])
                    {
                        break;
                    }

                    stackData.Pop();
                    nextPop++;
                }

                if (stackData.Count == 0)
                {
                    possible = true;
                }
            }

            return possible;
        }
    }
}
