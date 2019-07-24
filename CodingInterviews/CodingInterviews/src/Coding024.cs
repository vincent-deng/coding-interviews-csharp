using System;
using System.Collections.Generic;
using System.Text;

namespace CodingInterviews
{
    /// <summary>
    /// 二叉树中和为某一值的路径
    /// </summary>
    class Coding024
    {
        public static void FindPath(TreeNode root, int expectedSum)
        {
            if (root == null)
            {
                return;
            }

            int currentSum = 0;
            List<int> path = new List<int>();
            FindPath(root, expectedSum, path, ref currentSum);
        }

        private static void FindPath(TreeNode root, int expectedSum, List<int> path, ref int currentSum)
        {
            currentSum += root.val;
            path.Add(root.val);
            // 如果是叶结点，并且路径上结点的和等于输入的值
            // 打印出这条路径
            bool isLeaf = root.left == null && root.right == null;
            if (isLeaf && currentSum == expectedSum)
            {
                foreach (int data in path)
                {
                    Console.Write("{0}\t", data);
                }
                Console.WriteLine();
            }

            // 如果不是叶结点，则遍历它的子结点
            if (root.left != null)
            {
                FindPath(root.left, expectedSum, path, ref currentSum);
            }

            if (root.right != null)
            {
                FindPath(root.right, expectedSum, path, ref currentSum);
            }

            // 在返回到父结点之前，在路径上删除当前结点，
            // 并在currentSum中减去当前结点的值
            path.Remove(root.val);
            currentSum -= root.val;
        }
    }
}
