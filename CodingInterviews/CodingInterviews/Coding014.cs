using System;
using System.Collections.Generic;
using System.Text;

namespace CodingInterviews
{
    /// <summary>
    /// 代码的鲁棒性:链表中倒数第k个结点
    /// 输入一个链表，输出该链表中倒数第k个结点。
    /// 例如：输入一个链表，输出该链表中倒数第k个结点。为了符合大多数人的习惯，本题从1开始计数，即链表的尾结点是倒数第1个结点。
    /// 例如一个链表有6个结点，从头结点开始它们的值依次是1、2、3、4、5、6,这个链表的倒数第3个结点是值为4的结点。
    /// </summary>
    public class Coding014
    {
        public static ListNode FindBackKth(ListNode node, int k) {
            if (node == null || k <= 0) {
                return null;
            }

            ListNode firstNode = node;
            ListNode secondNode = node;
            for (int i = 1; i <= k - 1; i++) {
                firstNode = firstNode.next;
                if (firstNode == null) {
                    return null;
                }
            }

            while (firstNode.next != null) {
                firstNode = firstNode.next;
                secondNode = secondNode.next;
            }

            return secondNode;
        }
    }
}
