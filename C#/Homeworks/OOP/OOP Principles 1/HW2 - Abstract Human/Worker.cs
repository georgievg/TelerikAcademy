using System;
using System.Collections.Generic;
using System.Threading;
using System.IO;
using System.Web;
using System.Net;
using System.Linq;
using System.Text;

namespace HW2___Abstract_Human
{
    //
    public class Worker : Human
    {
        public int WeekSalary { get;private set;}
        public int WorkHoursPerDay { get; private set; }
        public Worker(string name,string lastName,int weekSalary, int workHoursPerDay)
        {
            this.WeekSalary = weekSalary;
            this.Name = name;
            this.LastName = lastName;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public int MoneyPerHour()
        {
            return this.WeekSalary / this.WorkHoursPerDay;
        }
    }
}