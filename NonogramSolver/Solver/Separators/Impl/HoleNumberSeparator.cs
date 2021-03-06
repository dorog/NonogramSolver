﻿using System.Collections.Generic;
using Solver.Engine.Data;

namespace Solver.Engine.Separators.Impl
{
    public class HoleNumberSeparator : ISeparator
    {
        public Range[] Separate(List<int> numbers, FieldType[] fields)
        {
            List<Range> holes = GetHoles(fields);

            if(holes.Count == numbers.Count)
            {
                for(int i = 0; i < holes.Count; i++)
                {
                    int place = holes[i].End - holes[i].Start + 1;
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

        private List<Range> GetHoles(FieldType[] fields)
        {
            List<Range> holes = new List<Range>();

            int? minRange = null;
            for(int i = 0; i < fields.Length; i++)
            {
                if(fields[i] != FieldType.White)
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
                        holes.Add(new Range() { Start = minRange.GetValueOrDefault(), End = (i - 1) });
                        minRange = null;
                    }
                }
            }

            if(minRange != null)
            {
                holes.Add(new Range() { Start = minRange.GetValueOrDefault(), End = (fields.Length - 1) });
            }

            return holes;
        }
    }
}
