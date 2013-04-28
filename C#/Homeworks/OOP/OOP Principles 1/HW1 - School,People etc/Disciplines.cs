using System;
using System.Collections.Generic;
using System.Threading;
using System.IO;
using System.Web;
using System.Net;
using System.Linq;
using System.Text;

namespace HW1___School_People_etc
{
    //
    public class Disciplines
    {
        private string Name { get; set; }
        private int NumberOfLectures { get; set; }
        private int NumberOfExercises { get; set; }

        public Disciplines(string name, int numberOfLectures, int numberOfExercises)
        {
            this.Name = name;
            this.NumberOfLectures = numberOfLectures;
            this.NumberOfExercises = NumberOfExercises;
        }
    }
}