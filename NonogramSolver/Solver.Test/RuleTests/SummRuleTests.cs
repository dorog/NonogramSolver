using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solver.Engine.Data;
using Solver.Engine.Rules.Complex.Impl;
using System.Collections.Generic;

namespace Solver.Test.RuleTests
{
    [TestClass]
    public class SummRuleTests
    {
        private readonly SummRule summRule = new SummRule();

        private readonly FieldType solid = FieldType.Solid;
        private readonly FieldType white = FieldType.White;

        [TestMethod]
        public void FullWithOneNumberTest()
        {
            List<int> numbers = new List<int>{ 5 };
            FieldType[] fields = new FieldType[5];
            FieldType[] expected = new FieldType[] { solid, solid, solid, solid, solid };

            var results = summRule.Apply(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void FullWithTwoNumberTest()
        {
            List<int> numbers = new List<int> { 2, 2 };
            FieldType[] fields = new FieldType[5];
            FieldType[] expected = new FieldType[] { solid, solid, white, solid, solid };

            var results = summRule.Apply(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void FullWithMoreNumberTest()
        {
            List<int> numbers = new List<int> { 1, 1, 1 };
            FieldType[] fields = new FieldType[5];
            FieldType[] expected = new FieldType[] { solid, white, solid, white, solid };

            var results = summRule.Apply(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void NotFullWithOneNumberTest()
        {
            List<int> numbers = new List<int> { 4 };
            FieldType[] fields = new FieldType[5];
            FieldType[] expected = new FieldType[5];

            var results = summRule.Apply(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void NotFullWithTwoNumberTest()
        {
            List<int> numbers = new List<int> { 2, 1 };
            FieldType[] fields = new FieldType[5];
            FieldType[] expected = new FieldType[5];

            var results = summRule.Apply(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void NotFullWithMoreNumberTest()
        {
            List<int> numbers = new List<int> { 2, 1, 1 };
            FieldType[] fields = new FieldType[7];
            FieldType[] expected = new FieldType[7];

            var results = summRule.Apply(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }
    }
}
