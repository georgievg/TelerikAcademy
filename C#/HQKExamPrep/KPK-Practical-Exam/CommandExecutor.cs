using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeContentCatalog
{
    public class CommandExecutor : ICommandExecutor
    {
        public void ExecuteCommand(ICatalog catalog, ICommand cmd, StringBuilder output)
        {
            switch (cmd.Type)
            {
                case CommandAction.AddBook:
                    catalog.Add(new Content(CommandType.Book, cmd.Parameters));
                    output.AppendLine("Book added");
                    break;
                case CommandAction.AddMovie:
                    catalog.Add(new Content(CommandType.Movie, cmd.Parameters));
                    output.AppendLine("Movie added");
                    break;
                case CommandAction.AddSong:
                    catalog.Add(new Content(CommandType.Song, cmd.Parameters));
                    output.AppendLine("Song added");
                    break;
                case CommandAction.AddApplication:
                    catalog.Add(new Content(CommandType.Application, cmd.Parameters));
                    output.AppendLine("Application added");
                    break;
                case CommandAction.Update:
                    ExecuteUpdateCommand(cmd, catalog, output);
                    break;
                case CommandAction.Find:
                    ExecuteFindCommand(cmd, catalog, output);
                    break;
                default:
                    throw new ArgumentException("Unknown command - " + cmd);
            }
        }
  
        private void ExecuteFindCommand(ICommand cmd, ICatalog catalog, StringBuilder output)
        {
            if (cmd.Parameters.Length != 2)
            {
                throw new ArgumentException("Invalid number of parameters - " + cmd.Parameters.Length);
            }

            int numberOfElementsToList = int.Parse(cmd.Parameters[1]);
            IEnumerable<IContent> foundContent = catalog.GetListContent(cmd.Parameters[0], numberOfElementsToList);
            if (foundContent.Count() == 0)
            {
                output.AppendLine("No items found");
            }
            else
            {
                foreach (IContent content in foundContent)
                {
                    output.AppendLine(content.TextRepresentation);
                }
            }
        }
  
        private void ExecuteUpdateCommand(ICommand cmd, ICatalog catalog, StringBuilder output)
        {
            if (cmd.Parameters.Length != 2)
            {
                throw new ArgumentException("Invalid Command - " + cmd);
            }

            output.AppendLine(String.Format("{0} items updated", catalog.UpdateContent(cmd.Parameters[0], cmd.Parameters[1])));
        }
    }
}
