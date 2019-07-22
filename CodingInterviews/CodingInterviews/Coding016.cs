using System;
using System.Collections.Generic;
using System.Text;

namespace CodingInterviews
{
    /// <summary>
    /// 代码的鲁棒性:合并两个排序的链表
    /// 输入两个单调递增的链表，输出两个链表合成后的链表，当然我们需要合成后的链表满足单调不减规则。
    /// 
    /// 解题思路：
    /// 创建一个新的链表，每次比较最小的插入链表中
    /// </summary>
    public class Coding016
    {
        public static ListNode Merge(ListNode node1, ListNode node2) {
            if (node1 == null) return node2;
            if (node2 == null) return node1;
            ListNode newNode = null;

            if (node1.item <= node2.item)
            {
                newNode = node1;
                newNode.next = Merge(node1.next, node2);
            }
            else {
                newNode = node2;
                newNode.next = Merge(node1, node2.next);
            }

            return newNode;
        }

    }
}
