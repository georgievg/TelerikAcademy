using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;
namespace Problem_1___Clearn_Code
{
    class Program
    {
        static void Main(string[] args)
        { 
           
            StringBuilder buffer = new StringBuilder();
            int lines = int.Parse(Console.ReadLine());
            for (int i = 0; i < lines; i++)
            {
                buffer.Append(Console.ReadLine());
                buffer.AppendLine();
            }
            string text = buffer.ToString();
           // string text = @"class HardTest
           //                     {
           //                      public HardMethod()
           //                      {
           //                       string str = @""//not a 
           //                     comment ;)"";//(y)
           //                       string str2 = ""/*no\""oo\\oo*/"";/*noo*/
           //                      }
           //                     }""";
            bool isinMultyComment = false;
            bool isinString = false;
            char currChar;
            char nextChar;
            buffer.Clear();
            text = CheckForSimpleCommentsAndStrings(text, buffer);
            buffer.Clear();
            text = CheckForMultiLineComments(text, buffer);
            text = Regex.Replace(text, @"^\s*$\n", string.Empty, RegexOptions.Multiline);
            File.WriteAllText("text.txt", text);
            Console.WriteLine(text);
        }

        private static string CheckForMultiLineComments(string text, StringBuilder sb)
        {

            bool isinCode = true;
            bool isinMultyComment = false;
            bool isinString = false;
            char currChar;
            char nextChar;
            for (int i = 0; i < text.Length-1; i++)
            {
                currChar = text[i];
                nextChar = text[i + 1];
                if (!isinMultyComment && isinCode)
                {
                    if (isinString)
                    {
                        if (currChar != '\\' && nextChar == '"')
                        {
                            isinString = false;
                            isinCode = true;
                        }
                    }
                    else if (nextChar == '"')
                    {
                        isinString = true;
                        isinCode = true;
                        isinMultyComment = false;
                    }
                    
                }
                if (isinMultyComment)
                {
                    if (currChar == '*' && nextChar == '/')
                    {
                        isinMultyComment = false;
                        isinCode = true;
                        i++;
                        continue;
                    }
                }
                if (currChar == '/' && nextChar == '*' && !isinString)
                {
                    isinMultyComment = true;
                    isinCode = false;
                }
                if (isinCode && !isinMultyComment)
                {
                    sb.Append(currChar);
                }
            }
            int openingBrackets = 0;
            int closingBrackets = 0;
            for (int i = 0; i < sb.Length; i++)
            {
                if (sb[i] == '{')
                    openingBrackets++;
                else if (sb[i] == '}')
                    closingBrackets++;
            }
            if (closingBrackets < openingBrackets)
                sb.Append("}");
            return sb.ToString();
        }

        private static string CheckForSimpleCommentsAndStrings(string text,StringBuilder sb)
        {
            bool isinCode = true;
            bool isinComment = false;
            bool isinString = false;
            char currChar;
            char nextChar;
            for (int i = 0; i < text.Length-1; i++)
            {
                currChar = text[i];
                nextChar = text[i + 1];
                
                if (!isinComment && isinCode)
                {
                    if (isinString)
                    {
                        if (currChar != '\\' && nextChar == '"')
                        {
                            isinString = false;
                            isinCode = true;
                        }
                    }
                    else if (nextChar == '"')
                    {
                        isinString = true;
                        isinCode = true;
                        isinComment = false;
                    }
                    
                }
                
                
                if (isinComment)
                {
                    if (currChar == '\n' || nextChar == '\n')
                    {
                        isinComment = false;
                        isinCode = true;
                    }
                }
                if (currChar == '/' && nextChar == '/' && !isinString)
                {
                    isinComment = true;
                    isinCode = false;
                }

                if (isinCode && !isinComment)
                {
                    sb.Append(currChar);
                }

            }


            return sb.ToString();
        }

    }
}
