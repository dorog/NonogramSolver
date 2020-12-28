
namespace Solver.Engine.Rules.Simple.Impl
{
    public class MoreThanHalfRule : ISimpleRule
    {
        public int[] Check(uint number, int[] fields)
        {
            if (number > fields.Length / 2)
            {
                for (int i = 0; i < fields.Length; i++)
                {
                    if (i < number && fields.Length - number <= i)
                    {
                        fields[i] = 1;
                    }
                }
            }

            return fields;
        }
    }
}
