using System;
using System.Linq;

namespace FreeContentCatalog
{
    public class Command : ICommand
    {
        private readonly char[] paramsSeparators = { ';' };
        private readonly char commandEnd = ':';
        private int commandNameEndIndex;

        public CommandAction Type { get; set; }
        public string OriginalForm { get; set; }
        public string Name { get; set; }
        public string[] Parameters { get; set; }

        public Command(string input)
        {
            this.OriginalForm = input.Trim();
            this.ParseCmd();
        }

        private void ParseCmd()
        {
            this.commandNameEndIndex = this.GetCommandNameEndIndex();
            this.Name = this.ParseName();
            this.Parameters = this.ParseParameters();
            this.TrimParams();
            this.Type = this.ParseCommandType(this.Name);
        }

        public CommandAction ParseCommandType(string commandName)
        {
            if (commandName.Contains(':') || commandName.Contains(';'))
            {
                throw new ArgumentException("Command can not contain ';' or ':'");
            }

            switch (commandName.Trim())
            {
                case "Add book":
                    return CommandAction.AddBook;
                case "Add movie":
                    return CommandAction.AddMovie;
                case "Add song":
                    return CommandAction.AddSong;
                case "Add application":
                    return CommandAction.AddApplication;
                case "Update":
                    return CommandAction.Update;
                case "Find":
                    return CommandAction.Find;
                default:
                    throw new ArgumentException("Invalid command name - " + commandName.Trim());

            }
        }

        public string ParseName()
        {
            string name = this.OriginalForm.Substring(0, this.commandNameEndIndex + 1);
            return name;
        }

        public string[] ParseParameters()
        {
            int paramsLength = this.OriginalForm.Length - (this.commandNameEndIndex + 3);
            string paramsOriginalForm = this.OriginalForm.Substring(this.commandNameEndIndex + 3, paramsLength);
            string[] parameters = paramsOriginalForm.Split(paramsSeparators, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < parameters.Length; i++)
            {
                parameters[i] = parameters[i];
            }

            return parameters;
        }

        public int GetCommandNameEndIndex()
        {
            int endIndex = this.OriginalForm.IndexOf(commandEnd) - 1;
            return endIndex;
        }

        private void TrimParams()
        {
            for (int i = 0; ; i++)
            {
                if (!(i < this.Parameters.Length))
                {
                    break;
                }
                this.Parameters[i] = this.Parameters[i].Trim();
            }
        }

        public override string ToString()
        {
            string toString = "" + this.Name + " ";

            foreach (string param in this.Parameters)
            {
                toString += param + " ";
            }
            return toString;
        }
    }
}
