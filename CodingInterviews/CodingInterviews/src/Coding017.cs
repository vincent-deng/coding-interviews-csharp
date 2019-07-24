using System;
using System.Collections.Generic;
using System.Text;

namespace CodingInterviews
{
    /// <summary>
    /// 代码的鲁棒性:树的子结构
    /// 输入两棵二叉树A，B，判断B是不是A的子结构。（ps：我们约定空树不是任意一个树的子结构）
    /// 
    /// 解题思路：
    /// 查找B是不是A的子结构，其实就是查找B是不是A的一部分
    /// 1.先找出A和B一样的根节点R
    /// 2.判断R的左右节点和B是否一样
    /// 每次都是根节点，左右节点，递归实现
    /// 递归的终结是如果之前的节点均相同，最后子树为空时，而父树如果也是NULL，则说明两颗树完全一样，如果父树不是NULL，则子树是父树的一部分
    /// </summary>
    public class Coding017
    {
        /// <summary>
        /// check 左右子树是否相同
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="child"></param>
        /// <returns></returns>
        private static bool CheckLeftAndRightNode(TreeNode parent, TreeNode child)
        {
            if (child == null) return true; //子树为NULL，那么必然是子树
            if (parent == null) return false; //子树不是空，父树为空

            if (child.val != parent.val)
            {
                return false;
            }
            else {
                return CheckLeftAndRightNode(parent.left, child.left) & CheckLeftAndRightNode(parent.right, child.right);
            }
        }

        /// <summary>
        /// 查找子树
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="child"></param>
        /// <returns></returns>
        public static bool HasSubTree(TreeNode parent, TreeNode child)
        {
            if (parent == null || child == null) return false;
            bool result = false;
            if (parent.val == child.val)
            {
                result = CheckLeftAndRightNode(parent, child);
            }

            if (!result)
            {
                result = HasSubTree(parent.left, child) || HasSubTree(parent.right, child);
            }
            return result;
        }
    }
}
