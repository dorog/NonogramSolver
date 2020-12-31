using Solver.Engine.Data;

namespace Solver.Engine.Rules.Simple.Impl
{
    public class WallRule : ISimpleRule
    {
        public FieldType[] Check(int number, FieldType[] fields)
        {
            if(fields[0] == FieldType.Solid)
            {
                for(int i = 0; i < number; i++)
                {
                    fields[i] = FieldType.Solid;
                }

                return fields;
            }
            else if(fields[^1] == FieldType.Solid)
            {
                int lastFieldIndex = fields.Length - 1;
                for (int i = 0; i < number; i++)
                {
                    fields[lastFieldIndex - i] = FieldType.Solid;
                }
            }
            else
            {
                for(int i = 1; i < fields.Length - 1; i++)
                {
                    if(fields[i] == FieldType.Solid)
                    {
                        if (fields[i - 1] == FieldType.White)
                        {
                            for(int j = 0; j < number; j++)
                            {
                                fields[i + j] = FieldType.Solid;
                            }
                        }
                        else if(fields[i + 1] == FieldType.White)
                        {
                            for (int j = 0; j < number; j++)
                            {
                                fields[i - j] = FieldType.Solid;
                            }
                        }
                    }
                }
            }

            return fields;
        }
    }
}
