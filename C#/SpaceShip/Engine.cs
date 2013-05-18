using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
namespace SpaceShip
{
    //public delegate void KeyPressHandler(Ship sender, CustomKeyPressEventArgs e);
    public class Engine
    {
        Random rand = new Random();
        System.Timers.Timer gameTimer;
        System.Timers.Timer abilityTimer;
        public  int  FieldWidth  { get; private set; }       
        public  int  FieldHeight { get; private set; }
        public  int  GameSleep   { get; private set; }
        public  Ship Ship        { get; private set; }     //passing the ship to the engine
        public PlayerStats Stats { get; private set; }
        private List<Wall> worldWalls;                     //list that contains all active walls
        private List<Food> worldFood;
        private List<Bullet> worldBullets;
        private List<Projectile> worldProjectiles;
        private readonly BackgroundWorker bwReadKey;       // background worker for the player position
        private readonly BackgroundWorker bwUpdateField;   // background worker that writes data to the gameField        
        private bool dead;
        private int  nextWall;
        private bool wallPosition;                         // top = true, bottom = false
        private int  timeElapsed;

        public Engine(int fieldWidth, int fieldHeight) //<----- CONSTRUCTOR !!!!!!!
        {

            Console.CursorVisible = false;
            Console.SetWindowSize(fieldWidth + 5, fieldHeight + 5);
            this.Stats = new PlayerStats();
            FieldHeight   = fieldHeight;
            FieldWidth    = fieldWidth;
            dead          = false;                         // player dead?
            nextWall      = 0;                             // if == 0 add wall, else set value depending on timeElasped
            wallPosition  = false;
            timeElapsed   = 1;
            worldWalls    = new List<Wall>();
            worldFood     = new List<Food>();
            worldBullets = new List<Bullet>();      // Game Bullets
            worldProjectiles = new List<Projectile>();
            Ship          = new Ship(new Point(5, FieldHeight / 2));
            this.Ship.HasAbility = false;
            bwReadKey     = new BackgroundWorker();        // initialize the background worker to read keys from the console
            bwUpdateField = new BackgroundWorker();  
            gameTimer = new System.Timers.Timer();
            abilityTimer = new System.Timers.Timer();
            gameTimer.Interval = 1000;
            gameTimer.Elapsed += gameTimer_Elapsed;
            GameSleep = 500;
            gameTimer.Start();
            RunBgWorkers();
        }
        private void RunBgWorkers()
        {
            bwReadKey.DoWork += (s, e) =>                     // 
            {                                                 // reads Key Strokes and updates the ship's positio
                ConsoleKeyInfo key = Console.ReadKey(true);   // be careful not to get out of the console's range n;
                switch (key.Key)
                {
                    case ConsoleKey.DownArrow:
                        if (Ship.Position.Y + Ship.Height < this.FieldHeight)
                        {
                            Ship.UpdatePosition(new Point(Ship.Position.X, Ship.Position.Y + 1));
                        } break;
                    case ConsoleKey.UpArrow:
                        if (Ship.Position.Y > 0)
                        {
                            Ship.UpdatePosition(new Point(Ship.Position.X, Ship.Position.Y - 1));
                        } break;
                    case ConsoleKey.RightArrow:
                        if (Ship.Position.X < this.FieldWidth)
                        {
                            Ship.UpdatePosition(new Point(Ship.Position.X + 1, Ship.Position.Y));
                        } break;
                    case ConsoleKey.LeftArrow:
                        if (Ship.Position.X > 0)
                        {
                            Ship.UpdatePosition(new Point(Ship.Position.X - 1, Ship.Position.Y));
                        } break;
                    case ConsoleKey.Spacebar:
                        if (Ship.CanShoot)
                        {

                            this.worldProjectiles.Add(new Projectile(new Point(this.Ship.Position.X + 5, this.Ship.Position.Y + 1)));
                            this.Stats.DecreaseBulletAmmonitions();
                        }
                        break;
                    
                    /*
                     * 
                     * 1.)To do: if space-key pressed and Ship.CanShoot==true
                     * 2.)Drow Bullet at Space.Position.X+10
                     * 3.)Bullet.UpdatePosition(new Point(Bullet.Position.x + 1,Bullet.Position.Y)) 
                     */
                    case ConsoleKey.Escape:
                        break;
                }
            };
            bwReadKey.RunWorkerCompleted += (s, e) => { bwReadKey.RunWorkerAsync(); };

            bwUpdateField.DoWork += (s, e) =>
            {
                if (this.Stats.Ammonitions <= 0)
                {
                    this.Ship.CanShoot = false;
                }
                if (!this.dead)
                {
                    for (int i = 0; i < this.worldWalls.Count; i++)
                    {
                        if (Ship.InCollision(this.worldWalls[i]))
                            this.dead = true;
                        if (this.worldWalls[i].Life == 0)
                         {
                            this.worldWalls.RemoveAt(i--);
                            continue;
                        }
                        for (int g = 0; g < this.worldProjectiles.Count; g++)
                        {
                            if (this.worldWalls[i].InCollision(this.worldProjectiles[g]))
                            {
                                this.worldWalls[i].ReduceLife();
                                this.worldProjectiles.RemoveAt(g--);
                            }
                        }
                    }
                    

                   
                    for (int i = 0; i < worldFood.Count; i++)
                    {
                        if (this.Ship.InCollision(worldFood[i]))
                        {
                            worldFood[i].SetPoints(rand.Next(5, this.Stats.Level * 20));
                            this.Stats.IncreaseScore(worldFood[i].Points);
                            if (rand.Next(0,101) < 15 && !this.Ship.HasAbility)
                            {
                                this.Ship.HasAbility = true;
                                this.Ship.GrandAbility(Abilities.Invincibility);                                
                                abilityTimer.Start();
                                int rndInterval = rand.Next(5000, 11000);
                                abilityTimer.Interval = rndInterval;
                                this.Ship.AbilitySeconds = rndInterval;
                                abilityTimer.Elapsed += abilityTimer_Elapsed;
                            }
                            worldFood.RemoveAt(i--);
                        }
                    }

                    // Check collision between ship and bullet -> Incr bullets -> 
                    for (int i = 0; i < worldBullets.Count; i++)
                    {
                        if (Ship.InCollision(worldBullets[i]))
                        {
                            worldBullets[i].SetBulletsAmount(rand.Next(1, 5));
                            this.Stats.IncreaseBulletAmmonition(worldBullets[i].BulletsAmount);
                            worldBullets.RemoveAt(i--);
                            if (this.Stats.Ammonitions > 0)
                            {
                                Ship.CanShoot = true; 
                            }
                        }
                    }
                    // generate wall
                    if (nextWall == 0)
                    {
                        nextWall = Math.Max(10 + 10 / timeElapsed + rand.Next(6, 20), Ship.Width + 4);
                        worldWalls.Add(new Wall(FieldHeight, FieldWidth, wallPosition));
                        wallPosition = !wallPosition;
                    }
                    else
                    {
                        nextWall--;
                        //generate food
                        if (timeElapsed % 10 == 0) worldFood.Add(new Food(new Point(FieldWidth, rand.Next(0, FieldHeight - 4))));
                        //generate bullet
                        if (timeElapsed % 40 == 0) worldBullets.Add(new Bullet(new Point(FieldWidth, rand.Next(0, FieldHeight - 4))));
                    }

                    UpdateGameObjectList(worldWalls.Cast<GameObject>().ToList());
                    UpdateGameObjectList(worldFood.Cast<GameObject>().ToList());
                    UpdateGameObjectList(worldBullets.Cast<GameObject>().ToList());
                    UpdateGameObjectList(worldProjectiles.Cast<GameObject>().ToList());
                    Thread.Sleep(100);
                }
            };

            bwUpdateField.RunWorkerCompleted += (s, e) =>
            {
                if (!dead) 
                    bwUpdateField.RunWorkerAsync();
            };
            
        }

        void abilityTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            this.Ship.HasAbility = false;
            this.Ship.RemoveAbility();
        }

        void gameTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (this.Ship.HasAbility)
            {
                this.Ship.AbilitySeconds -= 1000;
                if (this.Ship.AbilitySeconds < 0)
                    this.Ship.AbilitySeconds = 0;
            }
            this.Stats.IncreaseTimeAndLevel();
        }
        public void InitializeGameEngine() //start the game
        {
            bwReadKey.RunWorkerAsync();
            bwUpdateField.RunWorkerAsync();
            Console.WriteLine();
            do
            {
                Console.Clear();
                RenderField();
                timeElapsed++;
                this.GameSleep = 150 - this.Stats.TimeElapsed;
                if (this.GameSleep < 20)
                    this.GameSleep = 20;
                Thread.Sleep(GameSleep);
                if (dead)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(this.FieldWidth/2,this.FieldHeight/2);
                    Console.WriteLine("GAME OVER YOUR SCORE IS {0}",this.Stats.Score);
                    Console.SetCursorPosition(this.FieldWidth / 2, (this.FieldHeight / 2)+1);
                    Console.WriteLine("YOUR GAME WILL CLOSE IN 2 SECONDS");
                    Thread.Sleep(2000);
                    Environment.Exit(-1);
                }
            }
            while (!dead);
            
        }        
        public void RenderField()
        {

            this.Stats.DrawStats(this.FieldWidth, this.FieldHeight);
            Ship.Draw(FieldHeight, FieldWidth);
            for(int i = 0; i < worldWalls.Count; i++) {
                worldWalls[i].Draw(FieldHeight, FieldWidth);
            }
            for(int i = 0; i < worldFood.Count; i++) {
                worldFood[i].Draw(FieldHeight, FieldWidth);
            }
            for (int i = 0; i < worldBullets.Count; i++)
            {
                worldBullets[i].Draw(FieldHeight, FieldWidth);
            }
            for (int i = 0; i < worldProjectiles.Count; i++)
            {
                worldProjectiles[i].Draw(FieldHeight, FieldWidth);
            }

        }

        public void UpdateGameObjectList(List<GameObject> list)
        {
            for(int i = 0; i < list.Count; i++)
            {
                list[i].UpdatePosition(new Point(list[i].Position.X - 1, list[i].Position.Y));
                if(!list[i].InField(FieldHeight, FieldWidth))
                    list.RemoveAt(i--);
            }
        }

    }
}
