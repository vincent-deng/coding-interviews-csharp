using System;
using System.Collections.Generic;
using System.Text;

namespace CodingInterviews
{
    /// <summary>
    /// 从上往下打印二叉树
    /// </summary>
    public class Coding022
    {
        static void PrintFromTopToBottom(TreeNode root, List<int> data)
        {
            if (root == null)
            {
                return;
            }

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                TreeNode printNode = queue.Dequeue();
                data.Add(printNode.val);

                if (printNode.left != null)
                {
                    queue.Enqueue(printNode.left);
                }

                if (printNode.right != null)
                {
                    queue.Enqueue(printNode.right);
                }
            }
        }
    }
}
