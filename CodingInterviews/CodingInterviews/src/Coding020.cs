using System;
using System.Collections.Generic;
using System.Text;

namespace CodingInterviews
{
    /// <summary>
    /// 举例让抽象具体化:包含min函数的栈
    /// 定义栈的数据结构，请在该类型中实现一个能够得到栈中所含最小元素的min函数（时间复杂度应为O（1））。
    /// 
    /// 解题思路：维持两个栈，一个保存数据，一个保存最小值
    /// </summary>
    public class Coding020
    {

    }

    /// <summary>
    /// min函数栈
    /// </summary>
    public class MinInStack
    {
        public Stack<int> dataStack;
        public Stack<int> minStack;

        public MinInStack()
        {
            dataStack = new Stack<int>();
            minStack = new Stack<int>();
        }

        public int Pop()
        {
            if (dataStack.Count == 0) return -1;
            minStack.Pop();
            return dataStack.Pop();
        }

        public void Push(int item)
        {
            dataStack.Push(item);
            if (!minStack.TryPeek(out int data) || data > item) //每次放进去的都是最小值
            {
                minStack.Push(item);
            }
            else
            {
                minStack.Push(data);
            }
        }

        public int Min()
        {
            if (dataStack.Count == 0) return -1;

            return minStack.Peek();
        }
    }
}
