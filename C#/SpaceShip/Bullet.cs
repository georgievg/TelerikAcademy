using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceShip
{
    class Bullet: GameObject, ICollidable
    {
      public int BulletsAmount { get; private set; }
      Random rnd = new Random();

      public Bullet(Point position) : base (position)
      {
          IsCollidable = true;
          IsDestructible = true;
          FillBody();
          this.objColor = ConsoleColor.DarkBlue; // Set the object Color
      }
      public void SetBulletsAmount(int bullets)
      {
          this.BulletsAmount = bullets;
      }
      public override void FillBody()
      {
        Body = new char[,] 
        {
        {'\\','/'},       //    \/
        {'/','\\'}        //    /\ 
        };
        IsCollidable   = true;
        IsDestructible = true;
      }
    }
}
