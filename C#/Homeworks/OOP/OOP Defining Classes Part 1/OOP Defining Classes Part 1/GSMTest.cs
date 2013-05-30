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
    public static class GSMTest
    {
        static Random rnd = new Random();
        public static string TestGSMs(int count,string iphoneInfo="Unknown")
        {
            StringBuilder sb = new StringBuilder();
            GSM[] GSMs = new GSM[count];
            for (int i = 0; i < GSMs.Length; i++)
            {
                GSM newGSM = new GSM((Models)rnd.Next(0, 8), "SomeManufacturer", rnd.Next(1000, 5000), new GSM.Battery(BatteryTypes.NiMH, rnd.Next(20, 2000), rnd.Next(10, 1000)), new GSM.Display(rnd.Next(200, 500), rnd.Next(200, 500), (Colors)rnd.Next(0, 9)));
                GSMs[i] = newGSM;
                sb.AppendLine(GSMs[i].ToString());
                sb.AppendLine();
            }
            GSM.Iphone4s = iphoneInfo;
            sb.AppendLine(GSM.Iphone4s);
            return sb.ToString();
        }
    }
}