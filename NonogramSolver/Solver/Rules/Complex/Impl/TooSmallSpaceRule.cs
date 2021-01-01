using Solver.Engine.Data;
using Solver.Engine.Rules.Simple.Impl;
using System.Collections.Generic;
using System.Linq;

namespace Solver.Engine.Rules.Complex.Impl
{
    public class TooSmallSpaceRule : IComplexRule
    {
        private readonly NotEnoughSpaceRule notEnoughSpaceRule = new NotEnoughSpaceRule();

        public FieldType[] Apply(List<int> numbers, FieldType[] fields)
        {
            int smallest = numbers.OrderBy(x => x).First();

            return notEnoughSpaceRule.Apply(smallest, fields);
        }
    }
}
