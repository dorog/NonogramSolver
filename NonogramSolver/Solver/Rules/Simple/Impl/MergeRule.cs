
namespace Solver.Engine.Rules.Simple.Impl
{
    public class MergeRule : ISimpleRule
    {
        public int[] Check(int number, int[] fields)
        {
            int? min = null;
            int? max = null;

            for (int i = 0; i < fields.Length; i++)
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

            if(min != null && max != null && max - min < number)
            {
                return Fill(min.GetValueOrDefault(), max.GetValueOrDefault(), fields);
            }

            return fields;
        }

        private int[] Fill(int min, int max, int[] fields)
        {
            for(int i = min; i <= max; i++)
            {
                fields[i] = 1;
            }

            return fields;
        }
    }
}
