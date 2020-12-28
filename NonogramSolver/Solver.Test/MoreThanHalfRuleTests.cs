using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solver.Engine.Rules.Implementations;
using System.Collections.Generic;

namespace Solver.Test
{
    [TestClass]
    public class MoreThanHalfRuleTests
    {
        private readonly MoreThanHalfRule halfOrMore = new MoreThanHalfRule();

        [TestMethod]
        public void FullTest()
        {
            List<uint> numbers = new List<uint>{ 5 };
            int[] fields = new int[5];
            int[] expected = new int[] { 1, 1, 1, 1, 1 };

            var results = halfOrMore.Check(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void MoreThanHalfTest()
        {
            List<uint> numbers = new List<uint> { 3 };
            int[] fields = new int[5];
            int[] expected = new int[] { 0, 0, 1, 0, 0 };

            var results = halfOrMore.Check(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void HalfTest()
        {
            List<uint> numbers = new List<uint> { 3 };
            int[] fields = new int[6];
            int[] expected = new int[] { 0, 0, 0, 0, 0, 0 };

            var results = halfOrMore.Check(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void LessThanHalfTest()
        {
            List<uint> numbers = new List<uint> { 2 };
            int[] fields = new int[6];
            int[] expected = new int[] { 0, 0, 0, 0, 0, 0 };

            var results = halfOrMore.Check(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void NotEmpyRowAndMoreThanHalfTest()
        {
            List<uint> numbers = new List<uint> { 3 };
            int[] fields = new int[5] { 0, 0, 0, 0, 1 };
            int[] expected = new int[] { 0, 0, 1, 0, 1 };

            var results = halfOrMore.Check(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }
    }
}
