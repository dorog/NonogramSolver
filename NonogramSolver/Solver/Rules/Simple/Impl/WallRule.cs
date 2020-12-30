
namespace Solver.Engine.Rules.Simple.Impl
{
    public class WallRule : ISimpleRule
    {
        public int[] Check(int number, int[] fields)
        {
            if(fields[0] == 1)
            {
                for(int i = 0; i < number; i++)
                {
                    fields[i] = 1;
                }

                return fields;
            }
            else if(fields[^1] == 1)
            {
                int lastFieldIndex = fields.Length - 1;
                for (int i = 0; i < number; i++)
                {
                    fields[lastFieldIndex - i] = 1;
                }
            }
            else
            {
                for(int i = 1; i < fields.Length - 1; i++)
                {
                    if(fields[i] == 1)
                    {
                        if (fields[i - 1] == -1)
                        {
                            for(int j = 0; j < number; j++)
                            {
                                fields[i + j] = 1;
                            }
                        }
                        else if(fields[i + 1] == -1)
                        {
                            for (int j = 0; j < number; j++)
                            {
                                fields[i - j] = 1;
                            }
                        }
                    }
                }
            }

            return fields;
        }
    }
}
