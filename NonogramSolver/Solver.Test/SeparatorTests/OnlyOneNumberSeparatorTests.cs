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

        private readonly FieldType solid = FieldType.Solid;
        private readonly FieldType unknown = FieldType.Unknown;

        [TestMethod]
        public void OneNumberTest()
        {
            List<int> numbers = new List<int> { 3 };
            FieldType[] fields = new FieldType[] { unknown, solid, solid, solid, unknown, unknown };
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
            List<int> numbers = new List<int> { 3, 1 };
            FieldType[] fields = new FieldType[] { unknown, solid, solid, solid, unknown, unknown };
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
