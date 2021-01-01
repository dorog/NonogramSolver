
namespace Solver.Engine.Data
{
    public class Matrix<T>
    {
        public T[,] Fields { get; private set; }

        public Matrix(int rows, int columns)
        {
            Fields = new T[rows, columns];
        }

        public T[] GetMatrixRow(int index)
        {
            T[] row = new T[Fields.GetLength(1)];

            for (int i = 0; i < Fields.GetLength(0); i++)
            {
                row[i] = Fields[index, i];
            }

            return row;
        }

        public void SetMatrixRow(int index, T[] row, int delay = 0)
        {
            for (int i = delay; i < Fields.GetLength(1) && i < row.Length + delay; i++)
            {
                Fields[index, i] = row[i - delay];
            }
        }

        public T[] GetMatrixColumn(int index)
        {
            T[] column = new T[Fields.GetLength(0)];

            for (int i = 0; i < Fields.GetLength(1); i++)
            {
                column[i] = Fields[i, index];
            }

            return column;
        }

        public void SetMatrixColumn(int index, T[] column, int delay = 0)
        {
            for (int i = delay; i < Fields.GetLength(0) && i < column.Length + delay; i++)
            {
                Fields[i, index] = column[i - delay];
            }
        }
    }
}
