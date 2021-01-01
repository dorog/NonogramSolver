using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solver.Engine.Data;
using Solver.Engine.Separators.Impl;
using System.Collections.Generic;

namespace Solver.Test.SeparatorTests
{
    [TestClass]
    public class StartSpaceSeparatorTests
    {
        private readonly StartSpaceSeparator startSpaceSeparator = new StartSpaceSeparator();

        private readonly FieldType solid = FieldType.Solid;
        private readonly FieldType unknown = FieldType.Unknown;
        private readonly FieldType white = FieldType.White;

        [TestMethod]
        public void NoWhiteFieldWithOneNumberTest()
        {
            List<int> numbers = new List<int> { 3 };
            FieldType[] fields = new FieldType[] { unknown, solid, solid, solid, unknown, unknown };
            Range[] expected = new Range[]
            {
                null   
            };

            var results = startSpaceSeparator.Separate(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void NoWhiteFieldWithMoreNumberTest()
        {
            List<int> numbers = new List<int> { 3, 1 };
            FieldType[] fields = new FieldType[] { unknown, solid, solid, solid, unknown, solid };
            Range[] expected = new Range[]
            {
                null,
                null,
            };

            var results = startSpaceSeparator.Separate(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void WhiteFieldWithOneNumberButWithoutSolidTest()
        {
            List<int> numbers = new List<int> { 3 };
            FieldType[] fields = new FieldType[] { unknown, unknown, unknown, white, unknown, unknown, unknown };
            Range[] expected = new Range[]
            {
                null
            };

            var results = startSpaceSeparator.Separate(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void WhiteFieldWithOneNumberWithSolidStartPerfectTest()
        {
            List<int> numbers = new List<int> { 3 };
            FieldType[] fields = new FieldType[] { unknown, solid, unknown, white, unknown, unknown, unknown };
            Range[] expected = new Range[]
            {
                new Range()
                {
                    Start = 0,
                    End = 2,
                }
            };

            var results = startSpaceSeparator.Separate(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void WhiteFieldWithOneNumberWithSolidStartGreaterWithOneTest()
        {
            List<int> numbers = new List<int> { 3 };
            FieldType[] fields = new FieldType[] { solid, unknown, unknown, unknown, white, unknown, unknown, unknown };
            Range[] expected = new Range[]
            {
                new Range()
                {
                    Start = 0,
                    End = 3,
                }
            };

            var results = startSpaceSeparator.Separate(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void WhiteFieldWithOneNumberWithSolidStartGreaterWithMoreTest()
        {
            List<int> numbers = new List<int> { 3 };
            FieldType[] fields = new FieldType[] { unknown, solid, unknown, unknown, unknown, white, unknown, unknown, unknown };
            Range[] expected = new Range[]
            {
                null
            };

            var results = startSpaceSeparator.Separate(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void WhiteFieldWithOneNumberWithSolidEndPerfectTest()
        {
            List<int> numbers = new List<int> { 3 };
            FieldType[] fields = new FieldType[] { unknown, unknown, unknown, white, unknown, unknown, solid };
            Range[] expected = new Range[]
            {
                null
            };

            var results = startSpaceSeparator.Separate(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void WhiteFieldWithOneNumberWithSolidEndGreaterWithOneTest()
        {
            List<int> numbers = new List<int> { 3 };
            FieldType[] fields = new FieldType[] { unknown, unknown, unknown, white, solid, unknown, unknown, unknown };
            Range[] expected = new Range[]
            {
                null
            };

            var results = startSpaceSeparator.Separate(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void WhiteFieldWithOneNumberWithSolidEndGreaterWithMoreTest()
        {
            List<int> numbers = new List<int> { 3 };
            FieldType[] fields = new FieldType[] { unknown, unknown, unknown, white, unknown, solid, unknown, unknown, unknown };
            Range[] expected = new Range[]
            {
                null
            };

            var results = startSpaceSeparator.Separate(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void WhiteFieldWithTwoNumberTest()
        {
            List<int> numbers = new List<int> { 1, 3 };
            FieldType[] fields = new FieldType[] { unknown, solid, white, solid, unknown, unknown };
            Range[] expected = new Range[]
            {
                new Range(){ Start = 0, End = 1 },
                null
            };

            var results = startSpaceSeparator.Separate(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }
    }
}
