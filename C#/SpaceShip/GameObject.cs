using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceShip
{
    public abstract class GameObject : IMovable, IDrawable //, IDestructible
    {
        public char[,] Body           { get; protected set; }
        public int     Width          { get { return Body.GetLength(1); } } // Game Object's Width
        public int     Height         { get { return Body.GetLength(0); } } // Game Object's Height
        public Point   Position       { get; set; }                         // Game object's Upper Left Point
        public int     Power          { get; private set; }
        public bool    IsCollidable   { get; protected set; }                 // default value = false
        public bool    IsDestructible { get; protected set; }                 // default value = false
        public ConsoleColor objColor {get; set;}  // Color is set form the objConstructor and displayed form Drow()
        
        public GameObject() {}
        public GameObject(Point position)
        {
            this.Position       = position;
            this.IsCollidable   = false;
            this.IsDestructible = false;
        }
        
        public abstract void FillBody();
        public virtual  void UpdatePower(int value)
        {
            this.Power += value;
        }
        public virtual  void UpdatePosition(Point newPosition)
        {
            this.Position = newPosition;
        }

        public virtual  void Draw(int fieldHeight, int fieldWidth)
        {
            int x = Position.X; // because the position could be updated during the execution of the draw method
            int y = Position.Y; // because the position could be updated during the execution of the draw method
            int i, j;
            for (i = y; i < y + Height && i < fieldHeight; i++)
            {
                if (i < 0) continue;
                for (j = x; j < x + Width && j < fieldWidth; j++)
                {
                    if (j < 0) continue;
                    if (this is Wall)
                        if ((this as Wall).Life < 3)
                        {
                            this.objColor = ConsoleColor.Red;
                        }

                    Console.ForegroundColor = this.objColor;
                    Console.SetCursorPosition(j, i);
                    Console.Write(Body[i - y, j - x]);

                }
            }
        }
        public bool InCollision(GameObject obj)
        {
            if(!obj.IsCollidable || !this.IsCollidable && !(obj is Food) && !(obj is Bullet))
                return false;
            int x1 = Position.X;
            int y1 = Position.Y;
            int x2 = obj.Position.X;
            int y2 = obj.Position.Y;
            if (x1 + Width  < x2 || x2 + obj.Width  < x1 ||
                y1 + Height < y2 || y2 + obj.Height < y1)
                return false;
            return true;
        }
        public bool InField(int fieldHeight, int fieldWidth)
        {
            int x = Position.X;
            int y = Position.Y;
            if(x + Width < 0 || x > fieldWidth || y + Height < 0 || y > fieldHeight) return false;
            return true;
        }
    }
}
