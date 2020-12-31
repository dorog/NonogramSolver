using Solver.Engine.Data;

namespace Solver.Engine.Rules.Simple.Impl
{
    public class MergeRule : ISimpleRule
    {
        public FieldType[] Check(int number, FieldType[] fields)
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

            if(min != null && max != null && max - min < number)
            {
                return Fill(min.GetValueOrDefault(), max.GetValueOrDefault(), fields);
            }

            return fields;
        }

        private FieldType[] Fill(int min, int max, FieldType[] fields)
        {
            for(int i = min; i <= max; i++)
            {
                fields[i] = FieldType.Solid;
            }

            return fields;
        }
    }
}
