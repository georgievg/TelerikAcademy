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
    public class GSM
    {
        //manufacturer, 
	    //price, owner, battery characteristics
        public Models model { get; private set; }
        public string manufacturer { get; private set; }
        public int price { get; private set; }
        public Battery battery { get; private set; }
        public static string Iphone4s { get; set; }
        public Display display { get; private set; }
        public List<Call> callHistory { get; set; }
        
        public GSM(Models model,string manufacturer)
            :this(model,manufacturer,0)
        {
            this.model = model;
            this.manufacturer = manufacturer;
            callHistory = new List<Call>();
        }
        public GSM(Models model, string manufacturer, int price)
            : this(model, manufacturer, price, null,null)
        {
            this.model = model;
            this.manufacturer = manufacturer;
            this.price = price;
        }
        public GSM(Models model, string manufacturer, int price, Battery battery,Display display)
        {
            this.model = model;
            this.manufacturer = manufacturer;
            this.price = price;
            this.battery = battery;
            this.display = display;
        }
        public string CalculatePrice(double price)
        {
            double time = 0;
            foreach (var call in this.callHistory)
            {
                string inMinutes = "0." + call.duration;
                time += double.Parse(inMinutes);
            }
            
            return (time * price).ToString();
            
        }
        public override string ToString()
        {
            int idle;
            int talk;
            BatteryTypes batteryType;
            Colors color;
            int width;
            int height;
            if (battery != null)
            {
                idle = battery.hoursIdle;
                talk = battery.hoursTalk;
                batteryType = battery.model;
                width = display.width;
                height = display.height;
                color = display.color;
            }
            else
            {
                idle = 0;
                talk = 0;
                batteryType = BatteryTypes.Unknown;
                width = 0;
                height = 0;
                color = Colors.Unknown;
            }

            string result = string.Format("Your phone's model is {0} it's manufactured by {1}, it costs {2} and has a {3} battery with {4} idle hours and {5} hours for talking, it's display width is {6}, height {7} and color {8}",
                this.model, this.manufacturer, this.price, batteryType, idle, talk,width,height,color);

            return result;
        }
        public class Battery
        {
            //model, hours idle and hours talk
            public BatteryTypes model { get; private set; }
            public int hoursIdle { get; private set; }
            public int hoursTalk { get; private set; }
            public Battery(BatteryTypes model, int hoursIdle, int hoursTalk)
            {
                this.model = model;
                this.hoursIdle = hoursIdle;
                this.hoursTalk = hoursTalk;
            }
        }
        public class Display
        {
            public int width { get; private set; }
            public int height { get; private set; }
            public Colors color { get; private set; }

            public Display(int width,int height,Colors color)
            {
                this.width = width;
                this.height = height;
                this.color = color;
            }
        }
        
    }
    public enum Colors
    {
        Black,
        White,
        Red,
        Blue,
        Cyan,
        DarkGray,
        Gray,
        Pink,
        Transparent,
        Green,
        Unknown
    }
    public enum BatteryTypes
    {
        Li_Ion, 
        NiMH, 
        NiCd,
        Unknown,
    }
    public enum Models
    {
        Nokia,
        Sony,
        HTC,
        Iphone,
        SonyEricsson,
        LG,
        Samsung,
        Koodo,

    }
}