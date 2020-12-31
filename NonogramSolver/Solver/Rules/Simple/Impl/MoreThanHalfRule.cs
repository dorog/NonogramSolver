using Solver.Engine.Data;

namespace Solver.Engine.Rules.Simple.Impl
{
    public class MoreThanHalfRule : ISimpleRule
    {
        public FieldType[] Check(int number, FieldType[] fields)
        {
            if (number > fields.Length / 2)
            {
                for (int i = 0; i < fields.Length; i++)
                {
                    if (i < number && fields.Length - number <= i)
                    {
                        fields[i] = FieldType.Solid;
                    }
                }
            }

            return fields;
        }
    }
}
