using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MatrixIndexer
{
    public int Row { get; private set; }
    public int Col { get; private set; }

    public MatrixIndexer(int row, int col)
    {
        this.Row = row;
        this.Col = col;
    }
}

