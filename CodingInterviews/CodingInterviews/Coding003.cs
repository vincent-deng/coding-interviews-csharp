using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodingInterviews
{
    /// <summary>
    /// 链表:从尾到头打印链表
    /// 输入一个链表，按链表值从尾到头的顺序返回一个ArrayList。
    /// 
    /// 解题思路：
    /// 输入一个链表，从尾到头输出，正常的遍历都是从头到尾输出，而这里需要从尾到头输出，那么就是“先进后出”，也就是栈的功能。
    /// </summary>
    public class Coding003
    {
        /// <summary>
        /// 栈的方式实现
        /// </summary>
        /// <param name="nodes"></param>
        /// <returns></returns>
        public static List<int> PrintForStack(ListNode nodes)
        {
            Stack<ListNode> listNodes = new Stack<ListNode>();
            ListNode node = nodes;
            while (node != null)
            {
                listNodes.Push(node);
                node = node.next;
            }

            List<int> list = new List<int>();
            foreach (var item in listNodes) {
                list.Add(item.item);
            }
            return list;
        }

        /// <summary>
        /// 递归的方式实现
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public static List<int> PrintForRecursion(ListNode node) {
            List<int> listNodes = new List<int>();
            PrintForRecursion(node, listNodes);
            return listNodes;
        }

        private static void PrintForRecursion(ListNode node, List<int> list)
        {
            if (node != null) {
                if (node.next != null) {
                    PrintForRecursion(node.next, list);
                }
                list.Add(node.item);
            }
        }

        /// <summary>
        /// 栈的方式实现(倒过来的链表)
        /// </summary>
        /// <param name="nodes"></param>
        /// <returns></returns>
        public static ListNode PrintForReverse(ListNode nodes)
        {
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
    }
}
