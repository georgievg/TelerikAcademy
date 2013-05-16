using System;

namespace WalkInMatrix
{
    class WalkInMatrixMain
    {
        private static int ReadUserInput()
        {
            Console.WriteLine("Enter a positive number ");
            string input = Console.ReadLine();
            int n = 0;

            while (!int.TryParse(input, out n) || n < 0 || n > 100)
            {
                Console.WriteLine("You haven't entered a correct positive number");
                input = Console.ReadLine();
            }

            return n;
        }

        static void Main()
        {
            int n = ReadUserInput();
            Matrix matrix = new Matrix(n,n);
            matrix.FillMatrix();
            Console.WriteLine(matrix);

        //    int matrixDimension = 3;
        //    matrix = new int[matrixDimension, matrixDimension];

        //    int currentNumber = 1;
        //    int currentCol = 0;
        //    int currentRow = 0;
        //    int directionX = 1;
        //    int directionY = 1;

        //    FillMatrix(matrix, matrixDimension, ref directionX, ref directionY, ref currentCol, ref currentRow, ref currentNumber);

        //    FindAvailableCell(matrix, out currentCol, out currentRow);

        //    if (currentCol != 0 && currentRow != 0)
        //    {
        //        directionX = 1;
        //        directionY = 1;

        //        while (true)
        //        {
        //            matrix[currentCol, currentRow] = currentNumber;
        //            if (!HasAvailableCell(matrix, currentCol, currentRow))
        //            {
        //                break;
        //            }
        //            if (currentCol + directionX >= matrixDimension || currentCol + directionX < 0 || currentRow + directionY >= matrixDimension || currentRow + directionY < 0 || matrix[currentCol + directionX, currentRow + directionY] != 0)
        //            {
        //                while ((currentCol + directionX >= matrixDimension || currentCol + directionX < 0 || currentRow + directionY >= matrixDimension || currentRow + directionY < 0 || matrix[currentCol + directionX, currentRow + directionY] != 0))
        //                    ChangeDirection(ref directionX, ref directionY);
        //            }
        //            currentCol += directionX;
        //            currentRow += directionY;
        //            currentNumber++;
        //        }
        //    }
        //    for (int pp = 0; pp < matrixDimension; pp++)
        //    {
        //        for (int qq = 0; qq < matrixDimension; qq++)
        //        {
        //            Console.Write("{0,3}", matrix[pp, qq]);
        //        }

        //        Console.WriteLine();
        //    }
        //}
  
        //private static void FillMatrix(int[,] matrix, int matrixDimension, ref int directionX, ref int directionY, ref int col, ref int row, ref int currentNumber)
        //{
        //    while (true)
        //    {
        //        matrix[col, row] = currentNumber;

        //        if (!HasAvailableCell(matrix, col, row))
        //        {
        //            break;
        //        }

        //        if (col + directionX >= matrixDimension || col + directionX < 0 || row + directionY >= matrixDimension || row + directionY < 0 || matrix[col + directionX, row + directionY] != 0)
        //        {
        //            while ((col + directionX >= matrixDimension || col + directionX < 0 || row + directionY >= matrixDimension || row + directionY < 0 || matrix[col + directionX, row + directionY] != 0))
        //            {
        //                ChangeDirection(ref directionX, ref directionY);
        //            }
        //        }

        //        col += directionX;
        //        row += directionY;
        //        currentNumber++;
        //    }
        //}

        

        //static void ChangeDirection(ref int dx, ref int dy)
        //{
        //    int[] dirX = { 1, 1, 1, 0, -1, -1, -1, 0 };
        //    int[] dirY = { 1, 0, -1, -1, -1, 0, 1, 1 };
        //    int cd = 0;
        //    for (int count = 0; count < 8; count++)
        //    {
        //        if (dirX[count] == dx && dirY[count] == dy)
        //        {
        //            cd = count;
        //            break;
        //        }
        //    }

        //    if (cd == 7)
        //    {
        //        dx = dirX[0];
        //        dy = dirY[0];
        //        return;
        //    }

        //    dx = dirX[cd + 1];
        //    dy = dirY[cd + 1];
        //}

        //static bool HasAvailableCell(int[,] arr, int x, int y)
        //{
        //    int[] dirX = { 1, 1, 1, 0, -1, -1, -1, 0 };
        //    int[] dirY = { 1, 0, -1, -1, -1, 0, 1, 1 };
        //    for (int i = 0; i < 8; i++)
        //    {
        //        if (x + dirX[i] >= arr.GetLength(0) || x + dirX[i] < 0)
        //        {
        //            dirX[i] = 0;
        //        }

        //        if (y + dirY[i] >= arr.GetLength(0) || y + dirY[i] < 0)
        //        {
        //            dirY[i] = 0;
        //        }
        //    }
        //    for (int i = 0; i < 8; i++)
        //    {
        //        if (arr[x + dirX[i], y + dirY[i]] == 0)
        //        {
        //            return true;
        //        }
        //    }

        //    return false;
        //}

        //static void FindAvailableCell(int[,] arr, out int x, out int y)
        //{
        //    x = 0;
        //    y = 0;
        //    for (int i = 0; i < arr.GetLength(0); i++)
        //    {
        //        for (int j = 0; j < arr.GetLength(0); j++)
        //        {
        //            if (arr[i, j] == 0)
        //            {
        //                x = i;
        //                y = j;
        //                return;
        //            }
        //        }
        //    }
        }
    }
}