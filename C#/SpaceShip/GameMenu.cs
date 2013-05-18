using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaceShip
{
    public static class GameMenu
    {
        private static bool top = true;
        private static Engine eng { get; set; }
        public static void InitializeMenu(Engine engine)
        {
            eng = engine;
            RenderMenu(top);
            ReadInput();
        }
        private static void RenderMenu(bool up)
        {
            Console.Clear();
            Console.SetCursorPosition(eng.FieldWidth / 2, eng.FieldHeight / 2);
            if (up)
            {
                Console.WriteLine("-->START NEW GAME<--");
                Console.SetCursorPosition((eng.FieldWidth / 2), (eng.FieldHeight / 2) +1);
                Console.WriteLine("QUIT GAME");
            }
            else if (!up)
            {
                Console.WriteLine("START NEW GAME");
                Console.SetCursorPosition((eng.FieldWidth / 2), (eng.FieldHeight / 2) + 1);
                Console.WriteLine("-->QUIT GAME<--");
            }
           
            
        }
        private static void ReadInput()
        {
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.UpArrow)
                {
                    if (!top)
                    {
                        top = true;
                        RenderMenu(top);
                    }
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    if (top)
                    {     
                        top = false;
                        RenderMenu(top);
                    }
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    if (top)
                    {
                        eng.InitializeGameEngine();
                    }
                    else if (!top)
                    {
                        return;
                    }
                }
            }
        }
    }
}