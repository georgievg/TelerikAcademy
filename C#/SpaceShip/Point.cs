using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceShip
{
    public struct Point //Game object's upper left coordinates
    {
        public int X;
        public int Y;
        public Point(int x, int y) : this()
        {
            X = x;
            Y = y;
        }

        public static Point operator + (Point p1, Point p2)
        {
            return new Point(p1.X + p2.X, p1.Y + p2.Y);
        }

    }
}
