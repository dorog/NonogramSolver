using Solver.Engine.Data;

namespace Solver.Engine.Rules.Simple.Impl
{
    public class MergeRule : ISimpleRule
    {
        public FieldType[] Apply(int number, FieldType[] fields)
        {
            Range range = GetFirstAndLastSolidRange(fields);

            if(range != null && range.End - range.Start < number)
            {
                Fill(range, fields);
            }

            return fields;
        }

        private Range GetFirstAndLastSolidRange(FieldType[] fields)
        {
            int? min = null;
            int? max = null;

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

            if(min != null && max != null)
            {
                return new Range() { Start = min.GetValueOrDefault(), End = max.GetValueOrDefault() };
            }

            return null;
        }

        private void Fill(Range range, FieldType[] fields)
        {
            for(int i = range.Start; i <= range.End; i++)
            {
                fields[i] = FieldType.Solid;
            }
        }
    }
}
