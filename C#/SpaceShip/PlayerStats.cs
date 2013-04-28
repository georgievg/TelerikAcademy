using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaceShip
{
    public class PlayerStats
    {
        public int Score { get; private set; }
        public int Level { get; private set; }
        public int TimeElapsed { get; private set; }
        public int Ammonitions { get; private set; }
        private int tempTime;
        public PlayerStats()
        {
            this.Score = 0;
            this.Level = 1;
            this.TimeElapsed = 0;
        }
        public void IncreaseScore(int score)
        {
            this.Score +=score;
        }
        public void IncreaseBulletAmmonition(int ammunitions)
        {
            this.Ammonitions += ammunitions;
        }
        public void DecreaseBulletAmmonitions()
        {
            this.Ammonitions--;
        }
        public void IncreaseTimeAndLevel()
        {
            this.TimeElapsed++;
            tempTime++;
            if (tempTime == 60)
            {
                tempTime = 0;
                this.Level++;
            }
        }
        public void DrawStats(int fieldWidth,int fieldHeight)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(0, fieldHeight + 3);
            Console.Write("Score : {0} | Level : {1} | Time : {2}|Ammunitions:{3}", this.Score, this.Level, this.TimeElapsed,this.Ammonitions);
        }
    }
}