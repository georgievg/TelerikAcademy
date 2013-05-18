using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceShip
{
    public static class Extensions
    {
        public static void RenderObject(this GameObject obj) //Render any GameObject with body on the console on the right position
        {

            Console.SetCursorPosition(obj.Position.X, obj.Position.Y);
            int y = obj.Position.Y;
            for (int i = 0; i < obj.Body.GetLength(0); i++)
            {
                for (int g = 0; g < obj.Body.GetLength(1); g++)
                {
                    Console.Write(obj.Body[i, g]);
                }
                Console.SetCursorPosition(obj.Position.X, y++);
            }
        }
    }
}
