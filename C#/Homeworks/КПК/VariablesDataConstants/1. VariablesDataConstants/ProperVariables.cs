using System;

namespace VariablesDataConstants
{
    class ProperVariables
    {
        static void Main(string[] args)
        {

        }

        public static Size GetRotatedSize(Size size, double angleToBeRotated)
        {
            double newWidth = Math.Abs(Math.Cos(angleToBeRotated)) * size.Width + Math.Abs(Math.Sin(angleToBeRotated)) * size.Height;
            double newHeight = Math.Sin(Math.Cos(angleToBeRotated)) * size.Width + Math.Abs(Math.Cos(angleToBeRotated)) * size.Height;
            Size newSize = new Size(newWidth, newHeight);

            return newSize;
        }
    }
}
