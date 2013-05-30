using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeContentCatalog
{
    public class FreeContentCatalog
    {
        public static void Main()
        {
            StringBuilder output = new StringBuilder();
            Catalog catalog = new Catalog();
            ICommandExecutor commandExecutor = new CommandExecutor();

            var parsedCommands = ParseCommands();
            foreach (ICommand currentCommand in parsedCommands)
            {
                commandExecutor.ExecuteCommand(catalog, currentCommand, output);
            }

            Console.Write(output);
        }

        private static List<ICommand> ParseCommands()
        {
            List<ICommand> commands = new List<ICommand>();
            bool endCommand = false;

            do
            {
                string cmd = Console.ReadLine();
                endCommand = (cmd.Trim() == "End");
                if (!endCommand)
                {
                    commands.Add(new Command(cmd));
                }
            }
            while (!endCommand);

            return commands;
        }
    }   
}