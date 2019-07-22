using CodingInterviews;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CodingTest
{
    public class Coding014Test
    {
        [Fact]
        public void TestNull()
        {
            ListNode listNode = null;
            Assert.Null(Coding014.FindBackKth(listNode,9));
        }

        [Fact]
        public void TestK()
        {
            ListNode listNode = new ListNode(1);
            Assert.Null(Coding014.FindBackKth(listNode, 0));
            Assert.Equal(1, Coding014.FindBackKth(listNode, 1).item);
            Assert.Null(Coding014.FindBackKth(listNode, 2));
        }

        [Fact]
        public void Test1()
        {
            //0,1,2,3,4,5
            ListNode listNode = ListNode.CreateNodeList(6);
            Assert.Null(Coding014.FindBackKth(listNode, 0));
            Assert.Null(Coding014.FindBackKth(listNode, 7));
            Assert.Equal(3, Coding014.FindBackKth(listNode, 3).item);
            Assert.Equal(5, Coding014.FindBackKth(listNode, 1).item);
            Assert.Equal(0, Coding014.FindBackKth(listNode, 6).item);
        }

    }
}
