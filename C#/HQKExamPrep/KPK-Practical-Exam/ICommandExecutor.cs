using System;
using System.Linq;
using System.Text;

namespace FreeContentCatalog
{
    public interface ICommandExecutor
    {
        /// <summary>
        /// Exectutes a command
        /// </summary>
        /// <param name="contentCatalog">The catalog to be executed over</param>
        /// <param name="command">The Parsed command</param>
        /// <param name="output">The output </param>
        void ExecuteCommand(ICatalog contentCatalog, ICommand command, StringBuilder output);
    }
}
