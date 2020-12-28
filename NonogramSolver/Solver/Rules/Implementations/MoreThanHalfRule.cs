using System.Collections.Generic;

namespace Solver.Engine.Rules.Implementations
{
    public class MoreThanHalfRule : IRule
    {
        public int[] Check(List<uint> numbers, int[] fields)
        {
            if (numbers.Count == 1)
            {
                return Fill(numbers[0], fields);
            }
            else
            {
                return fields;
            }
        }

        private int[] Fill(uint number, int[] fields)
        {
            if(number > fields.Length / 2)
            {
                for(int i = 0; i < fields.Length; i++)
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
