using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    class Position
    {
        public int Value { get; set; }
        public string PositionName { get; set; }
    }
    class Employees
    {
       public string FirstName { get; set; }
       public string SecondName { get; set; }
       public string Position { get; set; }
    }
    class Program
    {
        static List<Position> Positions = new List<Position>();
        static List<Employees> EmployeesList = new List<Employees>();
        static List<Employees> SortedEmployees = new List<Employees>();
        static StringBuilder sb = new StringBuilder();
        static void Main(string[] args)
        {
            Readinput();
            Positions.Sort((a, b) => a.Value.CompareTo(b.Value));//Sort Array
            Positions.Reverse();//Reverse to Descending Order
            SortEmployees(EmployeesList);
            List<Employees> sortByFirstName = new List<Employees>();
            string name = null;
            string prevname = null;
            PrintEmployees(SortedEmployees);
            
        }

        private static void PrintEmployees(List<Employees> empls)
        {
            foreach (var empl in empls)
            {
                sb.AppendLine(empl.FirstName + " " + empl.SecondName);
                
            }
            Console.WriteLine(sb);
        }
        static void SortEmployees(List<Employees> employees)
        {
            int prevPos = 0;
            List<Employees> tempEmpl = new List<Employees>();
            foreach (var pos in Positions)
            {
                for (int i = 0; i < employees.Count; i++)
                {
                    if (i > 0)
                        prevPos = i - 1;
                    if (pos.PositionName == employees[i].Position.Trim())
                    {
                        Employees empl = new Employees();
                        empl.Position = employees[i].Position;
                        empl.FirstName = employees[i].FirstName;
                        empl.SecondName = employees[i].SecondName;
                        if (empl.Position == employees[prevPos].Position && i > 0)
                        {
                            SortedEmployees.RemoveAt(SortedEmployees.Count - 1);
                            tempEmpl.Add(employees[i]);
                            tempEmpl.Add(employees[prevPos]);
                            tempEmpl.Sort((a, b) => a.SecondName.CompareTo(b.SecondName));
                            foreach (var worker in tempEmpl)
                            {
                                if (!SortedEmployees.Contains(worker))
                                {
                                    SortedEmployees.Add(worker);
                                }
                            }
                        }
                        else
                        {
                            if (!SortedEmployees.Contains(empl))
                            {
                                SortedEmployees.Add(empl);
                            }
                        }
                    }
                }
            }
        }
        private static void Readinput()
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                string[] splitted = line.Split('-');
                Position pos = new Position();
                pos.PositionName = splitted[0].Trim();
                pos.Value = int.Parse(splitted[1].Trim());
                Positions.Add(pos);
            }
            int m = int.Parse(Console.ReadLine());
            for (int i = 0; i < m; i++)
            {
                string line = Console.ReadLine();
                string[] splitted = line.Split('-');
                Employees employee = new Employees();
                string name = splitted[0];
                string[] Names = name.Split(' ');
                employee.FirstName = Names[0];
                employee.SecondName = Names[1];
                employee.Position = splitted[1];
                EmployeesList.Add(employee);
            }
        }

        
    }
}
