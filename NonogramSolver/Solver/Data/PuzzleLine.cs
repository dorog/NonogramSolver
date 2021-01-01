using System.Collections.Generic;

namespace Solver.Engine.Data
{
    public class PuzzleLine
    {
        public Type Type { get; set; }
        public int Index { get; set; }
        public List<int> Numbers { get; set; }
        public FieldType[] Fields { get; set; }
    }
}
