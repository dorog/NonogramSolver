using System;

namespace Solver.Engine.Data
{
    public class Range
    {
        public bool Done { get; set; } = false;
        public uint Start { get; set; }
        public uint End { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Range range &&
                   Done == range.Done &&
                   Start == range.Start &&
                   End == range.End;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Done, Start, End);
        }
    }
}
