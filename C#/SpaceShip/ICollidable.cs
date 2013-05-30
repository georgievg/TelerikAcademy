using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceShip
{
    interface ICollidable
    {
        bool InCollision(GameObject obj);
    }
}
