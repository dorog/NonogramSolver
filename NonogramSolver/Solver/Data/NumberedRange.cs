
using System.Linq;

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
            return !Fields.Any(x => x == 0);
        }
    }
}
