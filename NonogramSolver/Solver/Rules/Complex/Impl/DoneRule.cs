using System.Collections.Generic;

namespace Solver.Engine.Rules.Complex.Impl
{
    public class DoneRule : IComplexRule
    {
        public int[] Check(List<uint> numbers, int[] fields)
        {
            List<uint> lengths = new List<uint>();

            uint length = 0;
            foreach(var field in fields)
            {
                if(field > 0)
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
                    if(fields[i] == 0)
                    {
                        fields[i] = -1;
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
