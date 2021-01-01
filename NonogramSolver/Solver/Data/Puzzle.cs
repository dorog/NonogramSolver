using Solver.Engine.Data;
using Solver.Engine.Rules;
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

        public List<PuzzleLine> GetRowLines()
        {
            List<PuzzleLine> rows = new List<PuzzleLine>();

            for (int i = 0; i < Columns.Count; i++)
            {
                rows.Add(GetRowLine(i));
            }

            return rows;
        }

        private PuzzleLine GetRowLine(int index)
        {
            PuzzleLine puzzleLine = new PuzzleLine()
            {
                Type = Type.Row,
                Index = index,
                Numbers = Rows[index],
                Fields = Matrix.GetMatrixRow(index)
            };

            return puzzleLine;
        }

        public List<PuzzleLine> GetColumnLines()
        {
            List<PuzzleLine> columns = new List<PuzzleLine>();

            for(int i = 0; i < Columns.Count; i++)
            {
                columns.Add(GetColumnLine(i));
            }

            return columns;
        }

        private PuzzleLine GetColumnLine(int index)
        {
            PuzzleLine puzzleLine = new PuzzleLine()
            {
                Type = Type.Column,
                Index = index,
                Numbers = Columns[index],
                Fields = Matrix.GetMatrixColumn(index)
            };

            return puzzleLine;
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

        public void ApplyComplexRule(IComplexRule complexRule)
        {
            foreach (var row in GetRowLines())
            {
                var calculatedRow = complexRule.Apply(row.Numbers, row.Fields);
                Matrix.SetMatrixRow(row.Index, calculatedRow);
            }

            foreach (var column in GetColumnLines())
            {
                var calculatedRow = complexRule.Apply(column.Numbers, column.Fields);
                Matrix.SetMatrixColumn(column.Index, calculatedRow);
            }
        }


    }
}
