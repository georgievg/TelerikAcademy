using System;
using System.Collections.Generic;
using System.Threading;
using System.IO;
using System.Web;
using System.Net;
using System.Linq;
using System.Text;

namespace HW3___Animals
{
    //
    public class Dog : Animals
    {
        public Dog(string name, string sex, int age)
        {
            this.Name = name;
            this.Sex = sex;
            this.Age = age;
        }
        public string Walk()
        {
            return string.Format("{0} is walking",this.Name);
        }
        public string WaveTale()
        {
            return string.Format("{0} is waving tale",this.Name);
        }
        public override string ProduceSound()
        {
           return string.Format("{0} is barking",this.Name);
        }
    }
}