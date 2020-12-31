﻿using Solver.Engine.Data;
using System.Collections.Generic;

namespace Solver.Engine.Rules.Complex.Impl
{
    public class DoneRule : IComplexRule
    {
        public FieldType[] Check(List<int> numbers, FieldType[] fields)
        {
            List<int> lengths = new List<int>();

            int length = 0;
            foreach(var field in fields)
            {
                if(field == FieldType.Solid)
                {
                    length++;
                }
                else
                {
                    lengths.Add(length);
                    length = 0;
                }
            }
            lengths.Add(length);


            lengths.RemoveAll(x => x == 0);

            if(lengths.Count == numbers.Count)
            {
                for(int i = 0; i < lengths.Count; i++)
                {
                    if(numbers[i] != lengths[i])
                    {
                        return fields;
                    }
                }

                for(int i = 0; i < fields.Length; i++)
                {
                    if(fields[i] == FieldType.Unknown)
                    {
                        fields[i] = FieldType.White;
                    }
                }

                return fields;
            }
            else
            {
                return fields;
            }
        }
    }
}
