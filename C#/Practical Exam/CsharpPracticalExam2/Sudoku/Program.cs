using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] sudoku = new int[9, 9];
            string input = Console.ReadLine();
            string[] Lines = input.Split(' ');
            for (int i = 0; i < Lines.Length; i++)
            {
                Lines[i] = Lines[i].Replace("-", "0");
            }
            for (int row = 0; row < sudoku.GetLength(0); row++)
            {
                for (int cell = 0; cell < sudoku.GetLength(0); cell++)
                {
                    sudoku[row, cell] = int.Parse(Lines[row][cell].ToString());
                }   
            }
            
        }
    }
}
