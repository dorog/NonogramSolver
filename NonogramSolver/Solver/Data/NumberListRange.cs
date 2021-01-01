using System.Collections.Generic;

namespace Solver.Engine.Data
{
    public class NumberListRange
    {
        public Type RangeType { get; set; }
        public int Index { get; set; }
        public int Delay { get; set; }
        public FieldType[] Fields { get; set; }
        public List<int> Numbers { get; set; }
    }
}
