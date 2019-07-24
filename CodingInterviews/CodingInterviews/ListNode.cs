using System;
using System.Collections.Generic;
using System.Text;

namespace CodingInterviews
{
    /// <summary>
    /// 链表
    /// </summary>
    public class ListNode
    {
        public int item;
        public ListNode next;
        public ListNode random;
        public ListNode(int x)
        {
            item = x;
        }

        /// <summary>
        /// 生成链表
        /// </summary>
        /// <param name="length"></param>
        public static ListNode CreateNodeList(int length)
        {
            ListNode listNode = new ListNode(0);
            var temp = listNode;
            for (int i = 1; i < length; i++)
            {
                temp = nextList(temp, i);
            }

            return listNode;

            //下一个
            ListNode nextList(ListNode node, int value)
            {
                while (node.next != null)
                {
                    node = node.next;
                }
                var next = new ListNode(value);
                node.next = next;
                return next;
            }
        }

        /// <summary>
        /// 获取链表的值
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public static string GetListString(ListNode head)
        {
            if (head == null)
            {
                return null;
            }

            StringBuilder sbList = new StringBuilder();
            while (head != null)
            {
                sbList.Append(head.item.ToString());
                head = head.next;
            }

            return sbList.ToString();
        }

        /// <summary>
        /// 获取链表的值
        /// </summary>
        /// <returns></returns>
        public string GetListString() {
            return GetListString(this);
        }
    }
}
