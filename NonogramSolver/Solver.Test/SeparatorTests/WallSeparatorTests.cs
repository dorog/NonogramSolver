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

        private readonly FieldType solid = FieldType.Solid;
        private readonly FieldType unknown = FieldType.Unknown;

        [TestMethod]
        public void NoRangeTest()
        {
            List<int> numbers = new List<int> { 2, 3 };
            FieldType[] fields = new FieldType[] { unknown, solid, unknown, solid, unknown, unknown };
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
            List<int> numbers = new List<int> { 5 };
            FieldType[] fields = new FieldType[] { solid, solid, solid, solid, solid };
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
            List<int> numbers = new List<int> { 4 };
            FieldType[] fields = new FieldType[] { solid, solid, solid, solid, solid };
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
            List<int> numbers = new List<int> { 4 };
            FieldType[] fields = new FieldType[] { unknown, solid, solid, solid, solid };
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
            List<int> numbers = new List<int> { 2, 3 };
            FieldType[] fields = new FieldType[] { solid, solid, unknown, solid, solid, solid };
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
            List<int> numbers = new List<int> { 2, 3 };
            FieldType[] fields = new FieldType[] { solid, solid, unknown, unknown, solid, unknown };
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
            List<int> numbers = new List<int> { 2, 3 };
            FieldType[] fields = new FieldType[] { unknown, solid, unknown, unknown, unknown, solid };
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
            List<int> numbers = new List<int> { 2, 2, 3 };
            FieldType[] fields = new FieldType[] { solid, unknown, unknown, solid, unknown, unknown, unknown, solid };
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
            List<int> numbers = new List<int> { 2, 2, 3 };
            FieldType[] fields = new FieldType[] { unknown, unknown, unknown, unknown, unknown, unknown, unknown, solid };
            Range[] expected = new Range[]
            {
                null,
                null,
                new Range(){ Start = 4, End = 7 },
            };

            var results = wallSeparator.Separate(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void MoreRangeStartTest()
        {
            List<int> numbers = new List<int> { 2, 2, 3 };
            FieldType[] fields = new FieldType[] { solid, unknown, unknown, unknown, unknown, unknown, unknown, unknown };
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
