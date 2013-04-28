using System;

namespace CohesionAndCoupling
{
    class UtilsExamples
    {
        static void Main()
        {
            Console.WriteLine(FileNameParsers.GetExtension("example"));
            Console.WriteLine(FileNameParsers.GetExtension("example.pdf"));
            Console.WriteLine(FileNameParsers.GetExtension("example.new.pdf"));

            Console.WriteLine(FileNameParsers.GetNameWithoutExtension("example"));
            Console.WriteLine(FileNameParsers.GetNameWithoutExtension("example.pdf"));
            Console.WriteLine(FileNameParsers.GetNameWithoutExtension("example.new.pdf"));

            //so i don't have to rename everything
            _3DFigure Utils = new _3DFigure(500, 400, 300);

            Console.WriteLine("Distance in the 2D space = {0:f2}",
                Utils.CalcDistance2D(1, -2, 3, 4));
            Console.WriteLine("Distance in the 3D space = {0:f2}",
                Utils.CalcDistance3D(5, 2, -1, 3, -6, 4));

            Console.WriteLine("Volume = {0:f2}", Utils.CalcVolume());
            Console.WriteLine("Diagonal XYZ = {0:f2}", Utils.CalcDiagonalXYZ());
            Console.WriteLine("Diagonal XY = {0:f2}", Utils.CalcDiagonalXY());
            Console.WriteLine("Diagonal XZ = {0:f2}", Utils.CalcDiagonalXZ());
            Console.WriteLine("Diagonal YZ = {0:f2}", Utils.CalcDiagonalYZ());
        }
    }
}
