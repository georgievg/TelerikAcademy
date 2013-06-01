using System;
using System.Collections.Generic;

namespace _14.PathInLabyrinth
{
    class PathInLabyrinthMain
    {
        private static Queue<MatrixPoint> points = new Queue<MatrixPoint>();
        private static string[,] labyrinth = new string[,]
            {
                { "0", "0", "0", "x", "0", "x" },
                { "0", "x", "0", "x", "0", "x" },
                { "0", "*", "x", "0", "x", "0" },
                { "0", "x", "0", "0", "0", "0" },
                { "0", "0", "0", "x", "x", "0" },
                { "0", "0", "0", "x", "0", "x" },
            };

        static void Main()
        {
            PrintMatrix(labyrinth);

            MatrixPoint startPos = FindStartPos(labyrinth);
            FindLabirynthPath(startPos);

            PrintMatrix(labyrinth);
        }

        private static void FindLabirynthPath(MatrixPoint point)
        {
            
            int row = point.Row;
            int col = point.Col;
            int counter = point.Counter;
            FindNeightbours(point);
            while (points.Count > 0)
            {
                MatrixPoint current = points.Dequeue();
                if (labyrinth[current.Row, current.Col] == "0")
                {
                    FindNeightbours(new MatrixPoint(current.Row, current.Col, current.Counter + 1));
                    labyrinth[current.Row, current.Col] = current.Counter.ToString();
                }
                if (labyrinth[current.Row, current.Col] == "*")
                {
                    FindNeightbours(new MatrixPoint(current.Row, current.Col, current.Counter + 1));
                }
            }
        }

        private static void FindNeightbours(MatrixPoint point)
        {
            int row = point.Row;
            int col = point.Col;
            int counter = point.Counter;
            if (row != labyrinth.GetLength(1) - 1)
            {
                points.Enqueue(new MatrixPoint(point.Row + 1, point.Col, point.Counter));
            }

            if (col != labyrinth.GetLength(0) - 1)
            {
                points.Enqueue(new MatrixPoint(row, col + 1, counter)); //bottom
            }

            if (row != 0)
            {
                points.Enqueue(new MatrixPoint(row - 1, col, counter));
            }

            if (col != 0)
            {
                points.Enqueue(new MatrixPoint(row, col - 1, counter));
            }
        }

        private static MatrixPoint FindStartPos(string[,] arr)
        {
            for (int row = 0; row < arr.GetLength(0); row++)
            {
                for (int col = 0; col < arr.GetLength(1); col++)
                {
                    if (arr[row, col] == "*")
                    {
                        return new MatrixPoint(row, col, 1);
                    }
                }
            }

            throw new ArgumentException("Could not find starting position");
        }

        private static void PrintMatrix(string[,] arr)
        {
            for (int row = 0; row < arr.GetLength(0); row++)
            {
                for (int col = 0; col < arr.GetLength(1); col++)
                {
                    Console.Write("{0}  ", arr[row, col]);
                }

                Console.WriteLine("\r\n");
            }

            Console.WriteLine(new string('-', 30));
        }
    }
}