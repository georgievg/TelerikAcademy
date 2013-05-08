using MatriceWalk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Matrix
{
    private int[,] matrix;
    private Direction currDirection = Direction.None;

    public int DimensionLength { get; private set; }
    public int CurrRow { get; private set; }
    public int CurrCol { get; private set; }
    public int CurrValue { get; private set; }

    public Matrix(int dimension)
    {
        this.matrix = new int[dimension, dimension];
        this.CurrCol = 0;
        this.CurrRow = 0;
        this.CurrValue = 1;
    }

    public int this[int row,int col]
    {
        get
        {
            return this.matrix[row, col];
        }
    }

    public void FillMatrix()
    {
        if (currDirection == Direction.None)
        {
            
        }
    }

}

