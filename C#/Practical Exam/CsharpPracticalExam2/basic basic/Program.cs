using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Lines
{
    public int LineNumber { get; set; }
    public string Code { get; set; }
}
class Program
{
    static List<Lines> BasicCode = new List<Lines>();
    static int V = 0;
    static int W = 0;
    static int X = 0;
    static int Y = 0;
    static int Z = 0;
    static void Main(string[] args)
    {
        string line = null;
        while ((line = Console.ReadLine()) != "RUN")
        {
            string num = null;
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i].ToString() != " ")
                {
                    num += line[i].ToString();
                }
                else
                {
                    line = line.Replace(num, "");
                    Lines code = new Lines();
                    code.LineNumber = int.Parse(num);
                    code.Code = line;
                    BasicCode.Add(code);
                    break;
                }
            }
        }
        for (int i = 0; i < BasicCode.Count; i++)
        {
            ExecuteLines(i);
        }

    }
    static void ExecuteLines(int line)
    {
        string command = BasicCode[line].Code;
        
    }
    static int ChangeVariables(int Variable,string line)
    {

        return 0;
    }
    static string PrintCommant(int ToPrint)
    {
        return null;
    }
    static string GotoCommand(int Line)
    {
        return null;
    }
}

