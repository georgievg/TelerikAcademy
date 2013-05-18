using System;

namespace UnitTesting
{
    public class Student
    {
        private string name;
        private int uniqueId;
        private School school;
        private Random rnd = new Random();

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (value == null || value == string.Empty)
                {
                    throw new ArgumentNullException("Name can not be empty");
                }
                this.name = value;
            }
        }
        public int UniqueID
        {
            get
            {
                return this.uniqueId;
            }
            private set
            {
                if (value < 10000 || value > 99999)
                {
                    throw new ArgumentException("Unique id must be between 10000 and 99999");
                }
                this.uniqueId = value;
            }
        }

        public Student(string name,School school)
        {
            this.Name = name;
            this.school = school;
            int id = GenerateUniqueId();
            this.UniqueID = id;
        }

        private int GenerateUniqueId()
        {
            int rndIn = 0;
            do
            {
                rndIn = rnd.Next(10000, 99999);
            }
            while (this.school.ContainsId(rndIn));
            
            return rndIn;
        }
    }
}
