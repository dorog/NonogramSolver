﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solver.Engine.Data;
using Solver.Engine.Separators.Impl;
using System.Collections.Generic;

namespace Solver.Test.SeparatorTests
{
    [TestClass]
    public class HoleNumberSeparatorTests
    {
        private readonly HoleNumberSeparator holeNumberSeparator = new HoleNumberSeparator();

        [TestMethod]
        public void OneNumberNoWhiteTest()
        {
            List<uint> numbers = new List<uint> { 3 };
            int[] fields = new int[] { 0, 1, 1, 1, 0, 0 };
            Range[] expected = new Range[]
            {
                new Range()
                {
                    Start = 0,
                    End = 5
                }
            };

            var results = holeNumberSeparator.Separate(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void TwoNumberNoWhiteTest()
        {
            List<uint> numbers = new List<uint> { 3, 1 };
            int[] fields = new int[] { 0, 1, 1, 1, 0, 1 };
            Range[] expected = new Range[]
            {
                null,
                null
            };

            var results = holeNumberSeparator.Separate(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void MoreNumberNoWhiteTest()
        {
            List<uint> numbers = new List<uint> { 3, 1, 1 };
            int[] fields = new int[] { 0, 1, 1, 1, 0, 1, 0, 1 };
            Range[] expected = new Range[]
            {
                null,
                null,
                null
            };

            var results = holeNumberSeparator.Separate(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void OneNumberOneWhiteStartTest()
        {
            List<uint> numbers = new List<uint> { 3 };
            int[] fields = new int[] { -1, 1, 1, 1, 0, 0 };
            Range[] expected = new Range[]
            {
                new Range()
                {
                    Start = 1,
                    End = 5
                }
            };

            var results = holeNumberSeparator.Separate(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void OneNumberOneWhiteEndTest()
        {
            List<uint> numbers = new List<uint> { 3 };
            int[] fields = new int[] { 0, 1, 1, 1, 0, -1 };
            Range[] expected = new Range[]
            {
                new Range()
                {
                    Start = 0,
                    End = 4
                }
            };

            var results = holeNumberSeparator.Separate(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void OneNumberOneWhiteMiddleTest()
        {
            List<uint> numbers = new List<uint> { 3 };
            int[] fields = new int[] { 0, 1, 1, 1, -1, 0 };
            Range[] expected = new Range[]
            {
                null
            };

            var results = holeNumberSeparator.Separate(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void TwoNumberOneWhiteMiddleTest()
        {
            List<uint> numbers = new List<uint> { 3, 1 };
            int[] fields = new int[] { 0, 1, 1, 1, -1, 0 };
            Range[] expected = new Range[]
            {
                new Range() { Start = 0, End = 3 },
                new Range() { Start = 5, End = 5 }
            };

            var results = holeNumberSeparator.Separate(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void TwoNumberOneWhiteEndTest()
        {
            List<uint> numbers = new List<uint> { 3, 1 };
            int[] fields = new int[] { 0, 1, 1, 1, 0, 1, 0, -1 };
            Range[] expected = new Range[]
            {
                null,
                null
            };

            var results = holeNumberSeparator.Separate(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void TwoNumberOneWhiteStartTest()
        {
            List<uint> numbers = new List<uint> { 3, 1 };
            int[] fields = new int[] { -1, 1, 1, 1, 0, 1, 0, 0 };
            Range[] expected = new Range[]
            {
                null,
                null
            };

            var results = holeNumberSeparator.Separate(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }
    }
}
