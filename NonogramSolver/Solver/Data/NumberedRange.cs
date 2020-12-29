
namespace Solver.Engine.Data
{
    public class NumberedRange
    {
        public RangeType RangeType { get; set; }
        public int Index { get; set; }
        public int Delay { get; set; }
        public int[] Fields { get; set; }
        public uint Number { get; set; }

        public bool IsDone()
        {
            foreach(var field in Fields)
            {
                if(field != -1 || field != 1)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
