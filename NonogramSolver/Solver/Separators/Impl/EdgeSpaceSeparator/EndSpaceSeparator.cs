using System.Collections.Generic;
using Solver.Engine.Data;

namespace Solver.Engine.Separators.Impl
{
    public class EndSpaceSeparator : EdgeSpaceSeparator
    {
        protected override Range[] CalculateRanges(List<int> numbers, FieldType[] fields, Range[] ranges, List<int> whiteSpacePositions)
        {
            if (whiteSpacePositions.Count > 0)
            {
                int lastWhiteLocation = whiteSpacePositions[^1];
                int lastNumber = numbers[^1];

                int space = fields.Length - 1 - lastWhiteLocation;
                if (lastNumber <= space && space <= lastNumber + 1 && SolidExists(lastWhiteLocation, fields.Length, fields))
                {
                    ranges[^1] = new Range()
                    {
                        Start = lastWhiteLocation + 1,
                        End = fields.Length - 1
                    };
                }
            }

            return ranges;
        }
    }
}
