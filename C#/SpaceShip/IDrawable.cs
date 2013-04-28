using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceShip
{
    interface IDrawable
    {
        void FillBody();
        void Draw( int fieldHeight, int fieldWidth);
    }
}
