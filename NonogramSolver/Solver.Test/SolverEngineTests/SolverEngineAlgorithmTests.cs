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
                Rows = new List<List<uint>>()
                {
                    new List<uint>() { 2, 1 },
                    new List<uint>() { 1, 3 },
                    new List<uint>() { 1, 2 },
                    new List<uint>() { 3 },
                    new List<uint>() { 4 },
                    new List<uint>() { 1 }
                },
                Columns = new List<List<uint>>()
                {
                    new List<uint>() { 1 },
                    new List<uint>() { 5 },
                    new List<uint>() { 2 },
                    new List<uint>() { 5 },
                    new List<uint>() { 2, 1 },
                    new List<uint>() { 2 }
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
                Rows = new List<List<uint>>()
                {
                    new List<uint>() { 5 },
                    new List<uint>() { 5 },
                    new List<uint>() { 5 },
                    new List<uint>() { 3 },
                    new List<uint>() { 1 },
                },
                Columns = new List<List<uint>>()
                {
                    new List<uint>() { 3 },
                    new List<uint>() { 4 },
                    new List<uint>() { 5 },
                    new List<uint>() { 4 },
                    new List<uint>() { 3 },
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
                Rows = new List<List<uint>>()
                {
                    new List<uint>() { 6 },
                    new List<uint>() { 8 },
                    new List<uint>() { 10 },
                    new List<uint>() { 10 },
                    new List<uint>() { 8 },
                    new List<uint>() { 3, 1 },
                    new List<uint>() { 3 },
                    new List<uint>() { 1 },
                    new List<uint>() { 6 },
                    new List<uint>() { 4 },
                },
                Columns = new List<List<uint>>()
                {
                    new List<uint>() { 2 },
                    new List<uint>() { 4 },
                    new List<uint>() { 6, 1 },
                    new List<uint>() { 6, 2 },
                    new List<uint>() { 10 },
                    new List<uint>() { 5, 1, 2 },
                    new List<uint>() { 7, 2 },
                    new List<uint>() { 5, 1 },
                    new List<uint>() { 4 },
                    new List<uint>() { 2 },
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
                Rows = new List<List<uint>>()
                {
                    new List<uint>() { 7 },
                    new List<uint>() { 9 },
                    new List<uint>() { 2, 4, 2 },
                    new List<uint>() { 2, 2 },
                    new List<uint>() { 2, 1, 1, 2 },
                    new List<uint>() { 3, 2 },
                    new List<uint>() { 2, 2 },
                    new List<uint>() { 3, 3, 1 },
                    new List<uint>() { 9, 1 },
                    new List<uint>() { 9, 1 },
                    new List<uint>() { 11, 2 },
                    new List<uint>() { 15 },
                    new List<uint>() { 14 },
                    new List<uint>() { 2, 3, 2 },
                    new List<uint>() { 1, 1, 1, 1, 1, 1, 1 },
                },
                Columns = new List<List<uint>>()
                {
                    new List<uint>() { 4 },
                    new List<uint>() { 6, 4 },
                    new List<uint>() { 12, 1 },
                    new List<uint>() { 2, 1, 6 },
                    new List<uint>() { 2, 5, 1 },
                    new List<uint>() { 3, 1, 6 },
                    new List<uint>() { 3, 7 },
                    new List<uint>() { 3, 6 },
                    new List<uint>() { 3, 1, 5, 1 },
                    new List<uint>() { 2, 6 },
                    new List<uint>() { 12, 1 },
                    new List<uint>() { 6, 4 },
                    new List<uint>() { 4 },
                    new List<uint>() { 3 },
                    new List<uint>() { 5 },
                },
                Matrix = new int[15, 15]
            };
            int[,] matrixSolution = {
                { empty, empty, empty, empty, empty, empty, empty, empty, empty, empty, empty, empty, empty, empty, empty },
                { empty, empty, empty, empty, empty, empty, empty, empty, empty, empty, empty, empty, empty, empty, empty },
                { empty, empty, empty, empty, empty, empty, empty, empty, empty, empty, empty, empty, empty, empty, empty },
                { empty, empty, empty, empty, empty, empty, empty, empty, empty, empty, empty, empty, empty, empty, empty },
                { empty, empty, empty, empty, empty, empty, empty, empty, empty, empty, empty, empty, empty, empty, empty },
                { empty, empty, empty, empty, empty, empty, empty, empty, empty, empty, empty, empty, empty, empty, empty },
                { empty, empty, empty, empty, empty, empty, empty, empty, empty, empty, empty, empty, empty, empty, empty },
                { empty, empty, empty, empty, empty, empty, empty, empty, empty, empty, empty, empty, empty, empty, empty },
                { empty, empty, empty, empty, empty, empty, empty, empty, empty, empty, empty, empty, empty, empty, empty },
                { empty, empty, empty, empty, empty, empty, empty, empty, empty, empty, empty, empty, empty, empty, empty },
                { empty, empty, empty, empty, empty, empty, empty, empty, empty, empty, empty, empty, empty, empty, empty },
                { empty, empty, empty, empty, empty, empty, empty, empty, empty, empty, empty, empty, empty, empty, empty },
                { empty, empty, empty, empty, empty, empty, empty, empty, empty, empty, empty, empty, empty, empty, empty },
                { empty, empty, empty, empty, empty, empty, empty, empty, empty, empty, empty, empty, empty, empty, empty },
                { empty, empty, empty, empty, empty, empty, empty, empty, empty, empty, empty, empty, empty, empty, empty },
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
