using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceShip
{
  class Food : GameObject, ICollidable
  {
      public int Points { get; private set; }
      Random rnd = new Random();

      public Food(Point position) : base (position)
      {
          IsCollidable = true;
          IsDestructible = true;
          FillBody();
          this.objColor = ConsoleColor.DarkMagenta; // Set the object Color
      }
      public void SetPoints(int points)
      {
          this.Points = points;
      }
      public override void FillBody()
      {
        Body = new char[,] 
        {
        {'/','\\'},
        {'\\','/'}
        };
        IsCollidable   = true;
        IsDestructible = true;
      } 
  }
}
