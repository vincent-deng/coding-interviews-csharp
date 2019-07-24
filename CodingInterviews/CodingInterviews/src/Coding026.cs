using System;
using System.Collections.Generic;
using System.Text;

namespace CodingInterviews
{
    /// <summary>
    /// 二叉搜索树与双向链表
    /// </summary>
    class Coding026
    {
        public TreeNode Convert(TreeNode root)
        {
            TreeNode lastNodeInList = null;
            ConvertNode(root, ref lastNodeInList);

            // lastNodeInList指向双向链表的尾结点，
            // 我们需要返回头结点
            TreeNode headInList = lastNodeInList;
            while (headInList != null && headInList.left != null)
            {
                headInList = headInList.left;
            }

            return headInList;
        }

        private void ConvertNode(TreeNode node, ref TreeNode lastNodeInList)
        {
            if (node == null)
            {
                return;
            }

            TreeNode currentNode = node;
            // 转换左子树
            if (currentNode.left != null)
            {
                ConvertNode(currentNode.left, ref lastNodeInList);
            }
            // 与根节点的衔接
            currentNode.left = lastNodeInList;
            if (lastNodeInList != null)
            {
                lastNodeInList.right = currentNode;
            }
            lastNodeInList = currentNode;
            // 转换右子树
            if (currentNode.right != null)
            {
                ConvertNode(currentNode.right, ref lastNodeInList);
            }
        }
    }
}
