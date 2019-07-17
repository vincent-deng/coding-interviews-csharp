using CodingInterviews;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CodingTest
{
    public class Coding012Test
    {
        [Fact]
        public void Test()
        {
            Assert.Equal(Math.Pow(2, 0), Coding012.Pow(2, 0));
            Assert.Equal(Math.Pow(2, 1), Coding012.Pow(2, 1));
            Assert.Equal(Math.Pow(2, -1), Coding012.Pow(2, -1));
            Assert.Equal(Math.Pow(2, 2), Coding012.Pow(2, 2));
            Assert.Equal(Math.Pow(2, -2), Coding012.Pow(2, -2));
        }
    }
}
