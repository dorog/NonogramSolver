using System;

namespace Solver.Engine.Data
{
    public class Range
    {
        public int Start { get; set; }
        public int End { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Range range &&
                   Start == range.Start &&
                   End == range.End;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Start, End);
        }
    }
}
