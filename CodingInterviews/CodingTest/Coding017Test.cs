using CodingInterviews;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace CodingTest
{
    public class Coding017Test
    {
        /// <summary>
        /// 普通二叉树
        ///              1                    1
        ///           /     \              /     \
        ///          2       3            2       3  
        ///         /       / \          /       / \
        ///        4       5   6        4       5   6
        ///         \         /          \         /
        ///          7       8            7       8   
        /// </summary>
        [Fact]
        public void Test1()
        {
            int[] preTree = { 1, 2, 4, 7, 3, 5, 6, 8 };//前序
            int[] midTree = { 4, 7, 2, 1, 5, 3, 8, 6 };//中序
            TreeNode tree = Coding004.Tree(preTree.ToList(), midTree.ToList());

            int[] preTree2 = { 1, 2, 4, 7, 3, 5, 6, 8 };
            int[] midTree2 = { 4, 7, 2, 1, 5, 3, 8, 6 };
            TreeNode child = Coding004.Tree(preTree2.ToList(), midTree2.ToList());

            Assert.True(Coding017.HasSubTree(tree, child));

            int[] preTree3 = { 1, 2, 4, 7, 3, 5, 9, 8 };
            int[] midTree3 = { 4, 7, 2, 1, 5, 3, 8, 9 };
            TreeNode child3 = Coding004.Tree(preTree3.ToList(), midTree3.ToList());
            Assert.False(Coding017.HasSubTree(tree, child3));
        }

        /// <summary>
        /// 普通二叉树
        ///              1                    1
        ///           /     \              /  
        ///          2       3            2   
        ///         /       / \          /    
        ///        4       5   6        4    
        ///         \         /          \      
        ///          7       8            7     
        /// </summary>
        [Fact]
        public void Test2()
        {
            int[] preTree = { 1, 2, 4, 7, 3, 5, 6, 8 };
            int[] midTree = { 4, 7, 2, 1, 5, 3, 8, 6 };
            TreeNode tree = Coding004.Tree(preTree.ToList(), midTree.ToList());

            int[] preTree2 = { 1, 2, 4, 7};
            int[] midTree2 = { 4, 7, 2, 1};
            TreeNode child = Coding004.Tree(preTree2.ToList(), midTree2.ToList());
            Assert.True(Coding017.HasSubTree(tree, child));
        }

        /// <summary>
        /// 普通二叉树
        ///              1                
        ///           /     \             
        ///          2       3            2   
        ///         /       / \          /    
        ///        4       5   6        4    
        ///         \         /          \      
        ///          7       8            7     
        /// </summary>
        [Fact]
        public void Test3()
        {
            int[] preTree = { 1, 2, 4, 7, 3, 5, 6, 8 };
            int[] midTree = { 4, 7, 2, 1, 5, 3, 8, 6 };
            TreeNode tree = Coding004.Tree(preTree.ToList(), midTree.ToList());

            int[] preTree2 = {  2, 4, 7 };
            int[] midTree2 = { 4, 7, 2 };
            TreeNode child = Coding004.Tree(preTree2.ToList(), midTree2.ToList());
            Assert.True(Coding017.HasSubTree(tree, child));

        }


        /// <summary>
        /// 所有结点都没有右子结点
        ///            1     1
        ///           /     /
        ///          2     2 
        ///         / 
        ///        3 
        /// </summary>
        [Fact]
        public void Right()
        {
            int[] preTree = { 1, 2, 3 };
            int[] midTree = { 3, 2, 1 };
            TreeNode tree = Coding004.Tree(preTree.ToList(), midTree.ToList());

            int[] preTree2 = { 1, 2, 3 };
            int[] midTree2 = { 2, 1 };
            TreeNode child = Coding004.Tree(preTree2.ToList(), midTree2.ToList());
            Assert.True(Coding017.HasSubTree(tree, child));
        }

        /// <summary>
        /// 所有结点都没有左子结点
        ///            1     
        ///             \ 
        ///              2      2
        ///               \      \
        ///                3      3
        ///                 \      
        ///                  4
        ///                   \
        ///                    5
        /// </summary>
        [Fact]
        public void Left()
        {
            int[] preTree = { 1, 2, 3, 4, 5 };
            int[] midTree = { 1, 2, 3, 4, 5 };
            TreeNode tree = Coding004.Tree(preTree.ToList(), midTree.ToList());

            int[] preTree2 = { 2, 3 };
            int[] midTree2 = { 2, 3 };
            TreeNode child = Coding004.Tree(preTree2.ToList(), midTree2.ToList());
            Assert.True(Coding017.HasSubTree(tree, child));

        }

    }
}
