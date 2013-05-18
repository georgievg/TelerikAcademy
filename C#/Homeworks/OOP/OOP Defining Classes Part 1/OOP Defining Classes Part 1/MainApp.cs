using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Defining_Classes_Part_1
{
    class MainApp
    {
        static Call newCall;
        static GSM newGSm = new GSM(Models.HTC, "Dunno");
        static Random rnd = new Random();
        static void Main()
        {
            CreateUserInterface();
            
        }

        private static void CreateUserInterface()
        {
            Console.WriteLine("Enter the number of the menu you want to choose :");
            Console.WriteLine("1. TestGSM");
            Console.WriteLine("2. Perform a Call");
            Console.WriteLine("3. Check Call History");
            Console.WriteLine("4. Calculate price of all calls");
            Console.WriteLine("5. Do a Call HIstory Test");
            int result = int.Parse(Console.ReadLine());
            switch (result)
            {
                case 1:
                    Console.WriteLine("How many GSMs to create?");
                    int res = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the IphoneInfo");
                    string iphoneRes = Console.ReadLine();
                    GSMTestMethod(res, iphoneRes);
                    GetBackToMainMenu();
                    break;
                case 2:                   
                    Console.WriteLine("Enter the mobile number you want to dial");
                    string number = Console.ReadLine();
                    newCall = new Call(number);
                    Console.WriteLine("The number {0} is being dialed press enter when you want to hang up",number);
                    Console.ReadLine();
                    newCall.HangUp();
                    newGSm.callHistory.Add(newCall);
                    Console.WriteLine("The call lasted {0} seconds",newCall.duration);                    
                    GetBackToMainMenu();
                    break;
                case 3:
                    foreach (var call in newGSm.callHistory)
                    {
                        Console.WriteLine(call.ToString());
                    }
                   
                    GetBackToMainMenu();
                    break;
                case 4:
                    double rndPrice = 0.59;
                    string totalPrice = newGSm.CalculatePrice(rndPrice);
                    Console.WriteLine("Your price for all calls is {0}",totalPrice);
                    break;
                case 5:
                    CallHIstoryTest.doTests();
                    break;
                default:                    
                    break;
            }
        }
        private static void GetBackToMainMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Do you want to get back to the main menu (y/n)");
            string answer = Console.ReadLine();
            if (answer == "y")
            {
                Console.Clear();
                CreateUserInterface();
            }
            else
                Environment.Exit(-1);
        }
        
        private static void GSMTestMethod(int count,string iphoneInfo="Unknown")
        {
            Console.WriteLine();
            Console.WriteLine(GSMTest.TestGSMs(count, iphoneInfo));
        }
        
    }
}
