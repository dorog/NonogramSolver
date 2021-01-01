using Solver.Engine.Data;
using System.Collections.Generic;

namespace Solver.Engine.Rules.Complex.Impl
{
    public class SummRule : IComplexRule
    {
        public FieldType[] Apply(List<int> numbers, FieldType[] fields)
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

        private FieldType[] Fill(List<int> numbers, FieldType[] fields)
        {
            int index = 0;
            foreach(var number in numbers)
            {
                for(int i = 0;  i < number; i++)
                {
                    fields[index] = FieldType.Solid;
                    index++;
                }
                if(index != fields.Length)
                {
                    fields[index] = FieldType.White;
                    index++;

                }
            }

            return fields;
        }
    }
}
