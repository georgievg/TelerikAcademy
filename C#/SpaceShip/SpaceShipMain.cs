using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceShip
{
    class SpaceShipMain
    {
        static void Main()
        {
            Engine gameEngine = new Engine(70, 30);
            GameMenu.InitializeMenu(gameEngine);
        }
    }
}
