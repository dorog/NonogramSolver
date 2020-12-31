using Solver.Engine.Data;
using System.Collections.Generic;

namespace Solver.Data
{
    public class Puzzle
    {
        public List<List<int>> Columns { get; set; }
        public List<List<int>> Rows { get; set; }
        public FieldType[,] Matrix { get; set; }

        public FieldType[] GetMatrixRow(int index)
        {
            FieldType[] row = new FieldType[Matrix.GetLength(1)];

            for(int i = 0; i < Matrix.GetLength(0); i++)
            {
                row[i] = Matrix[index, i];
            }

            return row;
        }

        public void SetMatrixRow(int index, FieldType[] row, int delay = 0)
        {
            for (int i = delay; i < Matrix.GetLength(1) && i < row.Length + delay; i++)
            {
                Matrix[index, i] = row[i - delay];
            }
        }

        public FieldType[] GetMatrixColumn(int index)
        {
            FieldType[] column = new FieldType[Matrix.GetLength(0)];

            for (int i = 0; i < Matrix.GetLength(1); i++)
            {
                column[i] = Matrix[i, index];
            }

            return column;
        }

        public void SetMatrixColumn(int index, FieldType[] column, int delay = 0)
        {
            for (int i = delay; i < Matrix.GetLength(0) && i < column.Length + delay; i++)
            {
                Matrix[i, index] = column[i - delay];
            }
        }
    }
}
