using System.Collections.Generic;

namespace Solver.Data
{
    public class Puzzle
    {
        public List<List<uint>> Columns { get; set; }
        public List<List<uint>> Rows { get; set; }
        public int[,] Matrix { get; set; }

        public int[] GetMatrixRow(int index)
        {
            int[] row = new int[Matrix.GetLength(1)];

            for(int i = 0; i < Matrix.GetLength(0); i++)
            {
                row[i] = Matrix[index, i];
            }

            return row;
        }

        public void SetMatrixRow(int index, int[] row, int delay = 0)
        {
            for (int i = delay; i < Matrix.GetLength(1) && i < row.Length; i++)
            {
                Matrix[index, i] = row[i];
            }
        }

        public int[] GetMatrixColumn(int index)
        {
            int[] column = new int[Matrix.GetLength(0)];

            for (int i = 0; i < Matrix.GetLength(1); i++)
            {
                column[i] = Matrix[i, index];
            }

            return column;
        }

        public void SetMatrixColumn(int index, int[] column, int delay = 0)
        {
            for (int i = delay; i < Matrix.GetLength(0) && i < column.Length; i++)
            {
                Matrix[i, index] = column[i];
            }
        }
    }
}
