using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.ExtractOddNumbers
{
    class ExtractMain
    {
        static void Main()
        {
            var str = "C#, SQL, PHP, PHP, SQL, SQL";
            var splitted = str.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
            var words = new Dictionary<string, int>();

            for (int i = 0; i < splitted.Length; i++)
            {
                var count = 1;
                if (words.ContainsKey(splitted[i]))
                {
                    count = words[splitted[i]] + 1;
                }

                words[splitted[i]] = count;
            }

            foreach (var keyVal in words)
            {
                if (keyVal.Value % 2 != 0)
                {
                    Console.WriteLine(keyVal.Key);
                }
            }
        }
    }
}
