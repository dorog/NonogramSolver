using Solver.Data;
using Solver.Engine.Data;
using Solver.Engine.Rules;
using Solver.Engine.Rules.Complex.Impl;
using Solver.Engine.Rules.Simple;
using Solver.Engine.Rules.Simple.Impl;
using Solver.Engine.Separators;
using Solver.Engine.Separators.Impl;
using System.Collections.Generic;
using System.Linq;

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

        private static readonly List<ISeparator> separators = new List<ISeparator>()
        {
            new TwoNumberDistanceSeparator(),
            new WallSeparator()
        };

        private static readonly List<NumberListRange> numberListRanges = new List<NumberListRange>();
        private static readonly List<NumberedRange> notDoneRanges = new List<NumberedRange>();

        public static Puzzle Solve(Puzzle puzzle)
        {
            numberListRanges.Clear();
            notDoneRanges.Clear();

            if (FinishedPuzzle(puzzle))
            {
                return puzzle;
            }

            CreateNumberListRanges(puzzle);

            ApplyComplexRuleOnThePuzzle(puzzle, new SummRule());

            //int maxStep = puzzle.Rows.Count * puzzle.Columns.Count;
            int maxStep = 2;
            int actualStep = 0;
            while (!FinishedPuzzle(puzzle) && actualStep <= maxStep)
            {
                ApplyComplexRules(puzzle);

                System.Console.WriteLine("DoneRanges: " + notDoneRanges.Count);
                foreach(var notDoneRange in notDoneRanges)
                {
                    System.Console.WriteLine("Type: " + notDoneRange.RangeType + ", " + "Index: " + notDoneRange.Index + ", Delay: " + notDoneRange.Delay + 
                        ", Fields: " + notDoneRange.Fields.Length + ", Number: " + notDoneRange.Number);
                    foreach(var field in notDoneRange.Fields)
                    {
                        System.Console.Write(field + ", ");
                    }
                    System.Console.WriteLine();
                }

                ApplySimpleRules(puzzle);

                System.Console.WriteLine("NextIter-----------------------------------");
                for (int i = 0; i < puzzle.Matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < puzzle.Matrix.GetLength(1); j++)
                    {
                        System.Console.Write((puzzle.Matrix[i, j] == 1) ? 'x' : '0');
                    }
                    System.Console.WriteLine("");
                }


                RefreshNumberedRanges(puzzle);

                RefreshNumberListRanges(puzzle);

                CalculateNumberedRanges();

                actualStep++;
            }

            return puzzle;
        }

        private static void CreateNumberListRanges(Puzzle puzzle)
        {
            for (int i = 0; i < puzzle.Matrix.GetLength(0); i++)
            {
                numberListRanges.Add(new NumberListRange()
                {
                    RangeType = RangeType.Row,
                    Index = i,
                    Delay = 0,
                    Fields = puzzle.GetMatrixRow(i),
                    Numbers = puzzle.Rows[i]
                });
            }

            for (int i = 0; i < puzzle.Matrix.GetLength(1); i++)
            {
                numberListRanges.Add(new NumberListRange()
                {
                    RangeType = RangeType.Column,
                    Index = i,
                    Delay = 0,
                    Fields = puzzle.GetMatrixColumn(i),
                    Numbers = puzzle.Columns[i]
                });
            }
        }

        private static void ApplyComplexRules(Puzzle puzzle)
        {
            foreach (var complexRule in complexRules)
            {
                ApplyComplexRuleOnThePuzzle(puzzle, complexRule);
            }
        }

        private static void ApplySimpleRules(Puzzle puzzle)
        {
            foreach (var notDoneRange in notDoneRanges)
            {
                /*System.Console.Write("Old fields: ");
                foreach (var field in notDoneRange.Fields)
                {
                    System.Console.Write(field + ", ");
                }
                System.Console.WriteLine();*/
                foreach (var simpleRule in simpleRules)
                {
                    notDoneRange.Fields = simpleRule.Check(notDoneRange.Number, notDoneRange.Fields);
                    /*System.Console.Write("New fields: " );
                    foreach (var field in notDoneRange.Fields)
                    {
                        System.Console.Write(field + ", ");
                    }
                    System.Console.WriteLine();*/
                }

                if (notDoneRange.RangeType == RangeType.Column)
                {
                    puzzle.SetMatrixColumn(notDoneRange.Index, notDoneRange.Fields, notDoneRange.Delay);
                }
                else
                {
                    puzzle.SetMatrixRow(notDoneRange.Index, notDoneRange.Fields, notDoneRange.Delay);
                }
            }
        }

        private static void RefreshNumberedRanges(Puzzle puzzle)
        {
            foreach(var numberedRange in notDoneRanges)
            {
                int[] fields = numberedRange.RangeType == RangeType.Column ? puzzle.GetMatrixColumn(numberedRange.Index) : puzzle.GetMatrixRow(numberedRange.Index);

                for(int i = 0; i < numberedRange.Fields.Length; i++)
                {
                    numberedRange.Fields[i] = fields[numberedRange.Delay + i];
                }
            }
        }

        private static void RefreshNumberListRanges(Puzzle puzzle)
        {
            foreach (var numberListRange in numberListRanges)
            {
                int[] fields = numberListRange.RangeType == RangeType.Column ? puzzle.GetMatrixColumn(numberListRange.Index) : puzzle.GetMatrixRow(numberListRange.Index);

                for (int i = 0; i < numberListRange.Fields.Length; i++)
                {
                    numberListRange.Fields[i] = fields[numberListRange.Delay + i];
                }
            }
        }

        private static void CalculateNumberedRanges()
        {
            List<NumberListRange> extraRanges = new List<NumberListRange>();
            List<int> separatedListIndexes = new List<int>();

            int index = 0;
            foreach(var numberListRange in numberListRanges)
            {
                int separatorId = 0;
                foreach(var separator in separators)
                {
                    separatorId++;
                    Range[] ranges = separator.Separate(numberListRange.Numbers, numberListRange.Fields);

                    List<uint> numbersInGroup = new List<uint>();
                    int delay = 0;
                    for(int i = 0; i < ranges.Length; i++)
                    {
                        if(ranges[i] == null)
                        {
                            numbersInGroup.Add(numberListRange.Numbers[i]);
                        }
                        else
                        {
                            if(numbersInGroup.Count > 0)
                            {
                                extraRanges.Add(new NumberListRange()
                                {
                                    RangeType = numberListRange.RangeType,
                                    Index = numberListRange.Index,
                                    Delay = delay,
                                    Fields = GetNumberedRangeFields(numberListRange, new Range() { Start = (uint)delay, End = ranges[i].Start - 1 }),
                                    Numbers = numbersInGroup
                                });
                            }

                            //System.Console.WriteLine("SepId: " + separatorId + ", F: " + GetNumberedRangeFields(numberListRange, ranges[i]).Length + ", Ranges: " + ranges[i].Start + "-" + ranges[i].End);
                            notDoneRanges.Add(new NumberedRange()
                            {
                                RangeType = numberListRange.RangeType,
                                Index = numberListRange.Index,
                                Delay = (int)(numberListRange.Delay + ranges[i].Start),
                                Fields = GetNumberedRangeFields(numberListRange, ranges[i]),
                                Number = numberListRange.Numbers[i]
                            });

                            delay += (int)ranges[i].End + 1;
                        }
                    }

                    if (numbersInGroup.Count > 0)
                    {
                        extraRanges.Add(new NumberListRange()
                        {
                            RangeType = numberListRange.RangeType,
                            Index = numberListRange.Index,
                            Delay = delay,
                            Fields = GetNumberedRangeFields(numberListRange, new Range() { Start = (uint)delay, End = (uint)(numberListRange.Fields.Length - 1) }),
                            Numbers = numbersInGroup
                        });
                    }

                    if(ranges.Any(x => x != null))
                    {
                        separatedListIndexes.Add(index);
                        break;
                    }
                }

                index++;
            }

            for(int i = separatedListIndexes.Count - 1; i >= 0; i--)
            {
                numberListRanges.RemoveAt(separatedListIndexes[i]);
            }
            numberListRanges.AddRange(extraRanges);

            notDoneRanges.RemoveAll(x => x.IsDone());
        }

        private static int[] GetNumberedRangeFields(NumberListRange numberListRange, Range range)
        {
            int[] fields = new int[range.End - range.Start + 1];

            for(int i = 0; i < fields.Length; i++)
            {
                fields[i] = numberListRange.Fields[range.Start + i];
            }

            return fields;
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
