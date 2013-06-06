using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.File_FolderTree
{
    public class File
    {
        public string Name { get; set; }

        public int Size { get; set; }

        public File(string name) : this(name,0)
        {
            int size = this.CalculateFileSize(name);
            this.Size = size;
        }

        public File(string name, int size)
        {
            this.Name = name;
            this.Size = size;
        }

        private int CalculateFileSize(string name)
        {
            FileInfo fileInfo = new FileInfo(name);
            return (int)fileInfo.Length;
        }

        public override string ToString()
        {
            return string.Format("File Name: {0} \r\n File Size: {1}", this.Name, this.Size);
        }
    }
}