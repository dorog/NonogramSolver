using Solver.Engine.Data;

namespace Solver.Engine.Rules.Simple.Impl
{
    public class UnreachableRule : ISimpleRule
    {
        public FieldType[] Apply(int number, FieldType[] fields)
        {
            Range range = GetFirstAndLastSolidRange(fields);

            if (range != null)
            {
                Fill(range, number, fields);
            }

            return fields;
        }

        private Range GetFirstAndLastSolidRange(FieldType[] fields)
        {
            int? max = null;
            int? min = null;

            for (int i = 0; i < fields.Length; i++)
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
                return new Range() { Start = min.GetValueOrDefault(), End = max.GetValueOrDefault() };
            }

            return null;
        }

        private void Fill(Range range, int number, FieldType[] fields)
        {
            long maxDistance = number - (range.End - range.Start);
            if(maxDistance > 0)
            {
                for (int i = 0; i < fields.Length; i++)
                {
                    if (System.Math.Abs(i - range.Start) >= maxDistance && System.Math.Abs(i - range.End) >= maxDistance && !IsBetweenStartAndEnd(i, range))
                    {
                        fields[i] = FieldType.White;
                    }
                }
            }
        }

        private bool IsBetweenStartAndEnd(int position, Range range)
        {
            return (range.Start <= position &&  position <= range.End);
        }
    }
}
