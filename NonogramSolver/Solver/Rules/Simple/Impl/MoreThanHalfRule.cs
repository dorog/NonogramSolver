using Solver.Engine.Data;

namespace Solver.Engine.Rules.Simple.Impl
{
    public class MoreThanHalfRule : ISimpleRule
    {
        public FieldType[] Apply(int number, FieldType[] fields)
        {
            if (number > fields.Length / 2)
            {
                for (int i = fields.Length - number; i < number; i++)
                {
                    fields[i] = FieldType.Solid;
                }
            }

            return fields;
        }
    }
}
