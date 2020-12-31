using Solver.Engine.Data;
using System.Collections.Generic;

namespace Solver.Engine.Separators.Impl
{
    public class WallSeparator : ISeparator
    {
        public Range[] Separate(List<int> numbers, FieldType[] fields)
        {
            Range[] ranges = new Range[numbers.Count];

            if(numbers.Count >= 1 && fields[0] == FieldType.Solid)
            {
                ranges[0] = new Range()
                {
                    Start = 0,
                    End = (numbers[0] - (fields.Length == numbers[0] ? 1 : 0))
                };
            }
            if(numbers.Count >= 1 && fields[^1] == FieldType.Solid)
            {
                ranges[numbers.Count - 1] = new Range()
                {
                    Start = (fields.Length - numbers[^1] - (fields.Length == numbers[^1] ? 0 : 1)),
                    End = (fields.Length - 1)
                };
            }

            return ranges;
        }
    }
}
