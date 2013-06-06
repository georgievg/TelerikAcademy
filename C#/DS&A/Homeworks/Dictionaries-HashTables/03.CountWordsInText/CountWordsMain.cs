using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace _03.CountWordsInText
{
    class CountWordsMain
    {
        static void Main()
        {            
            string textPath = "words.txt";
            var words = new Dictionary<string, int>();
            using (StreamReader sr = new StreamReader(textPath))
            {
                string line = sr.ReadLine();
                while (line != null)
                {
                    string[] wordsFromLine = line.Split(new char[] { ' ', ',', '.', '!', '@', '?' },
                        StringSplitOptions.RemoveEmptyEntries);
                    foreach (var word in wordsFromLine)
                    {
                        var count = 1;
                        if (words.ContainsKey(word))
                        {
                            count = words[word] + 1;
                        }

                        words[word] = count;
                    }

                    line = sr.ReadLine();
                }
            }

            List<KeyValuePair<string, int>> sortedWords = words.ToList();
            sortedWords.Sort((first, second) =>
                                {
                                    return first.Value.CompareTo(second.Value);
                                });

            foreach (var word in sortedWords)
            {
                Console.WriteLine("{0} -> {1}",word.Key,word.Value);
            }


        }
    }
}
