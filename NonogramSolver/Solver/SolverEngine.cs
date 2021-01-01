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
            new CompletedLineRule(),
            new TooSmallSpaceRule()
        };

        private static readonly List<ISimpleRule> simpleRules = new List<ISimpleRule>()
        {
            new MergeRule(),
            new MoreThanHalfRule(),
            new UnreachableRule(),
            new WallRule(),
            new NotEnoughSpaceRule()
        };

        private static readonly List<ISeparator> separators = new List<ISeparator>()
        {
            new TwoNumberDistanceSeparator(),
            new WallSeparator(),
            new OnlyOneNumberSeparator(),
            new EndSeparator(),
            new HoleNumberSeparator()
        };

        private static readonly List<NumberListRange> numberListRanges = new List<NumberListRange>();
        private static readonly List<NumberedRange> notDoneRanges = new List<NumberedRange>();

        public static Puzzle Solve(Puzzle puzzle)
        {
            numberListRanges.Clear();
            notDoneRanges.Clear();

            if (puzzle.FinishedPuzzle())
            {
                return puzzle;
            }

            CreateNumberListRanges(puzzle);

            ApplyComplexRuleOnThePuzzle(puzzle, new SummRule());

            int maxStep = puzzle.Rows.Count * puzzle.Columns.Count;
            int actualStep = 0;
            while (!puzzle.FinishedPuzzle() && actualStep <= maxStep)
            {
                ApplyComplexRules(puzzle);

                ApplySimpleRules(puzzle);

                RefreshNumberListRanges(puzzle);

                CutUnnecessaryNumberedRangesEnds();

                CutUnnecessaryNumberListRangesEnds();

                CalculateNumberedRanges();

                actualStep++;
            }

            return puzzle;
        }

        private static void CreateNumberListRanges(Puzzle puzzle)
        {
            foreach(var row in puzzle.GetRowLines())
            {
                numberListRanges.Add(new NumberListRange()
                {
                    RangeType = RangeType.Row,
                    Index = row.Index,
                    Delay = 0,
                    Fields = row.Fields,
                    Numbers = row.Numbers
                });
            }

            foreach(var column in puzzle.GetColumnLines())
            {
                numberListRanges.Add(new NumberListRange()
                {
                    RangeType = RangeType.Column,
                    Index = column.Index,
                    Delay = 0,
                    Fields = column.Fields,
                    Numbers = column.Numbers
                });
            }
        }

        private static void ApplyComplexRules(Puzzle puzzle)
        {
            foreach (var complexRule in complexRules)
            {
                ApplyComplexRuleOnThePuzzle(puzzle, complexRule);
            }

            RefreshNumberedRanges(puzzle);
            RefreshNumberListRanges(puzzle);
        }

        private static void ApplySimpleRules(Puzzle puzzle)
        {
            foreach (var notDoneRange in notDoneRanges)
            {
                FieldType[] originalFields = CopyFields(notDoneRange.Fields);

                foreach (var simpleRule in simpleRules)
                {
                    var result = simpleRule.Apply(notDoneRange.Number, notDoneRange.Fields);
                    if (IsChanged(originalFields, result))
                    {
                        notDoneRange.Fields = result;

                        if (notDoneRange.RangeType == RangeType.Column)
                        {
                            puzzle.Matrix.SetMatrixColumn(notDoneRange.Index, notDoneRange.Fields, notDoneRange.Delay);
                        }
                        else
                        {
                            puzzle.Matrix.SetMatrixRow(notDoneRange.Index, notDoneRange.Fields, notDoneRange.Delay);
                        }

                        RefreshNumberedRanges(puzzle);
                        break;
                    }
                }
            }
        }

        private static FieldType[] CopyFields(FieldType[] fields)
        {
            FieldType[] copy = new FieldType[fields.Length];
            for(int i = 0; i < fields.Length; i++)
            {
                copy[i] = fields[i];
            }

            return copy;
        }

        private static bool IsChanged(FieldType[] original, FieldType[] result)
        {
            for (int i = 0; i < original.Length; i++)
            {
                if(original[i] != result[i])
                {
                    return true;
                }
            }

            return false;
        }

        private static void RefreshNumberedRanges(Puzzle puzzle)
        {
            foreach(var numberedRange in notDoneRanges)
            {
                FieldType[] fields = numberedRange.RangeType == RangeType.Column ? puzzle.Matrix.GetMatrixColumn(numberedRange.Index) : puzzle.Matrix.GetMatrixRow(numberedRange.Index);

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
                FieldType[] fields = numberListRange.RangeType == RangeType.Column ? puzzle.Matrix.GetMatrixColumn(numberListRange.Index) : puzzle.Matrix.GetMatrixRow(numberListRange.Index);

                for (int i = 0; i < numberListRange.Fields.Length; i++)
                {
                    numberListRange.Fields[i] = fields[numberListRange.Delay + i];
                }
            }
        }

        private static void CutUnnecessaryNumberedRangesEnds()
        {
            foreach(var numberedRange in notDoneRanges)
            {
                int minPosition = 0;
                while(minPosition < numberedRange.Fields.Length && numberedRange.Fields[minPosition] == FieldType.White)
                {
                    minPosition++;
                }

                int maxPosition = numberedRange.Fields.Length - 1;
                while (maxPosition >= 0 && numberedRange.Fields[maxPosition] == FieldType.White)
                {
                    maxPosition--;
                }

                FieldType[] cutFields = new FieldType[maxPosition - minPosition + 1];
                for(int i = minPosition; i <= maxPosition; i++)
                {
                    cutFields[i - minPosition] = numberedRange.Fields[i];
                }

                numberedRange.Delay += minPosition;
                numberedRange.Fields = cutFields;
            }
        }

        private static void CutUnnecessaryNumberListRangesEnds()
        {
            foreach (var numberListRange in numberListRanges)
            {
                int minPosition = 0;
                while (minPosition < numberListRange.Fields.Length && numberListRange.Fields[minPosition] == FieldType.White)
                {
                    minPosition++;
                }

                int maxPosition = numberListRange.Fields.Length - 1;
                while (maxPosition >= 0 && numberListRange.Fields[maxPosition] == FieldType.White)
                {
                    maxPosition--;
                }

                FieldType[] cutFields = new FieldType[maxPosition - minPosition + 1];
                for (int i = minPosition; i <= maxPosition; i++)
                {
                    cutFields[i - minPosition] = numberListRange.Fields[i];
                }

                numberListRange.Delay += minPosition;
                numberListRange.Fields = cutFields;
            }
        }

        private static void CalculateNumberedRanges()
        {
            List<NumberListRange> extraRanges = new List<NumberListRange>();
            List<int> separatedListIndexes = new List<int>();

            int index = 0;
            foreach(var numberListRange in numberListRanges)
            {
                foreach (var separator in separators)
                {
                    Range[] ranges = separator.Separate(numberListRange.Numbers, numberListRange.Fields);

                    if(ranges.Any(x => x != null))
                    {
                        separatedListIndexes.Add(index);

                        List<int> numbersInGroup = new List<int>();
                        int delay = 0;

                        for (int i = 0; i < ranges.Length; i++)
                        {
                            if (ranges[i] == null)
                            {
                                numbersInGroup.Add(numberListRange.Numbers[i]);
                            }
                            else
                            {
                                if (numbersInGroup.Count > 0)
                                {
                                    extraRanges.Add(new NumberListRange()
                                    {
                                        RangeType = numberListRange.RangeType,
                                        Index = numberListRange.Index,
                                        Delay = delay + numberListRange.Delay,
                                        Fields = GetNumberedRangeFields(numberListRange, new Range() { Start = delay, End = ranges[i].Start - 1 }),
                                        Numbers = numbersInGroup.ToList()
                                    });

                                    numbersInGroup.Clear();
                                }

                                notDoneRanges.Add(new NumberedRange()
                                {
                                    RangeType = numberListRange.RangeType,
                                    Index = numberListRange.Index,
                                    Delay = (numberListRange.Delay + ranges[i].Start),
                                    Fields = GetNumberedRangeFields(numberListRange, ranges[i]),
                                    Number = numberListRange.Numbers[i]
                                });

                                delay += ranges[i].End + 1;
                            }
                        }

                        if (numbersInGroup.Count > 0)
                        {
                            extraRanges.Add(new NumberListRange()
                            {
                                RangeType = numberListRange.RangeType,
                                Index = numberListRange.Index,
                                Delay = delay + numberListRange.Delay,
                                Fields = GetNumberedRangeFields(numberListRange, new Range() { Start = delay, End = (numberListRange.Fields.Length - 1) }),
                                Numbers = numbersInGroup
                            });

                        }

                        break;
                    }
                }

                index++;
            }

            for (int i = separatedListIndexes.Count - 1; i >= 0; i--)
            {
                numberListRanges.RemoveAt(separatedListIndexes[i]);
            }

            numberListRanges.AddRange(extraRanges);

            notDoneRanges.RemoveAll(x => x.IsDone());
        }

        private static FieldType[] GetNumberedRangeFields(NumberListRange numberListRange, Range range)
        {
            FieldType[] fields = new FieldType[range.End - range.Start + 1];

            for(int i = 0; i < fields.Length; i++)
            {
                fields[i] = numberListRange.Fields[range.Start + i];
            }

            return fields;
        }

        private static void ApplyComplexRuleOnThePuzzle(Puzzle puzzle, IComplexRule complexRule)
        {
            foreach(var row in puzzle.GetRowLines())
            {
                var calculatedRow = complexRule.Apply(row.Numbers, row.Fields);
                puzzle.Matrix.SetMatrixRow(row.Index, calculatedRow);
            }

            foreach (var column in puzzle.GetColumnLines())
            {
                var calculatedRow = complexRule.Apply(column.Numbers, column.Fields);
                puzzle.Matrix.SetMatrixColumn(column.Index, calculatedRow);
            }
        }
    }
}
