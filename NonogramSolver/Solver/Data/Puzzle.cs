using System.Collections.Generic;

namespace Solver.Data
{
    public class Puzzle
    {
        public List<List<uint>> Columns { get; set; }
        public List<List<uint>> Rows { get; set; }
        public int[,] Matrix { get; set; }
    }
}
