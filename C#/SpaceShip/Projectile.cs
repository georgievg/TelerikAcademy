using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaceShip
{
    public class Projectile : GameObject, ICollidable
    {
        public Projectile(Point position)
        {
            this.Position = position;
            this.IsCollidable = true;
            this.IsDestructible = true;
            FillBody();
        }
        public override void FillBody()
        {
            this.Body = new char[,]
           {
               {'-','>'}
           };
        }
        public override void UpdatePosition(Point newPosition)
        {
            this.Position = new Point(this.Position.X + 1, this.Position.Y);
        }
        public override void Draw(int fieldHeight, int fieldWidth)
        {
            int x = this.Position.X;
            int y = this.Position.Y;
            if (x < fieldWidth)
            {
                for (int i = 0; i < this.Body.GetLength(0); i++)
                {
                    for (int g = 0; g < this.Body.GetLength(1); g++)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.SetCursorPosition(x, y);
                        x++;
                        Console.Write(this.Body[i, g]);
                    }
                    
                }
            }
        }
    }
}