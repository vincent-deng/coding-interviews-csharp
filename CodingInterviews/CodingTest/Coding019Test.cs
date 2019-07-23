using CodingInterviews;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace CodingTest
{
    public class Coding019Test
    {
        [Fact]
        public void Test()
        {
            int[,] data = {
                { 1, 2, 3, 4},
                {5 ,6, 7, 8  },
                {9, 10 ,11 ,12  },
                { 13, 14, 15 ,16}
            };

            int[] expect = { 1, 2, 3, 4, 8, 12, 16, 15, 14, 13, 9, 5, 6, 7, 11, 10 };
            List<int> expected = expect.ToList();
            List<int> actual = Coding019.HandleArray(data);

            Assert.Equal(JsonConvert.SerializeObject(expected), JsonConvert.SerializeObject(actual));
        }

        [Fact]
        public void One()
        {
            int[,] data = {
                { 1 }
            };

            int[] expect = { 1 };
            List<int> expected = expect.ToList();
            List<int> actual = Coding019.HandleArray(data);

            Assert.Equal(JsonConvert.SerializeObject(expected), JsonConvert.SerializeObject(actual));
        }

        [Fact]
        public void TopBottom()
        {
            int[,] data = {
                { 1, 2},
                {5 ,6 }
            };

            int[] expect = { 1, 2, 6, 5 };
            List<int> expected = expect.ToList();
            List<int> actual = Coding019.HandleArray(data);

            Assert.Equal(JsonConvert.SerializeObject(expected), JsonConvert.SerializeObject(actual));
        }

        [Fact]
        public void TopRightLeftBottom()
        {
            int[,] data = {
                { 1, 2},
                {5 ,6 },
                {9, 10  }
            };

            int[] expect = { 1, 2, 6, 10, 9, 5 };
            List<int> expected = expect.ToList();
            List<int> actual = Coding019.HandleArray(data);

            Assert.Equal(JsonConvert.SerializeObject(expected), JsonConvert.SerializeObject(actual));
        }

        [Fact]
        public void Right()
        {
            int[,] data = {
                { 1, 2,3}
            };

            int[] expect = { 1, 2, 3 };
            List<int> expected = expect.ToList();
            List<int> actual = Coding019.HandleArray(data);

            Assert.Equal(JsonConvert.SerializeObject(expected), JsonConvert.SerializeObject(actual));
        }

        [Fact]
        public void Bottom()
        {
            int[,] data = {
                { 1},
                {5  },
                {9  }
            };

            int[] expect = { 1, 5, 9 };
            List<int> expected = expect.ToList();
            List<int> actual = Coding019.HandleArray(data);

            Assert.Equal(JsonConvert.SerializeObject(expected), JsonConvert.SerializeObject(actual));
        }


    }
}
