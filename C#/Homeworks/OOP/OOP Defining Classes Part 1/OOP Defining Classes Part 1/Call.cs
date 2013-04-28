using System;
using System.Collections.Generic;
using System.Threading;
using System.IO;
using System.Web;
using System.Net;
using System.Linq;
using System.Text;

namespace OOP_Defining_Classes_Part_1
{
    //Create a class Call to hold a call performed through a GSM. It should contain date, time, 
	//dialed phone number and duration (in seconds).

    public class Call
    {
        private DateTime start = DateTime.Now;
        public string date { get; private set; }
        public string time { get; private set; }
        public string numberToDial { get; private set; }
        public string duration { get; private set; }
        private bool inCall { get; set; }

        public Call(string numberToDial)
        {
            inCall = true;
            this.numberToDial = numberToDial;
            this.date = getDate();
            this.time = getTime();
        }
        

        public override string ToString()
        {
            string data = string.Format("You did a call at {0} : {1} to {2}, it lasted {3} seconds", this.date, this.time, this.numberToDial, this.duration);
            return data.ToString();
        }
        private string getTime()
        {
            DateTime now = DateTime.Now;

            return now.ToString("hh:mm");
        }
        private string getDate()
        {
            DateTime today = DateTime.Now;

            return today.ToString("dd/MM/yyyy");
        }
        public void HangUp()
        {
            inCall = false;
            DateTime end = DateTime.Now;
            var tempDuration = end - start;
            duration = tempDuration.Seconds.ToString();
            
        }
    }
}