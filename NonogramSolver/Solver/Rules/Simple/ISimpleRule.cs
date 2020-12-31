using Solver.Engine.Data;

namespace Solver.Engine.Rules.Simple
{
    public interface ISimpleRule
    {
        FieldType[] Check(int number, FieldType[] fields);
    }
}
