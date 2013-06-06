using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.PathInLabyrinth
{
    public struct MatrixPoint
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public int Counter { get; set; }

        public MatrixPoint(int row, int col, int counter)
            : this()
        {
            this.Row = row;
            this.Col = col;
            this.Counter = counter;
        }
    }
}
