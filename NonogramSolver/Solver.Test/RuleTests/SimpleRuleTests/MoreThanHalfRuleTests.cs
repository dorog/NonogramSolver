using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solver.Engine.Data;
using Solver.Engine.Rules.Simple.Impl;

namespace Solver.Test.RuleTests.SimpleRuleTests
{
    [TestClass]
    public class MoreThanHalfRuleTests
    {
        private readonly MoreThanHalfRule halfOrMore = new MoreThanHalfRule();

        private readonly FieldType solid = FieldType.Solid;
        private readonly FieldType unknown = FieldType.Unknown;

        [TestMethod]
        public void FullTest()
        {
            int number =  5 ;
            FieldType[] fields = new FieldType[5];
            FieldType[] expected = new FieldType[] { solid, solid, solid, solid, solid };

            var results = halfOrMore.Apply(number, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void MoreThanHalfTest()
        {
            int number = 3;
            FieldType[] fields = new FieldType[5];
            FieldType[] expected = new FieldType[] { unknown, unknown, solid, unknown, unknown };

            var results = halfOrMore.Apply(number, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void HalfTest()
        {
            int number = 3;
            FieldType[] fields = new FieldType[6];
            FieldType[] expected = new FieldType[] { unknown, unknown, unknown, unknown, unknown, unknown };

            var results = halfOrMore.Apply(number, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void LessThanHalfTest()
        {
            int number = 2;
            FieldType[] fields = new FieldType[6];
            FieldType[] expected = new FieldType[] { unknown, unknown, unknown, unknown, unknown, unknown };

            var results = halfOrMore.Apply(number, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void NotEmpyRowAndMoreThanHalfTest()
        {
            int number = 3;
            FieldType[] fields = new FieldType[5] { unknown, unknown, unknown, unknown, solid };
            FieldType[] expected = new FieldType[] { unknown, unknown, solid, unknown, solid };

            var results = halfOrMore.Apply(number, fields);

            CollectionAssert.AreEqual(expected, results);
        }
    }
}
