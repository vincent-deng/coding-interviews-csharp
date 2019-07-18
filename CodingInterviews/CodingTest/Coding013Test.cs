using CodingInterviews;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CodingTest
{
    public class Coding013Test
    {
        [Fact]
        public void Test1()
        {
            int[] array = { 1, 2, 3, 4, 5 };
            int[] result = { 1, 3, 5, 2, 4 };
            Assert.Equal(JsonConvert.SerializeObject(result), JsonConvert.SerializeObject(Coding013.HandleArray(array)));
        }

        [Fact]
        public void Test0()
        {
            int[] array = { 0 };
            int[] result = { 0 };
            Assert.Equal(JsonConvert.SerializeObject(result), JsonConvert.SerializeObject(Coding013.HandleArray(array)));
        }

        [Fact]
        public void Test2()
        {
            int[] array = { 1 };
            int[] result = { 1 };
            Assert.Equal(JsonConvert.SerializeObject(result), JsonConvert.SerializeObject(Coding013.HandleArray(array)));
        }

        [Fact]
        public void Test3()
        {
            int[] array = { 2 };
            int[] result = { 2 };
            Assert.Equal(JsonConvert.SerializeObject(result), JsonConvert.SerializeObject(Coding013.HandleArray(array)));
        }

        [Fact]
        public void Test4()
        {
            int[] array = { 1, 3, 5 };
            int[] result = { 1, 3, 5 };
            Assert.Equal(JsonConvert.SerializeObject(result), JsonConvert.SerializeObject(Coding013.HandleArray(array)));
        }

        [Fact]
        public void Test5()
        {
            int[] array = { 2, 4, 6 };
            int[] result = { 2, 4, 6 };
            Assert.Equal(JsonConvert.SerializeObject(result), JsonConvert.SerializeObject(Coding013.HandleArray(array)));
        }
    }
}
