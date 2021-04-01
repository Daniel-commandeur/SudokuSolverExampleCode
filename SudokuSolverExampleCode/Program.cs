using SudokuSolverExampleCode.Models;
using System;
using System.Collections.Generic;

namespace SudokuSolverExampleCode
{
    class Program
    {
        static void Main(string[] args)
        {
            List<SudokuModel> listSudokus = (List<SudokuModel>)SudokuData.GetMockData();
            var sudoku = listSudokus.Find(s => s.SudokuId.Equals(2));

            Solver solver = new Solver();
            solver.SolveGuessing(sudoku);
            PrintSudoku(sudoku.Cells);
            Console.ReadKey();
        }

        public static void ShowModulus()
        {
            int aantal = -8;
            Console.WriteLine("int aantal = -8;");
            Console.ReadKey();
            int deler = 3;
            Console.WriteLine("int deler = 3;");
            Console.ReadKey();
            int x = aantal / deler;
            Console.WriteLine("int x = aantal / deler;");
            Console.ReadKey();
            Console.WriteLine("x = ?");
            Console.ReadKey();
            Console.WriteLine($"x = {x}");
            Console.ReadKey();
            Console.WriteLine("Nu vermenigvuldigen we x met de deler dus 2 maal 3 = 6");
            int y = x * deler;
            Console.WriteLine("int y = x * deler;");
            Console.ReadKey();
            Console.WriteLine("Nu halen we y van het aantal af dus 8 min 6 = 2");
            int modulus = aantal - y;
            Console.WriteLine($"modulus = {modulus}");
            Console.ReadKey();
            Console.WriteLine("Console.WriteLine(8 % 3); geeft dan dus...");
            Console.WriteLine(-8 % 3);
            Console.ReadKey();
        }

        public static void PrintSudoku(int[][] cells)
        {
            string horLine = "----------------------";
            string verLine = "|";

            Console.Write(horLine);
            Console.WriteLine();
            for (int i = 0; i < cells.Length; i++)
            {
                Console.Write(verLine);
                for (int j = 0; j < cells[i].Length; j++)
                {
                    if (cells[i][j] != 0)
                    {
                        Console.Write($"{cells[i][j]} ");
                    }
                    else
                    {
                        Console.Write("  ");
                    }
                    if (j % 3 == 2)
                    {
                        Console.Write(verLine);
                    }
                }
                Console.WriteLine();
                if (i % 3 == 2)
                {
                    Console.Write(horLine);
                    Console.WriteLine();
                }
            }
        }
    }
}
