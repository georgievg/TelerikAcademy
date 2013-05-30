using System;

namespace _14.PathInLabyrinth
{
    class PathInLabyrinthMain
    {
        static void Main()
        {
            char[,] arr = new char[,]
            {
                { '0', '0', '0', 'x', '0', 'x' },
                { '0', 'x', '0', 'x', '0', 'x' },
                { '0', '*', 'x', '0', 'x', '0' },
                { '0', 'x', '0', '0', '0', '0' },
                { '0', '0', '0', 'x', 'x', '0' },
                { '0', '0', '0', 'x', '0', 'x' },
            };

            char[,] result = FindLabirynthPath(arr, '1');
        }

        private static char[,] FindLabirynthPath(char[,] arr, char symbol, Direction direction = Direction.Right)
        {
            #if DEBUG
            PrintMatrix(arr);
            #endif

            int[,] startPos = FindStartPos(arr);
        }

        private static int[,] FindStartPos(char[,] arr)
        {
            for (int row = 0; row < arr.GetLength(0); row++)
            {
                for (int col = 0; col < arr.GetLength(1); col++)
                {
                    if (arr[row,col] == '*')
                    {
                        int[,] pos = new int[,]
                        {
                            {row},
                            {col},
                        };

                        return pos;
                    }
                }
            }

            throw new ArgumentException("Could not find starting position");
        }

        private static void PrintMatrix(char[,] arr)
        {
            for (int row = 0; row < arr.GetLength(0); row++)
            {
                for (int col = 0; col < arr.GetLength(1); col++)
                {
                    Console.Write("{0}  ", arr[row, col]);
                }

                Console.WriteLine("\r\n");
            }
        }
    }

    public enum Direction
    {
        Left,
        Right,
        Top,
        Bottom
    }
}