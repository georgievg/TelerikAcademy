using System;
using System.Linq;

namespace FreeContentCatalog
{
    public interface ICommand
    {
        /// <summary>
        /// The type of the command to be executed
        /// </summary>
        CommandAction Type { get; set; }

        /// <summary>
        /// The original form of the command
        /// </summary>
        string OriginalForm { get; set; }

        /// <summary>
        /// Name of the command
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// The parameters extracted from the raw command
        /// </summary>
        string[] Parameters { get; set; }

        /// <summary>
        /// Parses a command by it's name and returns the type of the next action
        /// </summary>
        CommandAction ParseCommandType(string commandName);

        /// <summary>
        /// Finds the name of the command
        /// </summary>
        string ParseName();

        /// <summary>
        /// Extracts the parameters from the command
        /// </summary>
        /// <returns></returns>
        string[] ParseParameters();
    }
}
