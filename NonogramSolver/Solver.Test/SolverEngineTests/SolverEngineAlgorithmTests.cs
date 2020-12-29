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
        public void OneNumberRangeTest()
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

            Assert.AreEqual(matrixSolution.GetLength(0), solvedPuzzleMatrix.GetLength(0));
            Assert.AreEqual(matrixSolution.GetLength(1), solvedPuzzleMatrix.GetLength(1));

            for(int i = 0; i < matrixSolution.GetLength(0); i++)
            {
                for (int j = 0; j < matrixSolution.GetLength(1); j++)
                {
                    Assert.AreEqual(matrixSolution[i, j], solvedPuzzleMatrix[i, j]);
                }
            }
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

            Assert.AreEqual(matrixSolution.GetLength(0), solvedPuzzleMatrix.GetLength(0), "Diff Lengths: Rows");
            Assert.AreEqual(matrixSolution.GetLength(1), solvedPuzzleMatrix.GetLength(1), "Diff Lengths: Columns");

            for (int i = 0; i < matrixSolution.GetLength(0); i++)
            {
                for (int j = 0; j < matrixSolution.GetLength(1); j++)
                {
                    Assert.AreEqual(matrixSolution[i, j], solvedPuzzleMatrix[i, j], "Matrix Value diff: " + "[" + i + ", " + j+ "]");
                }
            }
        }
    }
}
