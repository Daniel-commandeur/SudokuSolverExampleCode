using SudokuSolverExampleCode.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuSolverExampleCode
{
    public static class SudokuData
    {
        public static IEnumerable<SudokuModel> GetMockData()
        {
            List<SudokuModel> sudokuList = new List<SudokuModel>
                {
                new SudokuModel
                {
                    SudokuId = 0,
                    Name = "Logical",
                    Cells = new int[][]
                    {
                        new int[9] { 5, 3, 0, 0, 7, 0, 0, 0, 0 },
                        new int[9] { 6, 0, 0, 1, 9, 5, 0, 0, 0 },
                        new int[9] { 0, 9, 8, 0, 0, 0, 0, 6, 0 },
                        new int[9] { 8, 0, 0, 0, 6, 0, 0, 0, 3 },
                        new int[9] { 4, 0, 0, 8, 0, 3, 0, 0, 1 },
                        new int[9] { 7, 0, 0, 0, 2, 0, 0, 0, 6 },
                        new int[9] { 0, 6, 0, 0, 0, 0, 2, 8, 0 },
                        new int[9] { 0, 0, 0, 4, 1, 9, 0, 0, 5 },
                        new int[9] { 0, 0, 0, 0, 8, 0, 0, 7, 9 }
                    }
                },
                new SudokuModel
                {
                    SudokuId = 1,
                    Name = "Guessing",
                    Cells = new int[][]
                    {
                        new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                        new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                        new int[9] { 0, 9, 8, 0, 0, 0, 0, 6, 0 },
                        new int[9] { 8, 0, 0, 0, 6, 0, 0, 0, 0 },
                        new int[9] { 0, 0, 0, 8, 0, 0, 0, 0, 0 },
                        new int[9] { 7, 0, 0, 0, 2, 0, 0, 0, 0 },
                        new int[9] { 0, 6, 0, 0, 0, 0, 0, 0, 0 },
                        new int[9] { 0, 0, 0, 4, 1, 9, 0, 0, 0 },
                        new int[9] { 0, 0, 0, 0, 8, 0, 0, 0, 0 }
                    }
                },
                new SudokuModel
                {
                    SudokuId = 2,
                    Name = "Empty",
                    Cells = new int[][]
                    {
                        new int[9],
                        new int[9],
                        new int[9],
                        new int[9],
                        new int[9],
                        new int[9],
                        new int[9],
                        new int[9],
                        new int[9]
                    }
                },
                new SudokuModel
                {
                    SudokuId = 3,
                    Name = "Solve Hardest",
                    Cells = new int[][]
                    {
                        new int[9] { 8, 0, 0, 0, 0, 0, 0, 0, 0 },
                        new int[9] { 0, 0, 3, 6, 0, 0, 0, 0, 0 },
                        new int[9] { 0, 7, 0, 0, 9, 0, 2, 0, 0 },
                        new int[9] { 0, 5, 0, 0, 0, 7, 0, 0, 0 },
                        new int[9] { 0, 0, 0, 0, 4, 5, 7, 0, 0 },
                        new int[9] { 0, 0, 0, 1, 0, 0, 0, 3, 0 },
                        new int[9] { 0, 0, 1, 0, 0, 0, 0, 6, 8 },
                        new int[9] { 0, 0, 8, 5, 0, 0, 0, 1, 0 },
                        new int[9] { 0, 9, 0, 0, 0, 0, 4, 0, 0 }
                    }
                }
            };
            return sudokuList;
        }
    }
}
