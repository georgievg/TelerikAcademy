using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class AcademyPopcornMain
    {
        const int WorldRows = 23;
        const int WorldCols = 40;
        const int RacketLength = 6;

        static void Initialize(Engine engine)
        {
            int startRow = 3;
            int startCol = 2;
            int endCol = WorldCols - 2;

            for (int i = startCol; i < endCol; i++)
            {
                if (i == 3)
                {
                    ExplodingBlock expBlock = new ExplodingBlock(new MatrixCoords(startRow, i));
                    engine.AddObject(expBlock);
                    continue;
                }
                if (i == 2)
                {
                    GiftBlock giftblock = new GiftBlock(new MatrixCoords(startRow, i));
                    engine.AddObject(giftblock);
                    continue;
                }
                Block currBlock = new Block(new MatrixCoords(startRow, i));

                engine.AddObject(currBlock);
            }

           // Ball theBall = new Ball(new MatrixCoords(WorldRows / 2, 0),
           //     new MatrixCoords(-1, 1));
            //MeteoriteBall theBall = new MeteoriteBall(new MatrixCoords(WorldRows / 2, 0),
            //    new MatrixCoords(-1, 1));
            UnstoppableBall theBall = new UnstoppableBall(new MatrixCoords(WorldRows / 2, 0),
                new MatrixCoords(-1, 1));

            engine.AddObject(theBall);

            Racket theRacket = new Racket(new MatrixCoords(WorldRows - 1, WorldCols / 2), RacketLength);

            engine.AddObject(theRacket);

            for (int i = startRow; i < Console.BufferHeight; i++)
            {
                engine.AddObject(new UnpassableBlock(new MatrixCoords(i, startCol - 1)));
            }
            for (int i = startRow; i < Console.BufferHeight; i++)
            {
                engine.AddObject(new UnpassableBlock(new MatrixCoords(i, WorldCols - 2)));
            }
            for (int i = startCol-1; i < WorldCols-1; i++)
            {
                engine.AddObject(new UnpassableBlock(new MatrixCoords(startRow - 1, i)));
            }
            Random rnd = new Random();
            for (int i = 0; i < 5; i++)
            {
                engine.AddObject(new UnpassableBlock(new MatrixCoords((rnd.Next(0, WorldCols)), (rnd.Next(0, WorldRows)))));
            }
        }
        static void Main(string[] args)
        {
            IRenderer renderer = new ConsoleRenderer(WorldRows, WorldCols);
            IUserInterface keyboard = new KeyboardInterface();

            Engine gameEngine = new Engine(renderer, keyboard,200);

            keyboard.OnLeftPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketLeft();
            };

            keyboard.OnRightPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketRight();
            };
            keyboard.OnActionPressed += (sender, eventInfo) =>
            {
                gameEngine.ShootPlayerRacket();
            };

            Initialize(gameEngine);

            //

            gameEngine.Run();
        }
    }
}
