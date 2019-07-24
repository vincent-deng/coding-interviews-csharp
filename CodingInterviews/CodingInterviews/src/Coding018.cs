using System;
using System.Collections.Generic;
using System.Text;

namespace CodingInterviews
{

    /// <summary>
    /// 二叉树的镜像
    ///     8             8 
    ///    / \           / \ 
    ///   10 6           6 10 
    ///   / \ / \       / \ / \ 
    ///  11 9 7 5       5 7 9 11 
    ///  镜像：相当于镜子，左右对称
    ///  解题思路：
    ///  左右节点交换，依次左右交换
    /// </summary>
    public class Coding018
    {
        /// <summary>
        /// 镜像
        /// </summary>
        /// <param name="node"></param>
        public static void Mirror(TreeNode node) {
            if (node==null) return;

            var temp = node.left;
            node.left = node.right;
            node.right = temp;

            Mirror(node.left);
            Mirror(node.right);
        }
    }
}
