using CodingInterviews;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CodingTest
{
    public class Coding015Test
    {
        [Fact]
        public void Test0()
        {
            ListNode node = ListNode.CreateNodeList(6);
            ListNode node2 = ListNode.CreateNodeList(6);
            Assert.Equal(JsonConvert.SerializeObject(Coding015.PrintForReverse(node)), JsonConvert.SerializeObject(Coding015.PrintForReverse2(node2)));
        }

        [Fact]
        public void Test1()
        {
            ListNode node = ListNode.CreateNodeList(1);
            ListNode node2 = ListNode.CreateNodeList(1);
            Assert.Equal(JsonConvert.SerializeObject(Coding015.PrintForReverse(node)), JsonConvert.SerializeObject(Coding015.PrintForReverse2(node2)));
        }

        [Fact]
        public void Test2()
        {
            ListNode node = ListNode.CreateNodeList(2);
            ListNode node2 = ListNode.CreateNodeList(2);
            Assert.Equal(JsonConvert.SerializeObject(Coding015.PrintForReverse(node)), JsonConvert.SerializeObject(Coding015.PrintForReverse2(node2)));
        }

        [Fact]
        public void Test3()
        {
            ListNode node = ListNode.CreateNodeList(3);
            ListNode node2 = ListNode.CreateNodeList(3);
            Assert.Equal(JsonConvert.SerializeObject(Coding015.PrintForReverse(node)), JsonConvert.SerializeObject(Coding015.PrintForReverse2(node2)));
        }

        [Fact]
        public void TestNull()
        {
            ListNode node = null;
            Assert.Equal(JsonConvert.SerializeObject(Coding015.PrintForReverse(node)), JsonConvert.SerializeObject(Coding015.PrintForReverse2(node)));
        }
    }
}
