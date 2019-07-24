using System;
using System.Collections.Generic;
using System.Text;

namespace CodingInterviews
{
    /// <summary>
    /// 代码的鲁棒性:反转链表
    /// 输入一个链表，反转链表后，输出新链表的表头。
    /// 
    /// 解题思路：
    /// 定义3个指针，分别指向当前遍历到的结点、它的前一个结点及后一个结点。
    /// 在遍历过程中，首先记录当前节点的后一个节点，然后将当前节点的后一个节点指向前一个节点，其次前一个节点再指向当前节点，
    /// 最后再将当前节点指向最初记录的后一个节点，如此反复，直到当前节点的后一个节点为NULL时，则代表当前节点时反转后的头结点了。
    /// </summary>
    public class Coding015
    {
        /// <summary>
        /// 栈的方式实现(倒过来的链表)
        /// </summary>
        /// <param name="nodes"></param>
        /// <returns></returns>
        public static ListNode PrintForReverse(ListNode nodes)
        {
            if (nodes == null) return null; 
            Stack<ListNode> listNodes = new Stack<ListNode>();
            ListNode node = nodes;
            while (node != null)
            {
                listNodes.Push(node);
                node = node.next;
            }

            ListNode reverseNode = listNodes.Pop();
            var temp = reverseNode;
            foreach (var item in listNodes)
            {
                item.next = null;
                temp.next = item;
                temp = item;
            }
            return reverseNode;
        }

        public static ListNode PrintForReverse2(ListNode nodes) {
            ListNode prev = null, node = nodes, next = null;
            while (node != null)
            {
                next = node.next; //保存其下一个节点,相当于临时变量
                node.next = prev; //指针指向反转

                //后移下一轮操作
                prev = node; //保存前一个指针
                node = next; //递增指针, 指向下一个结点
            }

            return prev; //最后prev指针指向的那个节点就是原来的未指针，新的头指针
        }

    }
}
