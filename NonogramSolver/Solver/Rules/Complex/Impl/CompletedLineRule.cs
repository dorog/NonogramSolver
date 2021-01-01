using Solver.Engine.Data;
using System.Collections.Generic;

namespace Solver.Engine.Rules.Complex.Impl
{
    public class CompletedLineRule : IComplexRule
    {
        public FieldType[] Apply(List<int> numbers, FieldType[] fields)
        {
            List<int> lengths = GetContiguousSolidsLengths(fields);
            
            if(IsNumbersAndLengthsMatch(numbers, lengths))
            {
                SetEveryUnknownToWhite(fields);
            }

            return fields;
        }

        private List<int> GetContiguousSolidsLengths(FieldType[] fields)
        {
            List<int> lengths = new List<int>();

            int length = 0;
            foreach (var field in fields)
            {
                if (field == FieldType.Solid)
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

            return lengths;
        }

        private bool IsNumbersAndLengthsMatch(List<int> numbers, List<int> lengths)
        {
            if(numbers.Count != lengths.Count)
            {
                return false;
            }

            for (int i = 0; i < lengths.Count; i++)
            {
                if (numbers[i] != lengths[i])
                {
                    return false;
                }
            }

            return true;
        }

        private void SetEveryUnknownToWhite(FieldType[] fields)
        {
            for (int i = 0; i < fields.Length; i++)
            {
                if (fields[i] == FieldType.Unknown)
                {
                    fields[i] = FieldType.White;
                }
            }
        }
    }
}
