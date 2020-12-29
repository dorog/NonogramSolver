using System.Collections.Generic;

namespace Solver.Engine.Data
{
    public class NumberListRange
    {
        public RangeType RangeType { get; set; }
        public int Index { get; set; }
        public int Delay { get; set; }
        public int[] Fields { get; set; }
        public List<uint> Numbers { get; set; }
    }
}
