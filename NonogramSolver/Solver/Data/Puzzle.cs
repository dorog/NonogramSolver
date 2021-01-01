using Solver.Engine.Data;
using System.Collections.Generic;

namespace Solver.Data
{
    public class Puzzle
    {
        public List<List<int>> Rows { get; private set; }
        public List<List<int>> Columns { get; private set; }
        public Matrix<FieldType> Matrix { get; private set; }

        public Puzzle(List<List<int>> Rows, List<List<int>> Columns)
        {
            this.Rows = Rows;
            this.Columns = Columns;

            Matrix = new Matrix<FieldType>(Rows.Count, Columns.Count);
        }

        public bool FinishedPuzzle()
        {
            for (int i = 0; i < Matrix.Fields.GetLength(0); i++)
            {
                for (int j = 0; j < Matrix.Fields.GetLength(1); j++)
                {
                    if (Matrix.Fields[i, j] == FieldType.Unknown)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
