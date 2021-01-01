using Solver.Engine.Data;
using System.Collections.Generic;

namespace Solver.Engine.Separators.Impl
{
    public class WallSeparator : ISeparator
    {
        public Range[] Separate(List<int> numbers, FieldType[] fields)
        {
            Range[] ranges = new Range[numbers.Count];

            if(numbers.Count > 0 && fields[0] == FieldType.Solid)
            {
                int extraWhiteField = (fields.Length == numbers[0] ? 1 : 0);
                ranges[0] = new Range()
                {
                    Start = 0,
                    End = (numbers[0] - extraWhiteField)
                };
            }
            if(numbers.Count > 0 && fields[^1] == FieldType.Solid)
            {
                int extraWhiteField = (fields.Length == numbers[^1] ? 0 : 1);
                ranges[numbers.Count - 1] = new Range()
                {
                    Start = (fields.Length - numbers[^1] - extraWhiteField),
                    End = (fields.Length - 1)
                };
            }

            return ranges;
        }
    }
}
