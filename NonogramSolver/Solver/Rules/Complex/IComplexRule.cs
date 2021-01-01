using Solver.Engine.Data;
using System.Collections.Generic;

namespace Solver.Engine.Rules
{
    public interface IComplexRule
    {
        FieldType[] Apply(List<int> numbers, FieldType[] fields);
    }
}
