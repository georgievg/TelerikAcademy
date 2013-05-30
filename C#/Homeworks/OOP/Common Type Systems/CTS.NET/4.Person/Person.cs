using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _4.Person
{
    public class Person
    {
        private string name;
        private int? age;
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (value == null)
                {
                    throw new NullReferenceException("Name can not be null");
                }
                this.name = value;
            }
        }
        public int? Age
        {
            get
            {
                return this.age;
            }
            private set
            {
                if (value < 0 || value > 110)
                {
                    throw new IndexOutOfRangeException("Age is not valid, person is probably dead");
                }
                this.age = value;
            }
        }
        public Person(string name, int? age)
        {
            this.Name = name;
            this.Age = age;
        }
        public Person(string name)
            : this(name, null)
        {
        }
        public override string ToString()
        {
            string data = string.Format("The person's name is {0}, it's age is ", this.Name);
            if (this.Age == null)
            {
                data += "not specified";
            }
            else
            {
                data += this.Age.ToString();
            }
            return data;
        }
    }
}