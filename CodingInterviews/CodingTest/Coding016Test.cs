using CodingInterviews;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CodingTest
{
    public class Coding016Test
    {
        [Fact]
        public void Test1()
        {
            ListNode node1 = null;
            ListNode node2 = null;
            ListNode node = Coding016.Merge(node1, node2);
            Assert.Null(node);
        }

        [Fact]
        public void Test2()
        {
            ListNode node1 = null;
            ListNode node2 = ListNode.CreateNodeList(3);
            string value = node2.GetListString();
            ListNode node = Coding016.Merge(node1, node2);
            Assert.Equal(value, node.GetListString());
        }

        [Fact]
        public void Test3()
        {
            ListNode node1 = ListNode.CreateNodeList(3);
            ListNode node2 = null;
            string value = node1.GetListString();
            ListNode node = Coding016.Merge(node1, node2);
            Assert.Equal(value, node.GetListString());
        }

        [Fact]
        public void Test4()
        {
            ListNode node1 = ListNode.CreateNodeList(3);
            ListNode node2 = ListNode.CreateNodeList(3);
            string value = "001122";
            ListNode node = Coding016.Merge(node1, node2);
            Assert.Equal(value, node.GetListString());
        }

        [Fact]
        public void Test5()
        {
            ListNode node1 = ListNode.CreateNodeList(3);
            ListNode node2 = ListNode.CreateNodeList(4);
            string value = "0011223";
            ListNode node = Coding016.Merge(node1, node2);
            Assert.Equal(value, node.GetListString());
        }

    }
}
