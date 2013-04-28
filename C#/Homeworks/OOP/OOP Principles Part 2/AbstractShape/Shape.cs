using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractShape
{
    public abstract class Shape
    {
        private double width;
        private double height;

        public double Width
        {
            get
            {
                return this.width;
            }
            private set
            {
                if (value < 0)
                {
                    throw new NotValidSizeExeption("Width of shape is less than zero");
                }
                this.width = value;
            }
        }
        public double Height
        {
            get
            {
                return this.height;
            }
            private set
            {
                if (value < 0)
                {
                    throw new NotValidSizeExeption("Height of shape is less than zero");
                }
                this.height = value;
            }
        }

        public Shape(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }
        public abstract double CalculateSurface();
    }
}
