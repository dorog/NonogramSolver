using Solver.Engine.Data;
using System.Collections.Generic;
using System.Linq;

namespace Solver.Engine.Rules.Simple.Impl
{
    public class WallRule : ISimpleRule
    {
        public FieldType[] Apply(int number, FieldType[] fields)
        {
            List<FieldType> extendedFields = CreateExtendedFields(fields);

            Range range = FindWalledSolidRange(extendedFields, number);

            if(range != null)
            {
                Fill(range, fields);
            }

            return fields;
        }

        private List<FieldType> CreateExtendedFields(FieldType[] fields)
        {
            List<FieldType> extendedFields = new List<FieldType>();

            extendedFields.Add(FieldType.White);
            extendedFields.AddRange(fields.ToList());
            extendedFields.Add(FieldType.White);

            return extendedFields;
        }

        private Range FindWalledSolidRange(List<FieldType> extendedFields, int number)
        {
            for(int i = 1; i < extendedFields.Count - 1; i++)
            {
                if (extendedFields[i] == FieldType.Solid)
                {
                    if (extendedFields[i - 1] == FieldType.White)
                    {
                        return new Range() { Start = i - 1, End = i - 1 + (number - 1)};
                    }
                    else if (extendedFields[i + 1] == FieldType.White)
                    {
                        return new Range() { Start = i - 1 - (number - 1), End = i - 1};
                    }
                }
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
