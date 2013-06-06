using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _03.File_FolderTree
{
    class FileFolderTreeMain
    {
        static void Main()
        {
            Folder root = new Folder(@"C:/");
            Thread traverseThread = new Thread(() => TraverseDirectory(root));
            traverseThread.Start();
            Console.WriteLine("Press ENTER when you want to stop traversing(maybe if it takes too long)");
            Console.ReadLine();
            traverseThread.Suspend();

            Console.WriteLine("Please wait while building the Tree");
            StringBuilder treeOutput = new StringBuilder();
            BuildTree(treeOutput, root);

            Console.WriteLine("Tree building ready, if you want to save it to a file simply type it's path in the console,"+
                "else just press enter to print it on the console(it might take a while)");
            string userInput = Console.ReadLine();

            if (string.IsNullOrEmpty(userInput))
            {
                Console.WriteLine(treeOutput);
            }
            else
            {
                using (StreamWriter writer = new StreamWriter(userInput))
                {
                    writer.WriteLine(treeOutput);
                }
            }

            Console.WriteLine("All Done");
        }

        private static void BuildTree(StringBuilder treeOutput, Folder root)
        {
            foreach (var folder in root.Folders)
            {
                treeOutput.Append(folder.ToString());
                BuildTree(treeOutput, folder);
            }
        }

        private static void TraverseDirectory(Folder root)
        {
            string[] folders = new string[0];
            string[] files = new string[0];
            try
            {
                folders = Directory.GetDirectories(root.Name);
                files = Directory.GetFiles(root.Name);
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine(ex.Message);
            }

            foreach (var file in files)
            {
                root.Files.Add(new File(file));
            }

            foreach (var folder in folders)
            {
                Folder currentFolder = new Folder(folder);
                root.Folders.Add(currentFolder);
                TraverseDirectory(currentFolder);
            }
        }
    }
}