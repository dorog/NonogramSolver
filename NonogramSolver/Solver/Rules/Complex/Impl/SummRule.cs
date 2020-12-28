using System.Collections.Generic;

namespace Solver.Engine.Rules.Complex.Impl
{
    public class SummRule : IComplexRule
    {
        public int[] Check(List<uint> numbers, int[] fields)
        {
            long summ = numbers.Count - 1;
            foreach(var number in numbers)
            {
                summ += number;
            }

            if(summ == fields.Length)
            {
                return Fill(numbers, fields);
            }

            return fields;
        }

        private int[] Fill(List<uint> numbers, int[] fields)
        {
            int index = 0;
            foreach(var number in numbers)
            {
                for(uint i = 0;  i < number; i++)
                {
                    fields[index] = 1;
                    index++;
                }
                if(index != fields.Length)
                {
                    fields[index] = -1;
                    index++;

                }
            }

            return fields;
        }
    }
}
