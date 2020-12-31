using Solver.Engine.Data;
using System.Collections.Generic;

namespace Solver.Engine.Rules
{
    public interface IComplexRule
    {
        FieldType[] Check(List<int> numbers, FieldType[] fields);
    }
}
