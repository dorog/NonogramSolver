﻿using Solver.Engine.Data;
using System.Collections.Generic;

namespace Solver.Engine.Separators.Impl
{
    public class OnlyOneNumberSeparator : ISeparator
    {
        public Range[] Separate(List<int> numbers, FieldType[] fields)
        {
            Range[] ranges = new Range[numbers.Count];
            if(numbers.Count == 1)
            {
                ranges[0] = new Range()
                {
                    Start = 0,
                    End = fields.Length - 1
                };
            }

            return ranges;
        }
    }
}
