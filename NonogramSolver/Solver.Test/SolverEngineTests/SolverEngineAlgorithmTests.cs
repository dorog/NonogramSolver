using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solver.Data;
using Solver.Engine;
using System.Collections.Generic;

namespace Solver.Test.SolverEngineTests
{
    [TestClass]
    public class SolverEngineAlgorithmTests
    {
        private static readonly int solid = 1;
        private static readonly int empty = -1;

        [TestMethod]
        public void BirdNonogramTest()
        {
            Puzzle puzzle = new Puzzle()
            {
                Rows = new List<List<int>>()
                {
                    new List<int>() { 2, 1 },
                    new List<int>() { 1, 3 },
                    new List<int>() { 1, 2 },
                    new List<int>() { 3 },
                    new List<int>() { 4 },
                    new List<int>() { 1 }
                },
                Columns = new List<List<int>>()
                {
                    new List<int>() { 1 },
                    new List<int>() { 5 },
                    new List<int>() { 2 },
                    new List<int>() { 5 },
                    new List<int>() { 2, 1 },
                    new List<int>() { 2 }
                },
                Matrix = new int[6, 6]
            };
            int[,] matrixSolution = { 
                { solid, solid, empty, empty, empty, solid},
                { empty, solid, empty, solid, solid, solid },
                { empty, solid, empty, solid, solid, empty },
                { empty, solid, solid, solid, empty, empty },
                { empty, solid, solid, solid, solid, empty },
                { empty, empty, empty, solid, empty, empty},
            };

            var solvedPuzzle = SolverEngine.Solve(puzzle);

            var solvedPuzzleMatrix = solvedPuzzle.Matrix;

            TestResult(matrixSolution, solvedPuzzleMatrix);
        }

        [TestMethod]
        public void RoseNonogramTest()
        {
            Puzzle puzzle = new Puzzle()
            {
                Rows = new List<List<int>>()
                {
                    new List<int>() { 5 },
                    new List<int>() { 5 },
                    new List<int>() { 5 },
                    new List<int>() { 3 },
                    new List<int>() { 1 },
                },
                Columns = new List<List<int>>()
                {
                    new List<int>() { 3 },
                    new List<int>() { 4 },
                    new List<int>() { 5 },
                    new List<int>() { 4 },
                    new List<int>() { 3 },
                },
                Matrix = new int[5, 5]
            };
            int[,] matrixSolution = {
                { solid, solid, solid, solid, solid },
                { solid, solid, solid, solid, solid },
                { solid, solid, solid, solid, solid },
                { empty, solid, solid, solid, empty },
                { empty, empty, solid, empty, empty },
            };

            var solvedPuzzle = SolverEngine.Solve(puzzle);

            var solvedPuzzleMatrix = solvedPuzzle.Matrix;

            TestResult(matrixSolution, solvedPuzzleMatrix);
        }

        [TestMethod]
        public void BonsaiNonogramTest()
        {
            Puzzle puzzle = new Puzzle()
            {
                Rows = new List<List<int>>()
                {
                    new List<int>() { 6 },
                    new List<int>() { 8 },
                    new List<int>() { 10 },
                    new List<int>() { 10 },
                    new List<int>() { 8 },
                    new List<int>() { 3, 1 },
                    new List<int>() { 3 },
                    new List<int>() { 1 },
                    new List<int>() { 6 },
                    new List<int>() { 4 },
                },
                Columns = new List<List<int>>()
                {
                    new List<int>() { 2 },
                    new List<int>() { 4 },
                    new List<int>() { 6, 1 },
                    new List<int>() { 6, 2 },
                    new List<int>() { 10 },
                    new List<int>() { 5, 1, 2 },
                    new List<int>() { 7, 2 },
                    new List<int>() { 5, 1 },
                    new List<int>() { 4 },
                    new List<int>() { 2 },
                },
                Matrix = new int[10, 10]
            };
            int[,] matrixSolution = {
                { empty, empty, solid, solid, solid, solid, solid, solid, empty, empty },
                { empty, solid, solid, solid, solid, solid, solid, solid, solid, empty },
                { solid, solid, solid, solid, solid, solid, solid, solid, solid, solid },
                { solid, solid, solid, solid, solid, solid, solid, solid, solid, solid },
                { empty, solid, solid, solid, solid, solid, solid, solid, solid, empty },
                { empty, empty, solid, solid, solid, empty, solid, empty, empty, empty },
                { empty, empty, empty, empty, solid, solid, solid, empty, empty, empty },
                { empty, empty, empty, empty, solid, empty, empty, empty, empty, empty },
                { empty, empty, solid, solid, solid, solid, solid, solid, empty, empty },
                { empty, empty, empty, solid, solid, solid, solid, empty, empty, empty },
            };

            var solvedPuzzle = SolverEngine.Solve(puzzle);

            var solvedPuzzleMatrix = solvedPuzzle.Matrix;

            TestResult(matrixSolution, solvedPuzzleMatrix);
        }

        [TestMethod]
        public void LionNonogramTest()
        {
            Puzzle puzzle = new Puzzle()
            {
                Rows = new List<List<int>>()
                {
                    new List<int>() { 7 },
                    new List<int>() { 9 },
                    new List<int>() { 2, 4, 2 },
                    new List<int>() { 2, 2 },
                    new List<int>() { 2, 1, 1, 2 },
                    new List<int>() { 3, 2 },
                    new List<int>() { 2, 2 },
                    new List<int>() { 3, 3, 1 },
                    new List<int>() { 9, 1 },
                    new List<int>() { 9, 1 },
                    new List<int>() { 11, 2 },
                    new List<int>() { 15 },
                    new List<int>() { 14 },
                    new List<int>() { 2, 3, 2 },
                    new List<int>() { 1, 1, 1, 1, 1, 1, 1 },
                },
                Columns = new List<List<int>>()
                {
                    new List<int>() { 4 },
                    new List<int>() { 6, 4 },
                    new List<int>() { 12, 1 },
                    new List<int>() { 2, 1, 6 },
                    new List<int>() { 2, 5, 1 },
                    new List<int>() { 3, 1, 6 },
                    new List<int>() { 3, 7 },
                    new List<int>() { 3, 6 },
                    new List<int>() { 3, 1, 5, 1 },
                    new List<int>() { 2, 6 },
                    new List<int>() { 12, 1 },
                    new List<int>() { 6, 4 },
                    new List<int>() { 4 },
                    new List<int>() { 3 },
                    new List<int>() { 5 },
                },
                Matrix = new int[15, 15]
            };
            int[,] matrixSolution = {
                { empty, empty, empty, solid, solid, solid, solid, solid, solid, solid, empty, empty, empty, empty, empty },
                { empty, empty, solid, solid, solid, solid, solid, solid, solid, solid, solid, empty, empty, empty, empty },
                { empty, solid, solid, empty, empty, solid, solid, solid, solid, empty, solid, solid, empty, empty, empty },
                { empty, solid, solid, empty, empty, empty, empty, empty, empty, empty, solid, solid, empty, empty, empty },
                { empty, solid, solid, empty, empty, solid, empty, empty, solid, empty, solid, solid, empty, empty, empty },
                { empty, solid, solid, solid, empty, empty, empty, empty, empty, empty, solid, solid, empty, empty, empty },
                { empty, solid, solid, empty, empty, empty, empty, empty, empty, empty, solid, solid, empty, empty, empty },
                { empty, solid, solid, solid, empty, empty, empty, empty, empty, solid, solid, solid, empty, empty, solid },
                { empty, empty, solid, solid, solid, solid, solid, solid, solid, solid, solid, empty, empty, empty, solid },
                { empty, empty, solid, solid, solid, solid, solid, solid, solid, solid, solid, empty, empty, empty, solid },
                { empty, solid, solid, solid, solid, solid, solid, solid, solid, solid, solid, solid, empty, solid, solid },
                { solid, solid, solid, solid, solid, solid, solid, solid, solid, solid, solid, solid, solid, solid, solid },
                { solid, solid, solid, solid, solid, solid, solid, solid, solid, solid, solid, solid, solid, solid, empty },
                { solid, solid, empty, empty, empty, solid, solid, solid, empty, empty, empty, solid, solid, empty, empty },
                { solid, empty, solid, empty, solid, empty, solid, empty, solid, empty, solid, empty, solid, empty, empty },
            };

            var solvedPuzzle = SolverEngine.Solve(puzzle);

            var solvedPuzzleMatrix = solvedPuzzle.Matrix;

            TestResult(matrixSolution, solvedPuzzleMatrix);
        }

        private void TestResult(int[,] solution, int[,] solved)
        {
            Assert.AreEqual(solution.GetLength(0), solved.GetLength(0), "Diff Lengths: Rows");
            Assert.AreEqual(solution.GetLength(1), solved.GetLength(1), "Diff Lengths: Columns");

            for (int i = 0; i < solution.GetLength(0); i++)
            {
                for (int j = 0; j < solution.GetLength(1); j++)
                {
                    Assert.AreEqual(solution[i, j], solved[i, j], "Matrix Value diff: " + "[" + i + ", " + j + "]");
                }
            }
        }
    }
}
