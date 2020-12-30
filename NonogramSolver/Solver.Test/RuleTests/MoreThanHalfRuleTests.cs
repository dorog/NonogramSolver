using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solver.Engine.Rules.Simple.Impl;

namespace Solver.Test.RuleTests
{
    [TestClass]
    public class MoreThanHalfRuleTests
    {
        private readonly MoreThanHalfRule halfOrMore = new MoreThanHalfRule();

        [TestMethod]
        public void FullTest()
        {
            int number =  5 ;
            int[] fields = new int[5];
            int[] expected = new int[] { 1, 1, 1, 1, 1 };

            var results = halfOrMore.Check(number, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void MoreThanHalfTest()
        {
            int number = 3;
            int[] fields = new int[5];
            int[] expected = new int[] { 0, 0, 1, 0, 0 };

            var results = halfOrMore.Check(number, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void HalfTest()
        {
            int number = 3;
            int[] fields = new int[6];
            int[] expected = new int[] { 0, 0, 0, 0, 0, 0 };

            var results = halfOrMore.Check(number, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void LessThanHalfTest()
        {
            int number = 2;
            int[] fields = new int[6];
            int[] expected = new int[] { 0, 0, 0, 0, 0, 0 };

            var results = halfOrMore.Check(number, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void NotEmpyRowAndMoreThanHalfTest()
        {
            int number = 3;
            int[] fields = new int[5] { 0, 0, 0, 0, 1 };
            int[] expected = new int[] { 0, 0, 1, 0, 1 };

            var results = halfOrMore.Check(number, fields);

            CollectionAssert.AreEqual(expected, results);
        }
    }
}
