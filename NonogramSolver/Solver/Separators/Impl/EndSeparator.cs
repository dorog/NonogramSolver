using System.Collections.Generic;
using Solver.Engine.Data;

namespace Solver.Engine.Separators.Impl
{
    public class EndSeparator : ISeparator
    {
        public Range[] Separate(List<uint> numbers, int[] fields)
        {
            Range[] ranges = new Range[numbers.Count];

            int? firstWhite = null;
            int? lastWhite = null;

            for(int i = 0; i < fields.Length; i++)
            {
                if(fields[i] == -1)
                {
                    lastWhite = i;

                    if(firstWhite == null)
                    {
                        firstWhite = i;
                    }
                }
            }

            if(lastWhite != null)
            {
                int lastWhiteLocation = lastWhite.GetValueOrDefault();
                int lastFieldIndex = fields.Length - 1;
                if (lastFieldIndex - lastWhiteLocation <= numbers[^1] + 1 && lastFieldIndex - lastWhiteLocation >= numbers[^1] && SolidExists(lastWhiteLocation, lastFieldIndex + 1, fields))
                {
                    ranges[^1] = new Range()
                    {
                        Start = (uint)(lastWhiteLocation + 1),
                        End = (uint)fields.Length - 1
                    };
                }
            }

            if(firstWhite != null)
            {
                int firstWhiteLocation = firstWhite.GetValueOrDefault();
                if (firstWhiteLocation <= numbers[0] + 1 && firstWhiteLocation >= numbers[0] && SolidExists(0, firstWhiteLocation, fields))
                {
                    ranges[0] = new Range()
                    {
                        Start = 0,
                        End = (uint)firstWhiteLocation - 1
                    };
                }
            }

            return ranges;
        }

        private bool SolidExists(int min, int max, int[] fields)
        {
            for(int i = min; i < max; i++)
            {
                if(fields[i] == 1)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
