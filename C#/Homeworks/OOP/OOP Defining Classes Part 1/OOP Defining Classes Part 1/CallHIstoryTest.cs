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
    //
    public static class CallHIstoryTest
    {
        static Random rnd = new Random(); 
        public static void doTests()
        {
            GSM newGSm = new GSM(Models.Iphone, "Dunno");
            Console.WriteLine("Phone Created");
            Console.WriteLine("Please wait while generating calls...");                       
            int rndCallsAmount = rnd.Next(2,10);
            for (int i = 0; i < rndCallsAmount ; i++)
            {
                string number = (rnd.Next(500000, 700000)).ToString(); 
                Call newCall = new Call(number);
                int rndThreadSleep = rnd.Next(1000,6000);
                Thread.Sleep(rndThreadSleep);
                newCall.HangUp();
                newGSm.callHistory.Add(newCall);
            }
            Console.WriteLine("Calls generated");
            Console.WriteLine("Writing info");
            foreach (var call in newGSm.callHistory)
            {
                Console.WriteLine(call);
            }
            Console.WriteLine();
            Console.WriteLine("Calculating price for 0.37 per minute");
            string price = newGSm.CalculatePrice(0.37);
            Console.WriteLine("Price is {0}",price);
            Console.WriteLine("Findign and removing the longest call");
            double longestCall = 0;
            int index = 0;
            for (int i = 0; i < newGSm.callHistory.Count; i++)
            {
                if (double.Parse(newGSm.callHistory[i].duration) > longestCall)
                {
                    longestCall = double.Parse(newGSm.callHistory[i].duration);
                    index = i;
                }
            }
            newGSm.callHistory.RemoveAt(index);
            Console.WriteLine("Recalculating price");
            price = newGSm.CalculatePrice(0.37);
            Console.WriteLine("Price is {0}", price);
            newGSm.callHistory.Clear();
            Console.WriteLine("History Cleared");
            
        }
    }
    
}