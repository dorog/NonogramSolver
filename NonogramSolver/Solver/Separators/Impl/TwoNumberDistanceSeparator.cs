﻿using System.Collections.Generic;
using Solver.Engine.Data;

namespace Solver.Engine.Separators.Impl
{
    public class TwoNumberDistanceSeparator : ISeparator
    {
        public Range[] Separate(List<int> numbers, FieldType[] fields)
        {
            Range[] ranges = new Range[numbers.Count];
            if(numbers.Count == 2)
            {
                int max = numbers[0] + numbers[1];
                List<int> solidPositions = new List<int>();
                for(int i = 0; i < fields.Length; i++)
                {
                    if(fields[i] == FieldType.Solid)
                    {
                        solidPositions.Add(i);
                    }
                }

                for(int i = 1; i < solidPositions.Count; i++)
                {
                    if(solidPositions[i] - solidPositions[i-1] >= max)
                    {
                        int middle = solidPositions[i - 1] + numbers[0];
                        ranges[0] = new Range()
                        {
                            Start = 0,
                            End = middle
                        };
                        ranges[1] = new Range()
                        {
                            Start = middle + 1,
                            End = fields.Length - 1
                        };

                        return ranges;
                    }
                }
            }

            return ranges;
        }
    }
}
