using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solver.Engine.Rules.Simple.Impl;

namespace Solver.Test.RuleTests
{
    [TestClass]
    public class NotEnoughSpaceRuleTests
    {
        private readonly NotEnoughSpaceRule notEnoughSpaceRule = new NotEnoughSpaceRule();

        [TestMethod]
        public void NoLittlePlaceTest()
        {
            int number = 1;
            int[] fields = new int[] { 0, -1, 0, 0, -1, 0 };
            int[] expected = new int[] { 0, -1, 0, 0, -1, 0 };

            var results = notEnoughSpaceRule.Check(number, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void StartLittlePlaceTest()
        {
            int number = 2;
            int[] fields = new int[] { 0, -1, 0, 0, -1, 0, 0 };
            int[] expected = new int[] { -1, -1, 0, 0, -1, 0, 0 };

            var results = notEnoughSpaceRule.Check(number, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void EndLittlePlaceTest()
        {
            int number = 3;
            int[] fields = new int[] { 0, 0, 0, -1, 0, 0, 0, 0, -1, 0, 0 };
            int[] expected = new int[] { 0, 0, 0, -1, 0, 0, 0, 0, -1, -1, -1 };

            var results = notEnoughSpaceRule.Check(number, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void MiddleLittlePlaceTest()
        {
            int number = 2;
            int[] fields = new int[] { 0, 0, 0, -1, 0, -1, 0, 0 };
            int[] expected = new int[] { 0, 0, 0, -1, -1, -1, 0, 0 };

            var results = notEnoughSpaceRule.Check(number, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void AllLittlePlaceTest()
        {
            int number = 5;
            int[] fields = new int[] { 0, 0, 0, -1, 0, -1, 1, 1, 1, 1, 1, -1, 0, 0 };
            int[] expected = new int[] { -1, -1, -1, -1, -1, -1, 1, 1, 1, 1, 1, - 1, -1, -1 };

            var results = notEnoughSpaceRule.Check(number, fields);

            CollectionAssert.AreEqual(expected, results);
        }
    }
}
