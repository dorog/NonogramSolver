using Solver.Engine.Data;

namespace Solver.Engine.Rules.Simple
{
    public interface ISimpleRule
    {
        FieldType[] Apply(int number, FieldType[] fields);
    }
}
