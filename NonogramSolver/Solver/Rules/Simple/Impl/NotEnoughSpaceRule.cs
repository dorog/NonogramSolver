using System.Collections.Generic;

namespace Solver.Engine.Rules.Simple.Impl
{
    public class NotEnoughSpaceRule : ISimpleRule
    {
        public int[] Check(int number, int[] fields)
        {
            List<int> whiteFieldPositions = new List<int>()
            {
                -1,
            };

            for(int i = 0; i < fields.Length; i++)
            {
                if(fields[i] == -1)
                {
                    whiteFieldPositions.Add(i);
                }
            }
            whiteFieldPositions.Add(fields.Length);

            for (int i = 1; i < whiteFieldPositions.Count; i++)
            {
                if(whiteFieldPositions[i] - whiteFieldPositions[i-1] <= number)
                {
                    for(int j = whiteFieldPositions[i - 1] + 1; j < whiteFieldPositions[i]; j++)
                    {
                        fields[j] = -1;
                    }
                }
            }

            return fields;
        }
    }
}
