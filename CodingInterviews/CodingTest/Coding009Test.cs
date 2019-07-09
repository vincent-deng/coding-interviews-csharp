using CodingInterviews;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CodingTest
{
    public class Coding009Test
    {
        [Fact]
        public void Test1()
        {
            Assert.Equal(1, Coding009.Jump(1));
        }

        [Fact]
        public void Test2()
        {
            Assert.Equal(2, Coding009.Jump(2));
        }

        [Fact]
        public void Test3()
        {
            Assert.Equal(4, Coding009.Jump(3));
        }

        [Fact]
        public void Test4()
        {
            Assert.Equal(8, Coding009.Jump(4));
        }

        [Fact]
        public void Test5()
        {
            Assert.Equal(16, Coding009.Jump(5));
        }

    }
}
