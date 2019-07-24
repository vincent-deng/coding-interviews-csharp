using System;
using System.Collections.Generic;
using System.Text;

namespace CodingInterviews
{
    /// <summary>
    /// 复杂链表的复制
    /// </summary>
    class Coding025
    {
        ///  复制操作
        public ListNode Clone(ListNode pHead)
        {
            if (pHead == null)
            {
                return null;
            }
            Dictionary<ListNode, ListNode> nodeMap =new Dictionary<ListNode, ListNode>();

            ListNode currNode = pHead;
            ListNode newHead = null, preNode = null, newNode = null;

            ///  首先复制原链表的普通指针域, 一次遍历即可完成
            while (currNode != null)
            {
                newNode = new ListNode(currNode.item);
                nodeMap.Add(currNode, newNode);
                currNode = currNode.next;

                if (preNode == null)
                {
                    newHead = newNode;
                }
                else
                {
                    preNode.next = newNode;
                }

                preNode = newNode;
            }

            //  接着复制随机指针域, 需要两次遍历
            currNode = pHead;
            newNode = newHead;
            while (currNode != null && newNode != null)
            {
                ListNode randNode = currNode.random; ///随机指针域randNode
                ListNode newRandNode = nodeMap[randNode];
                newNode.random = newRandNode;

                ///  链表同步移动
                currNode = currNode.next;
                newNode = newNode.next;
            }

            return newHead;
        }

    }
}
