using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solver.Engine.Data;
using Solver.Engine.Separators.Impl;
using System.Collections.Generic;

namespace Solver.Test.SeparatorTests
{
    [TestClass]
    public class OnlyOneNumberSeparatorTests
    {
        private readonly OnlyOneNumberSeparator onlyOneNumberSeparator = new OnlyOneNumberSeparator();

        [TestMethod]
        public void OneNumberTest()
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

            var results = onlyOneNumberSeparator.Separate(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }


        [TestMethod]
        public void TwoNumberTest()
        {
            List<uint> numbers = new List<uint> { 3, 1 };
            int[] fields = new int[] { 0, 1, 1, 1, 0, 0 };
            Range[] expected = new Range[]
            {
                null,
                null
            };

            var results = onlyOneNumberSeparator.Separate(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }
    }
}
