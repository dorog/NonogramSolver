using System.Collections.Generic;
using Solver.Engine.Data;

namespace Solver.Engine.Separators.Impl
{
    public abstract class EdgeSpaceSeparator : ISeparator
    {
        public Range[] Separate(List<int> numbers, FieldType[] fields)
        {
            Range[] ranges = new Range[numbers.Count];

            List<int> whiteSpacePositions = GetWhiteFieldPositions(fields);

            return CalculateRanges(numbers, fields, ranges, whiteSpacePositions);
        }

        private List<int> GetWhiteFieldPositions(FieldType[] fields)
        {
            List<int> whiteSpacePositions = new List<int>();

            for (int i = 0; i < fields.Length; i++)
            {
                if (fields[i] == FieldType.White)
                {
                    whiteSpacePositions.Add(i);
                }
            }

            return whiteSpacePositions;
        }

        protected bool SolidExists(int min, int max, FieldType[] fields)
        {
            for (int i = min; i < max; i++)
            {
                if (fields[i] == FieldType.Solid)
                {
                    return true;
                }
            }

            return false;
        }

        protected abstract Range[] CalculateRanges(List<int> numbers, FieldType[] fields, Range[] ranges, List<int> whiteSpacePositions);
    }
}
