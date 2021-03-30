using SudokuSolverExampleCode.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuSolverExampleCode
{
    public class Solver
    {
        public void SolveLogical(SudokuModel sudokuModel)
        {
            PlaceNumbers(sudokuModel.Cells);
        }

        public void SolveGuessing(SudokuModel sudokuModel)
        {
            while (!CheckIfSolved(sudokuModel.Cells))
            {
                PlaceNumbers(sudokuModel.Cells);
                sudokuModel.Cells = GuessANumber(sudokuModel.Cells);
            }
        }

        private int[][] GuessANumber(int[][] cells)
        {
            throw new NotImplementedException();
        }

        private int[][] PlaceNumbers(int[][] sudokuCells)
        {
            bool placed;
            do
            {
                placed = false;

                for (int row = 0; row < 9; row++)
                {
                    for (int col = 0; col < 9; col++)
                    {
                        if (sudokuCells[row][col] == 0)
                        {
                            //List<int> numberlist = Enumerable.Range(1, 9).ToList();
                            List<int> numberlist = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

                            numberlist = numberchecker(sudokuCells, row, col, numberlist);

                            if (numberlist.Count == 1)
                            {
                                sudokuCells[row][col] = numberlist[0];
                                placed = true;
                                break;
                            }
                        }
                    }
                    if (placed)
                    {
                        break;
                    }
                }
            } while (placed);

            return sudokuCells;
        }

        private List<int> numberchecker(int[][] sudokuCells, int row, int colum, List<int> numberlist)
        {
            int corda = row - row % 3;
            int cordb = colum - colum % 3;

            for (int tempcolum = 0; tempcolum < 9; tempcolum++)
            {
                if (numberlist.Contains(sudokuCells[row][tempcolum]))
                {
                    numberlist.Remove(sudokuCells[row][tempcolum]);
                }
            }
            for (int tempRow = 0; tempRow < 9; tempRow++)
            {
                if (numberlist.Contains(sudokuCells[tempRow][colum]))
                {
                    numberlist.Remove(sudokuCells[tempRow][colum]);
                }
            }
            for (int i = corda; i < corda + 3; i++)
            {
                for (int j = cordb; j < cordb + 3; j++)
                {
                    if (numberlist.Contains(sudokuCells[i][j]))
                    {
                        numberlist.Remove(sudokuCells[i][j]);
                    }
                }
            }
            return numberlist;
        }

        private bool CheckIfSolved(int[][] sudoku)
        {
            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    if (sudoku[x][y] == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
