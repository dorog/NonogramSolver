﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solver.Engine.Data;
using Solver.Engine.Separators.Impl;
using System.Collections.Generic;

namespace Solver.Test.SeparatorTests
{
    [TestClass]
    public class TwoNumberDistanceSeparatorTests
    {
        private readonly TwoNumberDistanceSeparator twoNumberDistanceSeparator = new TwoNumberDistanceSeparator();

        [TestMethod]
        public void OneNumberRangeTest()
        {
            List<int> numbers = new List<int> { 3 };
            int[] fields = new int[] { 0, 1, 1, 1, 0, 0 };
            Range[] expected = new Range[]
            {
                null
            };

            var results = twoNumberDistanceSeparator.Separate(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void MoreThanTwoNumberRangeTest()
        {
            List<int> numbers = new List<int> { 1, 1, 1 };
            int[] fields = new int[] { 0, 1, 0, 1, 0, 1 };
            Range[] expected = new Range[]
            {
                null,
                null,
                null
            };

            var results = twoNumberDistanceSeparator.Separate(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void TwoNumberTwoSolidButTooCloseRangeTest()
        {
            List<int> numbers = new List<int> { 1, 2 };
            int[] fields = new int[] { 0, 1, 0, 1, 0, 0 };
            Range[] expected = new Range[]
            {
                null,
                null
            };

            var results = twoNumberDistanceSeparator.Separate(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void TwoNumberMoreSolidButTooCloseRangeTest()
        {
            List<int> numbers = new List<int> { 1, 3 };
            int[] fields = new int[] { 0, 1, 0, 1, 0, 1 };
            Range[] expected = new Range[]
            {
                null,
                null
            };

            var results = twoNumberDistanceSeparator.Separate(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void TwoNumberTwoSolidAndEnoughSpaceRangeTest()
        {
            List<int> numbers = new List<int> { 1, 1 };
            int[] fields = new int[] { 0, 1, 0, 0, 1, 0 };
            Range[] expected = new Range[]
            {
                new Range(){ Start = 0, End = 2 },
                new Range(){ Start = 3, End = 5 }
            };

            var results = twoNumberDistanceSeparator.Separate(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void TwoNumberMoreSolidAndEnoughSpaceRangeTest()
        {
            List<int> numbers = new List<int> { 1, 3 };
            int[] fields = new int[] { 0, 1, 0, 0, 0, 1, 0, 1 };
            Range[] expected = new Range[]
            {
                new Range(){ Start = 0, End = 2 },
                new Range(){ Start = 3, End = 7 },
            };

            var results = twoNumberDistanceSeparator.Separate(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }
    }
}
