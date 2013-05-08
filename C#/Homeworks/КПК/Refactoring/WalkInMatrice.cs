using System;
using MatriceWalk;

class WalkInMatrice
{
    static void Main()
    {

        //Console.WriteLine( "Enter a positive number " );
        //string input = Console.ReadLine(  );
        //int n = 0;
        //while ( !int.TryParse( input, out n ) || n < 0 || n > 100 )
        //{
        //    Console.WriteLine( "You haven't entered a correct positive number" );
        //    input = Console.ReadLine(  );
        //}
        int matriceLength = 6;
        int[,] matrice = new int[matriceLength, matriceLength];
        int currentValue = 1;
        int row = 0;
        int col = 0;
        int directionX = 1;
        int directionY = 1;

        Direction currentDirection = Direction.None;
        while ((currentDirection = AvailableMove(matrice, row, col)) != Direction.None)
        {
            matrice[row, col] = currentValue;

            //if (row + directionX >= n || row + directionX < 0 || col + directionY >= n || col + directionY < 0 || matrice[row + directionX, col + directionY] != 0)
            {
                while ((row + directionX >= matriceLength || row + directionX < 0 || col + directionY >= matriceLength || col + directionY < 0 || matrice[row + directionX, col + directionY] != 0))
                {
                    ChangeDirection(ref directionX, ref directionY);
                }

                row += directionX; 
                col += directionY; 
                currentValue++;
            }
        }
        for (int p = 0; p < matriceLength; p++)
        {
            for (int q = 0; q < matriceLength; q++)
            {
                Console.Write("{0,4}", matrice[p, q]);
            }
            Console.WriteLine();
        }

        FindCell(matrice, out row, out col);

        if (row != 0 && col != 0)
        {
            directionX = 1; directionY = 1;

            //while (AvailableMove(matrice, row, col) != Direction.None)
            {
                matrice[row, col] = currentValue;

                if (row + directionX >= matriceLength || row + directionX < 0 || col + directionY >= matriceLength || col + directionY < 0 || matrice[row + directionX, col + directionY] != 0)
                {
                    while (matrice.Contains(0)) //|| (row + directionX >= n || row + directionX < 0 || col + directionY >= n || col + directionY < 0 || matrice[row + directionX, col + directionY] != 0) )
                    {
                        ChangeDirection(ref directionX, ref directionY);
                    }
                    row += directionX; col += directionY; currentValue++;
                }
            }
        }
        for (int pp = 0; pp < matriceLength; pp++)
        {
            Console.WriteLine();
            for (int qq = 0; qq < matriceLength; qq++)
            {
                Console.Write("{0,3}", matrice[pp, qq]);
            }

            Console.WriteLine();
        }
    }

    private static void ChangeDirection(ref int dx, ref int dy)
    {
        int[] dirX = { 1, 1, 1, 0, -1, -1, -1, 0 };


        int[] dirY = { 1, 0, -1, -1, -1, 0, 1, 1 };
        int cd = 0;
        for (int count = 0; count < 8; count++)
            if (dirX[count] == dx && dirY[count] == dy) { cd = count; break; }
        if (cd == 7) { dx = dirX[0]; dy = dirY[0]; return; }
        dx = dirX[cd + 1];


        dy = dirY[cd + 1];
    }

    private static Direction AvailableMove(int[,] arr, int row, int col)
    {
        const int DirectionsLength = 8;
        Direction availDirection = Direction.None;

        for (int i = 0; i < DirectionsLength; i++)
        {
            Direction currDirection = (Direction)i;
            bool isAvailable = AvailableDirection(arr, row, col, currDirection);
            if (isAvailable)
            {
                availDirection = currDirection;
                break;
            }
        }

        return availDirection;
    }

    private static bool AvailableDirection(int[,] arr, int row, int col, Direction direction)
    {
        bool availableDir = false;
        int arrLength = arr.GetLength(0) - 1;

        switch (direction)
        {
            case Direction.RightDown:
                if (col != arrLength && row != arrLength)
                {
                    availableDir = arr[row + 1, col + 1] == 0;
                }
                break;
            case Direction.Down:
                if (col != arrLength)
                {
                    availableDir = arr[row, col + 1] == 0;
                }
                break;
            case Direction.LeftDown:
                if (col != arrLength && row != 0)
                {
                    availableDir = arr[row - 1, col + 1] == 0;
                }
                break;
            case Direction.Left:
                if (row != 0)
                {
                    availableDir = arr[row - 1, col] == 0;
                }
                break;
            case Direction.LeftUp:
                if (col != arrLength && row != 0)
                {
                    availableDir = arr[row - 1, col - 1] == 0;
                }
                break;
            case Direction.Up:
                if (col != arrLength)
                {
                    availableDir = arr[row, col - 1] == 0;
                }
                break;
            case Direction.RightUp:
                if (col != 0 && row != 0)
                {
                    availableDir = arr[row - 1, col - 1] == 0;
                }
                break;
            case Direction.Right:
                if (row != arrLength)
                {
                    availableDir = arr[row + 1, col] == 0;
                }
                break;
            default:
                break;
        }

        return availableDir;
    }

    private static void FindCell(int[,] arr, out int x, out int y)
    {
        x = 0;
        y = 0;
        for (int row = 0; row < arr.GetLength(0); row++)
        {
            for (int col = 0; col < arr.GetLength(0); col++)
            {
                if (arr[row, col] == 0)
                {
                    x = row; 
                    y = col; 
                    return;
                }
            }
        }

    }
}

