using CodingInterviews;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace CodingTest
{
    public class Coding018Test
    {
        /// 二叉树的镜像
        ///     8             8 
        ///    / \           / \ 
        ///   10 6           6 10 
        ///   / \ / \       / \ / \ 
        ///  11 9 7 5       5 7 9 11 
        ///  镜像：相当于镜子，左右对称
        ///  
        [Fact]
        public void Test1()
        {
            int[] preTree = { 8, 10, 11, 9, 6, 7, 5 };//前序
            int[] midTree = { 11, 10, 9, 8, 7, 6, 5 };//中序
            TreeNode tree = Coding004.Tree(preTree.ToList(), midTree.ToList());

            int[] preTree2 = { 8, 6, 5, 7, 10, 9, 11 };//前序
            int[] midTree2 = { 5, 6, 7, 8, 9, 10, 11 };//中序
            TreeNode tree2 = Coding004.Tree(preTree2.ToList(), midTree2.ToList());

            Coding018.Mirror(tree);
            Assert.Equal(JsonConvert.SerializeObject(tree2), JsonConvert.SerializeObject(tree));
        }

        /// <summary>
        /// 所有结点都没有右子结点
        ///            1     1
        ///           /       \
        ///          2         2 
        ///         /           \
        ///        3             3  
        /// </summary>
        [Fact]
        public void Right()
        {
            int[] preTree = { 1, 2, 3 };
            int[] midTree = { 3, 2, 1 };
            TreeNode tree = Coding004.Tree(preTree.ToList(), midTree.ToList());

            int[] preTree2 = { 1, 2, 3 };
            int[] midTree2 = { 1, 2, 3 };
            TreeNode tree2 = Coding004.Tree(preTree2.ToList(), midTree2.ToList());
            Coding018.Mirror(tree);
            Assert.Equal(JsonConvert.SerializeObject(tree2), JsonConvert.SerializeObject(tree));
        }

        /// <summary>
        /// 所有结点都没有左子结点
        ///            1                  1
        ///             \                /
        ///              2              2
        ///               \            /
        ///                3          3
        ///                 \        /
        ///                  4      4
        ///                   \    /
        ///                    5  5
        /// </summary>
        [Fact]
        public void Left()
        {
            int[] preTree = { 1, 2, 3, 4, 5 };
            int[] midTree = { 1, 2, 3, 4, 5 };
            TreeNode tree = Coding004.Tree(preTree.ToList(), midTree.ToList());

            int[] preTree2 = { 1, 2, 3, 4, 5 };
            int[] midTree2 = { 5, 4, 3, 2, 1 };
            TreeNode tree2 = Coding004.Tree(preTree2.ToList(), midTree2.ToList());
            Coding018.Mirror(tree);
            Assert.Equal(JsonConvert.SerializeObject(tree2), JsonConvert.SerializeObject(tree));
        }
    }
}
