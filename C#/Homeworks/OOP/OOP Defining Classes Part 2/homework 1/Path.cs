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
    //
    public class Path
    {
        public List<Point3D> points { get; private set; }

        public Path()
        {
            points = new List<Point3D>();
        }
        public void AddPoint(Point3D point)
        {
            points.Add(point);
        }
        public void RemovePoint(int AtPosition)
        {
            points.RemoveAt(AtPosition);
        }

        
    }
}