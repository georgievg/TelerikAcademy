using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceShip
{
    public class Ship : GameObject, ICollidable
    {
        Random rnd = new Random();
        public int Score { get; set; }
        public bool HasAbility { get; set; }
        public bool CanShoot { get; set; }
        public int AbilitySeconds { get; set; }
        public Abilities Ability { get; set; }
        public Ship(Point initialPosition)
            : base(initialPosition)
        {
            FillBody();
            Score = 0;
            this.CanShoot = false;
            this.HasAbility = false;
            IsCollidable = true;
            objColor = ConsoleColor.Yellow; // Set the object Color
        }
        public override void Draw(int fieldHeight, int fieldWidth)
        {
            var random = new Random();
            int x = Position.X; // because the position could be updated during the execution of the draw method
            int y = Position.Y; // because the position could be updated during the execution of the draw method
            int i, j;
            if (this.HasAbility)
            {
                if (this.Position.X > 2)
                {
                    Console.SetCursorPosition(this.Position.X - 2, this.Position.Y + 1);
                    Console.Write(MillisecondsConverter.ConvertSecondsToMinutes(this.AbilitySeconds));
                }
                if (this.Position.Y > 2)
                {
                    Console.SetCursorPosition(this.Position.X, this.Position.Y - 2);
                    if (this.Ability == Abilities.Invincibility)
                    {
                        Console.Write("INVINC.");
                    }
                }
            }
            for (i = y; i < y + Height && i < fieldHeight; i++)
            {
                if (i < 0)
                    continue;
                for (j = x; j < x + Width && j < fieldWidth; j++)
                {
                    if (j < 0)
                        continue;
                    Console.ForegroundColor = this.objColor;
                    Console.SetCursorPosition(j, i);
                    Console.Write(this.Body[i - y, j - x]);
                }
            }
            Console.ForegroundColor = (ConsoleColor)random.Next((int)ConsoleColor.Black, (int)ConsoleColor.White);

        }

        public void GrandAbility(Abilities ability)
        {
            if (ability == Abilities.Invincibility)
            {
                this.Ability = ability;
                this.Body = new char[,]
                {
                    {'{','}','-','-'},
                    {'|','|','-','>'},
                    {'{','}','-','-'}
                };
                this.IsCollidable = false;
            }
        }
        public void RemoveAbility()
        {
            this.Body = new char[,] 
            {
            {'[',']','-','-'},
            {'|','|','=','>'},
            {'[',']','-','-'}};

            this.IsCollidable = true;

        }
        public override void FillBody()
        {
            Body = new char[,] 
            {
            {'[',']','-','-'},
            {'|','|','=','>'},
            {'[',']','-','-'}};     //ship            


            IsCollidable = true;
            IsDestructible = true;
        }
    }
}

//    []         (^,^)   
//    ||>=<     (     )  
//    []          / \     