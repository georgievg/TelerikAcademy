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
    
    public struct Point3D
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        public static string PointO
        {
            get
            {
                return "0 0 0";
            }
        }
        

        
        
        public Point3D(int X,int Y,int Z)
            : this()
        {
            this.X = X;
            this.Y = Y;
            this.Z = Z;
        }

        public override string ToString()
        {
            string point = string.Format("Point X = {0} \r\nPoint Y = {1} \r\nPoint Z = {2}", this.X, this.Y, this.Z);
            return point.ToString();
        }
    }
}