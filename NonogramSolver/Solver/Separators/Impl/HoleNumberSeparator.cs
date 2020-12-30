using System.Collections.Generic;
using Solver.Engine.Data;

namespace Solver.Engine.Separators.Impl
{
    public class HoleNumberSeparator : ISeparator
    {
        public Range[] Separate(List<uint> numbers, int[] fields)
        {
            List<Range> holes = GetHoles(fields);

            if(holes.Count == numbers.Count)
            {
                for(int i = 0; i < holes.Count; i++)
                {
                    uint place = holes[i].End - holes[i].Start + 1;
                    if(place < numbers[i])
                    {
                        return new Range[numbers.Count];
                    }
                }
                return holes.ToArray();
            }
            else
            {
                return new Range[numbers.Count];
            }
        }

        private List<Range> GetHoles(int[] fields)
        {
            List<Range> holes = new List<Range>();

            int? minRange = null;
            for(int i = 0; i < fields.Length; i++)
            {
                if(fields[i] != -1)
                {
                    if(minRange == null)
                    {
                        minRange = i;
                    }
                }
                else
                {
                    if(minRange != null)
                    {
                        holes.Add(new Range() { Start = (uint)minRange.GetValueOrDefault(), End = (uint)(i - 1) });
                        minRange = null;
                    }
                }
            }

            if(minRange != null)
            {
                holes.Add(new Range() { Start = (uint)minRange.GetValueOrDefault(), End = (uint)(fields.Length - 1) });
            }

            return holes;
        }
    }
}
