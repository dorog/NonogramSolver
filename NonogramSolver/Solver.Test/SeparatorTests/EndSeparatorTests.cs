using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solver.Engine.Data;
using Solver.Engine.Separators.Impl;
using System.Collections.Generic;

namespace Solver.Test.SeparatorTests
{
    [TestClass]
    public class EndSeparatorTests
    {
        private readonly EndSeparator endSeparator = new EndSeparator();

        [TestMethod]
        public void NoWhiteFieldWithOneNumberTest()
        {
            List<int> numbers = new List<int> { 3 };
            int[] fields = new int[] { 0, 1, 1, 1, 0, 0 };
            Range[] expected = new Range[]
            {
                null   
            };

            var results = endSeparator.Separate(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void NoWhiteFieldWithMoreNumberTest()
        {
            List<int> numbers = new List<int> { 3, 1 };
            int[] fields = new int[] { 0, 1, 1, 1, 0, 1 };
            Range[] expected = new Range[]
            {
                null,
                null,
            };

            var results = endSeparator.Separate(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void WhiteFieldWithOneNumberButWithoutSolidTest()
        {
            List<int> numbers = new List<int> { 3 };
            int[] fields = new int[] { 0, 0, 0, -1, 0, 0, 0 };
            Range[] expected = new Range[]
            {
                null
            };

            var results = endSeparator.Separate(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void WhiteFieldWithOneNumberWithSolidStartPerfectTest()
        {
            List<int> numbers = new List<int> { 3 };
            int[] fields = new int[] { 0, 1, 0, -1, 0, 0, 0 };
            Range[] expected = new Range[]
            {
                new Range()
                {
                    Start = 0,
                    End = 2,
                }
            };

            var results = endSeparator.Separate(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void WhiteFieldWithOneNumberWithSolidStartGreaterWithOneTest()
        {
            List<int> numbers = new List<int> { 3 };
            int[] fields = new int[] { 1, 0, 0, 0, -1, 0, 0, 0 };
            Range[] expected = new Range[]
            {
                new Range()
                {
                    Start = 0,
                    End = 3,
                }
            };

            var results = endSeparator.Separate(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void WhiteFieldWithOneNumberWithSolidStartGreaterWithMoreTest()
        {
            List<int> numbers = new List<int> { 3 };
            int[] fields = new int[] { 0, 1, 0, 0, 0, -1, 0, 0, 0 };
            Range[] expected = new Range[]
            {
                null
            };

            var results = endSeparator.Separate(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void WhiteFieldWithOneNumberWithSolidEndPerfectTest()
        {
            List<int> numbers = new List<int> { 3 };
            int[] fields = new int[] { 0, 0, 0, -1, 0, 0, 1 };
            Range[] expected = new Range[]
            {
                new Range()
                {
                    Start = 4,
                    End = 6,
                }
            };

            var results = endSeparator.Separate(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void WhiteFieldWithOneNumberWithSolidEndGreaterWithOneTest()
        {
            List<int> numbers = new List<int> { 3 };
            int[] fields = new int[] { 0, 0, 0, -1, 1, 0, 0, 0 };
            Range[] expected = new Range[]
            {
                new Range()
                {
                    Start = 4,
                    End = 7,
                }
            };

            var results = endSeparator.Separate(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void WhiteFieldWithOneNumberWithSolidEndGreaterWithMoreTest()
        {
            List<int> numbers = new List<int> { 3 };
            int[] fields = new int[] { 0, 0, 0, -1, 0, 1, 0, 0, 0 };
            Range[] expected = new Range[]
            {
                null
            };

            var results = endSeparator.Separate(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void WhiteFieldWithTwoNumberTest()
        {
            List<int> numbers = new List<int> { 1, 3 };
            int[] fields = new int[] { 0, 1, -1, 1, 0, 0 };
            Range[] expected = new Range[]
            {
                new Range(){ Start = 0, End = 1 },
                new Range(){ Start = 3, End = 5 },
            };

            var results = endSeparator.Separate(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }
    }
}
