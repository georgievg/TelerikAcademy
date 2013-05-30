using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceShip
{
    class Wall : GameObject, ICollidable
    {
        Random rnd = new Random();
        public int Life { get; private set; }
        public Wall(int fieldHeight, int fieldWidth, bool top)
        {
            
            int height = rnd.Next(5,  fieldHeight * 7 / 10);
            int width  = 2;
            Position   = top ? new Point(fieldWidth - 1, 0) :  new Point(fieldWidth - 1, fieldHeight - height);
            Body       = new char[height, width];            
            FillBody();
            IsCollidable   = true;
            IsDestructible = false;
            this.objColor = ConsoleColor.DarkGreen; // Set the object Color
            this.Life = rnd.Next(3, 6);
        }
        public void ReduceLife()
        {
            this.Life--;
        }
        public override void FillBody()
        {
            for (int i = 0; i < this.Height; i++) {
                for (int j = 0; j < this.Width; j++) {
                    Body[i, j] = '#';
                }
            }
        }
    }
}
                                                                             