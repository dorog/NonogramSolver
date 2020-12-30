using Solver.Engine.Rules.Simple.Impl;
using System.Collections.Generic;
using System.Linq;

namespace Solver.Engine.Rules.Complex.Impl
{
    public class TooSmallSpaceRule : IComplexRule
    {
        private readonly NotEnoughSpaceRule notEnoughSpaceRule = new NotEnoughSpaceRule();

        public int[] Check(List<int> numbers, int[] fields)
        {
            int smallest = numbers.OrderBy(x => x).First();

            return notEnoughSpaceRule.Check(smallest, fields);
        }
    }
}
