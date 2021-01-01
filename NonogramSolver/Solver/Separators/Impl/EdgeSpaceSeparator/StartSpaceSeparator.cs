using System.Collections.Generic;
using Solver.Engine.Data;

namespace Solver.Engine.Separators.Impl
{
    public class StartSpaceSeparator : EdgeSpaceSeparator
    {
        protected override Range[] CalculateRanges(List<int> numbers, FieldType[] fields, Range[] ranges, List<int> whiteSpacePositions)
        {
            if (whiteSpacePositions.Count > 0)
            {
                int firstWhiteLocation = whiteSpacePositions[0];
                if (numbers[0] <= firstWhiteLocation && firstWhiteLocation <= numbers[0] + 1 && SolidExists(0, firstWhiteLocation, fields))
                {
                    ranges[0] = new Range()
                    {
                        Start = 0,
                        End = firstWhiteLocation - 1
                    };
                }
            }

            return ranges;
        }
    }
}
