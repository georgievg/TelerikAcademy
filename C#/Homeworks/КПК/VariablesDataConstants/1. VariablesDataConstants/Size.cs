using System;

namespace VariablesDataConstants
{
    public class Size
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
                    throw new NotValidValueException("Width can not be less than zero");
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
                    throw new NotValidValueException("Height can not be less than zero");
                }
                this.height = value;
            }
        }

        public Size(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }
    }
}
