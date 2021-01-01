using System.Linq;

namespace Solver.Engine.Data
{
    public class NumberedRange
    {
        public Type RangeType { get; set; }
        public int Index { get; set; }
        public int Delay { get; set; }
        public FieldType[] Fields { get; set; }
        public int Number { get; set; }

        public bool IsDone()
        {
            return !Fields.Any(x => x == FieldType.Unknown);
        }
    }
}
