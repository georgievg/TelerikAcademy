using MatriceWalk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Matrix
{
    //private const int DownLeft = this.matrix[this.CurrRow + 1, this.CurrCol + 1];
    private const int DirectionsLenght = 8;

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

    public int this[int row, int col]
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
            MatrixIndexer availMatrixCoords = FindFreeCell();
        }
        else
        {

        }
    }

    // private void FillAvailPos(Direction
    private bool DownLeft()
    {
        if (this.CurrCol != this.DimensionLength - 1 && this.CurrRow != this.DimensionLength - 1)
        {
            if (this.matrix[this.CurrRow + 1, this.CurrCol + 1] == 0)
            {
                return true;
            }
        }

        return false;
    }
    private bool RightDown()
    {
        if (this.CurrCol != this.DimensionLength && this.CurrCol != this.DimensionLength)
        {
            if (this.matrix[this.CurrRow + 1, this.CurrCol + 1] == 0)
            {
                return true;
            }
        }

        return false;
    }


    private Direction FindAvailDirection()
    {
            for (int i = 0; i < DirectionsLenght; i++)
			{
			    Direction currDirection = (Direction)i;
                if (DownLeft())
	            {
		                
	            }
                else if (RightDown())
	            {
		 
	            }
			}
            case Direction.RightDown:
                
                break;
            case Direction.Down:
                if (this.CurrCol != this.DimensionLength -1)
                {
                    availableDir = this.matrix[this.CurrRow, this.CurrCol + 1] == 0;
                }
                break;
            case Direction.LeftDown:
                if (this.CurrCol != this.DimensionLength -1 && this.CurrRow != 0)
                {
                    availableDir = this.matrix[this.CurrRow - 1, this.CurrCol + 1] == 0;
                }
                break;
            case Direction.Left:
                if (this.CurrRow != 0)
                {
                    availableDir = this.matrix[this.CurrRow - 1, this.CurrCol] == 0;
                }
                break;
            case Direction.LeftUp:
                if (this.CurrCol != this.DimensionLength -1 && this.CurrRow != 0)
                {
                    availableDir = this.matrix[this.CurrRow - 1, this.CurrCol - 1] == 0;
                }
                break;
            case Direction.Up:
                if (this.CurrCol != this.DimensionLength -1)
                {
                    availableDir = this.matrix[this.CurrRow, this.CurrCol - 1] == 0;
                }
                break;
            case Direction.RightUp:
                if (this.CurrCol != 0 && this.CurrRow != 0)
                {
                    availableDir = this.matrix[this.CurrRow - 1, this.CurrCol - 1] == 0;
                }
                break;
            case Direction.Right:
                if (this.CurrRow != this.DimensionLength -1)
                {
                    availableDir = this.matrix[this.CurrRow + 1, this.CurrCol] == 0;
                }
                break;
       
    }

    private MatrixIndexer FindFreeCell()
    {
        int foundRow = 0;
        int foundCol = 0;
        for (int row = 0; row < this.DimensionLength; row++)
        {
            for (int col = 0; col < this.DimensionLength; col++)
            {
                if (this.matrix[row, col] == 0)
                {
                    foundRow = row;
                    foundCol = col;
                    break;
                }
            }
        }

        MatrixIndexer foundMatrixCoords = new MatrixIndexer(foundRow, foundCol);
        return foundMatrixCoords;
    }


}

