using System.Collections.Generic;

namespace Solver.Engine.Rules
{
    public interface IRule
    {
        int[] Check(List<uint> numbers, int[] fields);
    }
}
