using Solver.Engine.Data;
using System.Collections.Generic;

namespace Solver.Engine.Rules.Complex.Impl
{
    public class SummaryRule : IComplexRule
    {
        public FieldType[] Apply(List<int> numbers, FieldType[] fields)
        {
            int summary = CalculateNumbersSumm(numbers);

            if (summary == fields.Length)
            {
                Fill(numbers, fields);
            }

            return fields;
        }

        private int CalculateNumbersSumm(List<int> numbers)
        {
            int summary = numbers.Count - 1;
            foreach (var number in numbers)
            {
                summary += number;
            }

            return summary;
        }

        private void Fill(List<int> numbers, FieldType[] fields)
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
        }
    }
}
