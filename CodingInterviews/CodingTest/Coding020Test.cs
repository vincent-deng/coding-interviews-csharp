
using CodingInterviews;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CodingTest
{
    public class Coding020Test
    {
        [Fact]
        public void Test() {
            MinInStack stack = new MinInStack();
            stack.Push(1);
            Assert.Equal(1, stack.Min());
        }

        [Fact]
        public void Test2()
        {
            MinInStack stack = new MinInStack();
            stack.Push(1);
            stack.Push(2);
            Assert.Equal(1, stack.Min());
        }

        [Fact]
        public void Test3()
        {
            MinInStack stack = new MinInStack();
            stack.Push(3);
            stack.Push(2);
            stack.Push(1);
            Assert.Equal(1, stack.Min());
        }

        [Fact]
        public void Test4()
        {
            MinInStack stack = new MinInStack();
            stack.Push(3);
            stack.Push(2);
            stack.Push(1);
            Assert.Equal(1, stack.Min());
            stack.Pop();
            Assert.Equal(2, stack.Min());
            stack.Pop();
            Assert.Equal(3, stack.Min());
        }

        [Fact]
        public void Test5()
        {
            MinInStack stack = new MinInStack();
            stack.Push(3);
            stack.Push(2);
            stack.Push(2);
            stack.Push(4);
            Assert.Equal(2, stack.Min());
            stack.Pop();
            Assert.Equal(2, stack.Min());
            stack.Pop();
            stack.Pop();
            Assert.Equal(3, stack.Min());
        }

        [Fact]
        public void Test6()
        {
            MinInStack stack = new MinInStack();
            stack.Push(3);
            stack.Push(2);
            stack.Push(2);
            stack.Push(4);
            Assert.Equal(2, stack.Min());
            stack.Pop();
            stack.Push(1);
            Assert.Equal(1, stack.Min());
        }
    }
}
