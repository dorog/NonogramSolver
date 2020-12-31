using Solver.Engine.Data;
using System.Collections.Generic;

namespace Solver.Engine.Rules.Simple.Impl
{
    public class NotEnoughSpaceRule : ISimpleRule
    {
        public FieldType[] Check(int number, FieldType[] fields)
        {
            List<int> whiteFieldPositions = new List<int>()
            {
                -1,
            };

            for(int i = 0; i < fields.Length; i++)
            {
                if(fields[i] == FieldType.White)
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
                        fields[j] = FieldType.White;
                    }
                }
            }

            return fields;
        }
    }
}
