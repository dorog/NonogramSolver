using Solver.Data;
using Solver.Engine.Rules;
using Solver.Engine.Rules.Complex.Impl;
using Solver.Engine.Rules.Simple;
using Solver.Engine.Rules.Simple.Impl;
using System.Collections.Generic;

namespace Solver.Engine
{
    public static class SolverEngine
    {
        private static readonly List<IComplexRule> complexRules = new List<IComplexRule>()
        {
            new DoneRule()
        };

        private static readonly List<ISimpleRule> simpleRules = new List<ISimpleRule>()
        {
            new MergeRule(),
            new MoreThanHalfRule(),
            new UnreachableRule(),
        };

        public static Puzzle Solve(Puzzle puzzle)
        {
            if (FinishedPuzzle(puzzle))
            {
                return puzzle;
            }

            ApplyComplexRuleOnThePuzzle(puzzle, new SummRule());

            while (!FinishedPuzzle(puzzle))
            {
                foreach(var complexRule in complexRules)
                {
                    ApplyComplexRuleOnThePuzzle(puzzle, complexRule);
                }
            }

            return puzzle;
        }

        private static bool FinishedPuzzle(Puzzle puzzle)
        {
            for(int i = 0; i < puzzle.Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < puzzle.Matrix.GetLength(1); j++)
                {
                    if (puzzle.Matrix[i, j] == 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private static void ApplyComplexRuleOnThePuzzle(Puzzle puzzle, IComplexRule complexRule)
        {
            for (int i = 0; i < puzzle.Matrix.GetLength(0); i++)
            {
                int[] actualRow = puzzle.GetMatrixRow(i);
                int[] calculatedRow = complexRule.Check(puzzle.Rows[i], actualRow);
                puzzle.SetMatrixRow(i, calculatedRow);
            }

            for (int i = 0; i < puzzle.Matrix.GetLength(1); i++)
            {
                int[] actualColumn = puzzle.GetMatrixColumn(i);
                int[] calculatedRow = complexRule.Check(puzzle.Columns[i], actualColumn);
                puzzle.SetMatrixColumn(i, calculatedRow);
            }
        }
    }
}
