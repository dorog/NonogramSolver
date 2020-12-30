using System.Collections.Generic;

namespace Solver.Engine.Rules
{
    public interface IComplexRule
    {
        int[] Check(List<int> numbers, int[] fields);
    }
}
