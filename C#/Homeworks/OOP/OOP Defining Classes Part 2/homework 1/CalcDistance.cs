using System;
using System.Collections.Generic;
using System.Threading;
using System.IO;
using System.Web;
using System.Net;
using System.Linq;
using System.Text;

namespace homework_1
{
    //float deltaX = x1 - x0;
    //float deltaY = y1 - y0;
    //float deltaZ = z1 - z0;
    //
    //float distance = (float) Math.Sqrt(deltaX * deltaX + deltaY * deltaY + deltaZ * deltaZ);
    public static class CalcDistance
    {
        public static float CalcBetweenTwoPoints(Point3D p1, Point3D p2)
        {
            float deltaX = p1.X - p2.X;
            float deltaY = p1.Y - p2.Y;
            float deltaZ = p1.Z - p2.Z;

            float distance = (float)Math.Sqrt(deltaX * deltaX + deltaY * deltaY + deltaZ * deltaZ);
            return distance;
        }
    }
}