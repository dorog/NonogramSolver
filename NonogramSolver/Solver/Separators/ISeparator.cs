using Solver.Engine.Data;
using System.Collections.Generic;

namespace Solver.Engine.Separators
{
    public interface ISeparator
    {
        Range[] Separate(List<uint> numbers, int[] fields);
    }
}
