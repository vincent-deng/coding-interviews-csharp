using System;
using System.Collections.Generic;
using System.Text;

namespace CodingInterviews
{
    /// <summary>
    /// 栈和队列:用两个栈实现队列
    /// 用两个栈来实现一个队列，完成队列的Push和Pop操作。 队列中的元素为int类型。
    /// 
    /// 解题思路：
    /// 栈：先进后出，队列：先进先出。用两个【先进后出】的实现一个【先进先出】。
    /// 对于两个栈而言，插入的时候没有什么问题，直接插入就可以，出栈的时候，需要借助另外一个栈操作。
    /// 简单的来说就是负负为正。这里有个效率问题，进栈的第一个数据不用pop到出栈中直接返回就可以了。
    /// </summary>
    public class Coding005
    {
        /// <summary>
        /// 出栈
        /// </summary>
        private Stack<int> dequeue;
        /// <summary>
        /// 进栈
        /// </summary>
        private Stack<int> enqueue;

        public Coding005()
        {
            dequeue = new Stack<int>();
            enqueue = new Stack<int>();
        }
        /// <summary>
        /// 出栈（优化）
        /// </summary>
        /// <returns></returns>
        public int Dequeue2()
        {
            //没有数据
            if (enqueue.Count == 0 && dequeue.Count == 0) {
                return -1;
            }

            while (enqueue.Count > 1) {
                var item = enqueue.Pop();
                dequeue.Push(item);
            }

            if (enqueue.Count == 1)
            {
                return enqueue.Pop();
            }
            else {
                return dequeue.Pop();
            }
        }

        /// <summary>
        /// 出栈
        /// </summary>
        /// <returns></returns>
        public int Dequeue()
        {
            //没有数据
            if (enqueue.Count == 0 && dequeue.Count == 0)
            {
                return -1;
            }

            while (enqueue.Count > 0)
            {
                var item = enqueue.Pop();
                dequeue.Push(item);
            }

            return dequeue.Pop();
        }

        /// <summary>
        /// 进栈
        /// </summary>
        /// <param name="item"></param>
        public void Enqueue(int item)
        {
            enqueue.Push(item);
        }

    }

    /// <summary>
    /// 栈和队列:用两个队列实现栈
    /// </summary>
    public class HStack
    {
        /// <summary>
        /// 出栈
        /// </summary>
        private Queue<int> pop;
        /// <summary>
        /// 进栈
        /// </summary>
        private Queue<int> push;

        public HStack()
        {
            pop = new Queue<int>();
            push = new Queue<int>();
        }

        /// <summary>
        /// 出栈
        /// </summary>
        /// <returns></returns>
        public int Pop()
        {
            //没有数据
            if (push.Count == 0 && pop.Count == 0)
            {
                return -1;
            }

            while (push.Count > 1)
            {
                var item = push.Dequeue();
                pop.Enqueue(item);
            }
            int result = push.Dequeue();

            //数据交换回去
            var temp = pop;
            pop = push;
            push = temp;

            return result;
        }

        /// <summary>
        /// 进栈
        /// </summary>
        /// <param name="item"></param>
        public void Push(int item)
        {
            push.Enqueue(item);
        }
    }
}
