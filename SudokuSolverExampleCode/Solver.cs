using SudokuSolverExampleCode.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SudokuSolverExampleCode
{
    public class Solver
    {
        private List<int> GetAllNumbers 
        { 
            get { return Enumerable.Range(1, 9).ToList(); } 
        }

        public void SolveLogical(SudokuModel sudokuModel)
        {
            PlaceNumbers(sudokuModel.Cells);
        }

        public void SolveGuessing(SudokuModel sudokuModel)
        {
            PlaceNumbers(sudokuModel.Cells);

            SudokuBackupModel backup = new SudokuBackupModel
            {
                BackupCells = CopyArray(sudokuModel.Cells)
            };

            while (!CheckIfSolved(sudokuModel.Cells))
            {
                while (!CheckIfStuck(sudokuModel.Cells))
                {
                    sudokuModel.Cells = GuessANumber(sudokuModel);
                    //Program.PrintSudoku(sudokuModel.Cells);
                    sudokuModel.Cells = PlaceNumbers(sudokuModel.Cells);
                    if (CheckIfSolved(sudokuModel.Cells))
                    {
                        return;
                    }
                }
                sudokuModel.Cells = CopyArray(backup.BackupCells);
            }

        }

        private int[][] GuessANumber(SudokuModel sudokuModel)
        {
            var rnd = new Random();

            for (int i = 2; i < 10;)
            {
                sudokuModel.Coord = FindLocation(sudokuModel.Cells, sudokuModel.Coord);
                List<int> possibleNumbers = Numberchecker(sudokuModel.Cells, sudokuModel.Coord);

                if (possibleNumbers.Count == i)
                {
                    sudokuModel.Cells[sudokuModel.Coord.Row][sudokuModel.Coord.Col] = possibleNumbers[rnd.Next(possibleNumbers.Count)];

                    return sudokuModel.Cells;
                }
                else
                {
                    sudokuModel.Coord = NextCoordinate(sudokuModel.Coord);

                    if (sudokuModel.Coord.Row == 0 && sudokuModel.Coord.Col == 0)
                    {
                        i++;
                    }
                }
            }
            return sudokuModel.Cells;
        }

        private Coordinate NextCoordinate(Coordinate coord)
        {
            coord.Col = (coord.Col + 1) % 9;
            if (coord.Col == 0)
            {
                coord.Row = (coord.Row + 1) % 9;
            }
            return coord;
        }

        private Coordinate FindLocation(int[][] cells, Coordinate coord)
        {
            for (int row = coord.Row; row < 9; row++)
            {
                for (int col = coord.Col; col < 9; col++)
                {
                    if (cells[row][col] == 0)
                    {
                        coord.Row = row;
                        coord.Col = col;
                        return coord;
                    }
                }
            }
            return coord;
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
                            List<int> numberlist = Numberchecker(sudokuCells, new Coordinate {Row = row, Col = col });

                            if (numberlist.Count == 1)
                            {
                                sudokuCells[row][col] = numberlist[0];
                                placed = true;
                                //Program.PrintSudoku(sudokuCells);
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

        private List<int> Numberchecker(int[][] sudokuCells, Coordinate coord)
        {
            List<int> numberlist = GetAllNumbers;
            int corda = coord.Row - coord.Row % 3;
            int cordb = coord.Col - coord.Col % 3;

            for (int tempcolum = 0; tempcolum < 9; tempcolum++)
            {
                if (numberlist.Contains(sudokuCells[coord.Row][tempcolum]))
                {
                    numberlist.Remove(sudokuCells[coord.Row][tempcolum]);
                }
            }
            for (int tempRow = 0; tempRow < 9; tempRow++)
            {
                if (numberlist.Contains(sudokuCells[tempRow][coord.Col]))
                {
                    numberlist.Remove(sudokuCells[tempRow][coord.Col]);
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

        private bool CheckIfStuck(int[][] sudoku)
        {
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    if (sudoku[row][col] == 0)
                    {
                        List<int> numberlist = Numberchecker(sudoku, new Coordinate { Row = row, Col = col });
                        if (numberlist.Count == 0)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private int[][] CopyArray(int[][] source)
        {
            return source.Select(s => s.ToArray()).ToArray();
        }

    }
}
