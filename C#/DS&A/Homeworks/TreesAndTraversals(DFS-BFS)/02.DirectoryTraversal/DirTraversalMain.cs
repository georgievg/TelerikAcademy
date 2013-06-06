using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _02.DirectoryTraversal
{
    public class DirTraversalMain
    {
        private static List<string> files = new List<string>();

        static void Main()
        {
            var dirToTraverse = Path.GetPathRoot(Environment.SystemDirectory) +
                                Environment.SpecialFolder.Windows.ToString();

            Console.WriteLine("Traversing {0}", dirToTraverse);
            TraverseDirectory(dirToTraverse, "*.exe");
            File.WriteAllText("files.txt",string.Join("\r\n", files));
            Console.WriteLine("All written in files.txt");
        }

        private static void TraverseDirectory(string dirToTraverse, string extension)
        {
            string[] filesInDir = new string[0];
            string[] dirs = new string[0];
            try
            {
                filesInDir = Directory.GetFiles(dirToTraverse, extension);
            }
            catch (UnauthorizedAccessException ex)
            {
                files.Add(ex.Message);
            }

            files.AddRange(filesInDir);

            try
            {
                dirs = Directory.GetDirectories(dirToTraverse);
            }
            catch (UnauthorizedAccessException ex)
            {
                files.Add(ex.Message);
            }

            foreach (var dir in dirs)
            {
                TraverseDirectory(dir, extension);
            }
        }
    }
}