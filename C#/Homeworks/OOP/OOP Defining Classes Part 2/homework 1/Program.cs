using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework_1
{
    [Version2("2.13")]
    class Program
    {
        static void Main(string[] args)
        {
            GenericList<int> asd = new GenericList<int>();
            for (int i = 0; i < 30; i++)
            {
                asd.Add(i);
            }
            asd.RemoveAt(5);
            Console.WriteLine(asd);
            asd.insertAt(4, 99);
            Console.WriteLine(asd);
            asd.Clear();
            Matrix<double> dsa = new Matrix<double>(4,5);
            Matrix<double> okp = new Matrix<double>(4, 5);
            Matrix<double> ffff = new Matrix<double>(4, 5);
            ffff = dsa + okp;
            
        }
        static string getVersion()
        {
            Type type = typeof(Program);
            object[] attributes = type.GetCustomAttributes(false);
            foreach (var attr in attributes)
            {
                return attr.ToString();
            }
            return "";
        }
    }
}
