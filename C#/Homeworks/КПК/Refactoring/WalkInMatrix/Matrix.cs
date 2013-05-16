using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkInMatrix
{
    class Matrix
    {
        private int[,] innerMatrix;
        private int currentNumber;
        private int directionX;
        private int directionY;
        private int currentRow;
        private int currentCol;
        private readonly int matrixWidth;
        private readonly int matrixHeight;

        public Matrix(int width, int height)
        {
            this.innerMatrix = new int[width, height];
            this.matrixWidth = width;
            this.matrixHeight = height;
            this.currentNumber = 1;
            this.directionX = 1;
            this.directionY = 1;
            this.currentCol = 0;
            this.currentRow = 0;
        }

        public void FillMatrix()
        {
            TraverseAvailablePositions();
            FindAvailableCell();
            if(currentCol != 0 && currentRow != 0)
            {
                directionX = 1;
                directionX = 1;
                TraverseAvailablePositions();
            }
        }
  
        private void TraverseAvailablePositions()        
        {
            while (true)
            {
                this.innerMatrix[currentCol, currentRow] = currentNumber;

                if (!HasAvailableCell())
                {
                    break;
                }

                if (currentCol + directionX >= this.matrixHeight || currentCol + directionX < 0 || currentRow + directionY >= this.matrixHeight || currentRow + directionY < 0 || this.innerMatrix[currentCol + directionX, currentRow + directionY] != 0)
                {
                    while ((currentCol + directionX >= this.matrixHeight || currentCol + directionX < 0 || currentRow + directionY >= this.matrixHeight || currentRow + directionY < 0 || this.innerMatrix[currentCol + directionX, currentRow + directionY] != 0))
                    {
                        ChangeDirection();
                    }
                }

                currentCol += directionX;
                currentRow += directionY;
                currentNumber++;
            }
            currentNumber++;
        }

        private void ChangeDirection()
        {
            const int AllDirectionsLenght = 8;
            int[] directionsX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] directionsY = { 1, 0, -1, -1, -1, 0, 1, 1 };
            int newDirection = 0;

            for (int currentDirection = 0; currentDirection < AllDirectionsLenght; currentDirection++)
            {
                if (directionsX[currentDirection] == directionX && directionsY[currentDirection] == directionY)
                {
                    newDirection = currentDirection;
                    break;
                }
            }

            if (newDirection == AllDirectionsLenght - 1)
            {
                directionX = directionsX[0];
                directionY = directionsY[0];
                return;
            }

            directionX = directionsX[newDirection + 1];
            directionY = directionsY[newDirection + 1];
        }

        private bool HasAvailableCell()
        {
            int[] dirX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] dirY = { 1, 0, -1, -1, -1, 0, 1, 1 };

            for (int i = 0; i < 8; i++)
            {
                if (currentRow + dirX[i] >= this.matrixHeight || currentRow + dirX[i] < 0)
                {
                    dirX[i] = 0;
                }

                if (currentCol + dirY[i] >= this.matrixWidth || currentCol + dirY[i] < 0)
                {
                    dirY[i] = 0;
                }
            }

            for (int i = 0; i < 8; i++)
            {
                if (this.innerMatrix[currentRow + dirX[i], currentCol + dirY[i]] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        private void FindAvailableCell()
        {
            currentRow = 0;
            currentCol = 0;
            for (int row = 0; row < this.matrixHeight; row++)
            {
                for (int col = 0; col < this.matrixWidth; col++)
                {
                    if (this.innerMatrix[row, col] == 0)
                    {
                        currentRow = row;
                        currentCol = col;
                        return;
                    }
                }
            }
        }

        public int this[int row, int col]
        {
            get
            {
                return this.innerMatrix[row, col];
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int row = 0; row < this.matrixHeight; row++)
            {
                for (int col = 0; col < this.matrixWidth; col++)
                {
                    sb.AppendFormat("{0,4}", this.innerMatrix[row, col]);
                }

                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}