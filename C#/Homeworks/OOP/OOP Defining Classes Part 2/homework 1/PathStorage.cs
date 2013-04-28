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
    public static class PathStorage
    {
        public static void SavePathsToFile(string FullPath,string FileName,Path path)
        {
            using (StreamWriter sr = new StreamWriter(FullPath+FileName))
            {
                foreach (var point in path.points)
                {
                    sr.Write("{0},{1},{2},", point.X, point.Y, point.Z);
                    sr.WriteLine();
                }
            }
        }
        static Path LoadPathsFromFile(string FullPath, string FileName)
        {
            Path newPath = new Path();
            using (StreamReader sr = new StreamReader(FullPath+FileName))
            {
                string line = null;               
                while ((line = sr.ReadLine()) != null)
                {
                    string[] splitted = line.Split(new char[] {','},StringSplitOptions.RemoveEmptyEntries);
                    Point3D newPoint = new Point3D(int.Parse(splitted[0]), int.Parse(splitted[1]), int.Parse(splitted[2]));
                    newPath.AddPoint(newPoint);
                }
            }

            return newPath;
        }
    }
}