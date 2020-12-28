using System;

namespace Solver.Engine.Rules.Simple.Impl
{
    public class UnreachableRule : ISimpleRule
    {
        public int[] Check(uint number, int[] fields)
        {
            int? max = null;
            int? min = null;

            for(int i = 0; i < fields.Length; i++)
            {
                if (fields[i] > 0)
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

        private int[] Fill(int min, int max, uint number, int[] fields)
        {
            long maxDistance = number - (max - min);
            if(maxDistance <= 0)
            {
                return fields;
            }

            for(int i = 0; i < fields.Length; i++)
            {
                if(Math.Abs(i - min) >= maxDistance && Math.Abs(i - max) >= maxDistance)
                {
                    fields[i] = -1;
                }
            }

            return fields;
        }
    }
}
