using Solver.Engine.Data;
using System;

namespace Solver.Engine.Rules.Simple.Impl
{
    public class UnreachableRule : ISimpleRule
    {
        public FieldType[] Check(int number, FieldType[] fields)
        {
            int? max = null;
            int? min = null;

            for(int i = 0; i < fields.Length; i++)
            {
                if (fields[i] == FieldType.Solid)
                {
                    max = i;

                    if (min == null)
                    {
                        min = i;
                    }
                }
            }

            if(max != null && min != null)
            {
                return Fill(min.GetValueOrDefault(), max.GetValueOrDefault(), number, fields);
            }

            return fields;
        }

        private FieldType[] Fill(int min, int max, int number, FieldType[] fields)
        {
            long maxDistance = number - (max - min);
            if(maxDistance <= 0)
            {
                return fields;
            }

            for(int i = 0; i < fields.Length; i++)
            {
                if(Math.Abs(i - min) >= maxDistance && Math.Abs(i - max) >= maxDistance && (i < min || max < i))
                {
                    fields[i] = FieldType.White;
                }
            }

            return fields;
        }
    }
}
