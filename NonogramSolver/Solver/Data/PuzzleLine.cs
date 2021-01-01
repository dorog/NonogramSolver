using System.Collections.Generic;

namespace Solver.Engine.Data
{
    public class PuzzleLine
    {
        public RangeType Type { get; set; }
        public int Index { get; set; }
        public List<int> Numbers { get; set; }
        public FieldType[] Fields { get; set; }
    }
}
