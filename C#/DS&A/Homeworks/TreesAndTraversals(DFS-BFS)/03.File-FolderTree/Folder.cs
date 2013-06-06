using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.File_FolderTree
{
    public class Folder
    {
        public string Name { get; set; }

        public List<File> Files { get; set; }

        public List<Folder> Folders { get; set; }

        public Folder(string name, File[] files,
            Folder[] folders) : this(name)
        { 
            this.Files.AddRange(files);
            this.Folders.AddRange(folders);
        }

        public Folder(string name, List<File> files, List<Folder> folders) 
            : this(name,files.ToArray(),folders.ToArray())
        {
        }

        public Folder(string name)
        {
            this.Files = new List<File>();
            this.Folders = new List<Folder>();
            this.Name = name;
        }

        public override string ToString()
        {
            return string.Format("Folder Name: {0} \r\n Files: {1} \r\n Folders: {2}", 
                this.Name, string.Join(", ", this.Files), string.Join(", ", this.Folders));
        }
    }
}