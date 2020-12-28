using System.Collections.Generic;

namespace Solver.Engine.Rules
{
    public interface IComplexRule
    {
        int[] Check(List<uint> numbers, int[] fields);
    }
}
