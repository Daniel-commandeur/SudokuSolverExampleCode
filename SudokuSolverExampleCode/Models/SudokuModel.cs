using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuSolverExampleCode.Models
{
    public class SudokuModel
    {
        public int SudokuId { get; set; }
        public string Name { get; set; }
        public int[][] Cells { get; set; }
        public Coordinate Coord { get; set; }
    }
}
