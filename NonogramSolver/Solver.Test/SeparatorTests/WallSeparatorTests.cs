using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solver.Engine.Data;
using Solver.Engine.Separators.Impl;
using System.Collections.Generic;

namespace Solver.Test.SeparatorTests
{
    [TestClass]
    public class WallSeparatorTests
    {
        private readonly WallSeparator wallSeparator = new WallSeparator();

        [TestMethod]
        public void NoRangeTest()
        {
            List<uint> numbers = new List<uint> { 2, 3 };
            int[] fields = new int[] { 0, 1, 0, 1, 0, 0 };
            Range[] expected = new Range[]
            {
                null,
                null
            };

            var results = wallSeparator.Separate(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void OneRangeFullTest()
        {
            List<uint> numbers = new List<uint> { 5 };
            int[] fields = new int[] { 1, 1, 1, 1, 1 };
            Range[] expected = new Range[] 
            {
                new Range(){ Start = 0, End = 4 }
            };

            var results = wallSeparator.Separate(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void OneRangeStartTest()
        {
            List<uint> numbers = new List<uint> { 4 };
            int[] fields = new int[] { 1, 1, 1, 1, 1 };
            Range[] expected = new Range[]
            {
                new Range(){ Start = 0, End = 4 }
            };

            var results = wallSeparator.Separate(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void OneRangeEndTest()
        {
            List<uint> numbers = new List<uint> { 4 };
            int[] fields = new int[] { 0, 1, 1, 1, 1 };
            Range[] expected = new Range[]
            {
                new Range(){ Start = 0, End = 4 }
            };

            var results = wallSeparator.Separate(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void TwoRangeBothTest()
        {
            List<uint> numbers = new List<uint> { 2, 3 };
            int[] fields = new int[] { 1, 1, 0, 1, 1, 1 };
            Range[] expected = new Range[]
            {
                new Range(){ Start = 0, End = 2 },
                new Range(){ Start = 2, End = 5 }
            };

            var results = wallSeparator.Separate(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void TwoRangeStartTest()
        {
            List<uint> numbers = new List<uint> { 2, 3 };
            int[] fields = new int[] { 1, 1, 0, 0, 1, 0 };
            Range[] expected = new Range[]
            {
                new Range(){ Start = 0, End = 2 },
                null
            };

            var results = wallSeparator.Separate(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void TwoRangeEndTest()
        {
            List<uint> numbers = new List<uint> { 2, 3 };
            int[] fields = new int[] { 0, 1, 0, 0, 0, 1 };
            Range[] expected = new Range[]
            {
                null,
                new Range(){ Start = 2, End = 5 }
            };

            var results = wallSeparator.Separate(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void MoreRangeBothTest()
        {
            List<uint> numbers = new List<uint> { 2, 2, 3 };
            int[] fields = new int[] { 1, 0, 0, 1, 0, 0, 0, 1 };
            Range[] expected = new Range[]
            {
                new Range(){ Start = 0, End = 2 },
                null,
                new Range(){ Start = 4, End = 7 },
            };

            var results = wallSeparator.Separate(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void MoreRangeEndTest()
        {
            List<uint> numbers = new List<uint> { 2, 2, 3 };
            int[] fields = new int[] { 0, 0, 0, 0, 0, 0, 0, 1 };
            Range[] expected = new Range[]
            {
                null,
                null,
                new Range(){ Start = 4, End = 7 },
            };

            var results = wallSeparator.Separate(numbers, fields);

            foreach(var result in results)
            {
                if(result == null)
                {
                    System.Console.WriteLine("Null");
                }
                else
                {
                    System.Console.WriteLine(result.Start + " - " + result.End);
                }
            }

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void MoreRangeStartTest()
        {
            List<uint> numbers = new List<uint> { 2, 2, 3 };
            int[] fields = new int[] { 1, 0, 0, 0, 0, 0, 0, 0 };
            Range[] expected = new Range[]
            {
                new Range(){ Start = 0, End = 2 },
                null,
                null,
            };

            var results = wallSeparator.Separate(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }
    }
}
