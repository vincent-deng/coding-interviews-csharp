using CodingInterviews;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CodingTest
{
    public class Coding011Test
    {
        [Fact]
        public void Test1()
        {
            int data = 1;//0001
            Assert.Equal(1, Coding011.SimpleNumberOf1(data));
            Assert.Equal(1, Coding011.NumberOf1(data));
            data = 0b0001;
            Assert.Equal(1, Coding011.SimpleNumberOf1(data));
            Assert.Equal(1, Coding011.NumberOf1(data));

            data = 0b0100;
            Assert.Equal(1, Coding011.SimpleNumberOf1(data));
            Assert.Equal(1, Coding011.NumberOf1(data));
            data = 4;//0100
            Assert.Equal(1, Coding011.SimpleNumberOf1(data));
            Assert.Equal(1, Coding011.NumberOf1(data));

            data = 0b1000;
            Assert.Equal(1, Coding011.SimpleNumberOf1(data));
            Assert.Equal(1, Coding011.NumberOf1(data));
            data = 8;//1000
            Assert.Equal(1, Coding011.SimpleNumberOf1(data));
            Assert.Equal(1, Coding011.NumberOf1(data));

            data = 0;
            Assert.Equal(0, Coding011.SimpleNumberOf1(data));
            Assert.Equal(0, Coding011.NumberOf1(data));

            data = int.MaxValue;
            Assert.Equal(31, Coding011.SimpleNumberOf1(data));
            Assert.Equal(31, Coding011.NumberOf1(data));
        }

        [Fact]
        public void Test2()
        {
            var data = -1;
            Assert.Equal(32, Coding011.NumberOf1(data));

            data = -4;
            Assert.Equal(30, Coding011.NumberOf1(data));

            data = -8;
            Assert.Equal(29, Coding011.NumberOf1(data));

            data = int.MinValue;
            Assert.Equal(1, Coding011.NumberOf1(data));
        }


    }
}
