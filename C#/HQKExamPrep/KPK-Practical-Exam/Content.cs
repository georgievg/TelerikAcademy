using System;
using System.Linq;

namespace FreeContentCatalog
{
    public class Content : IComparable, IContent
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public Int64 Size { get; set; }

        private string url;

        public string Url
        {
            get
            {
                return this.url;
            }
            set
            {
                this.url = value;
                this.TextRepresentation = this.ToString();
            }
        }

        public CommandType Type { get; set; }

        public string TextRepresentation { get; set; }

        public Content(CommandType commandType, string[] commandParams)
        {
            this.Type = commandType;
            this.Title = commandParams[(int)ExtraInfo.Title];
            this.Author = commandParams[(int)ExtraInfo.Author];
            this.Size = long.Parse(commandParams[(int)ExtraInfo.Size]);
            this.Url = commandParams[(int)ExtraInfo.Url];
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }

            Content otherContent = obj as Content;
            if (otherContent != null)
            {
                int comparisonResul = this.TextRepresentation.CompareTo(otherContent.TextRepresentation);
                return comparisonResul;
            }

            throw new ArgumentException("Object is not a Content");
        }

        public override string ToString()
        {
            string output = String.Format("{0}: {1}; {2}; {3}; {4}",
                this.Type.ToString(), this.Title, this.Author, this.Size, this.Url);

            return output;
        }
    }
}
