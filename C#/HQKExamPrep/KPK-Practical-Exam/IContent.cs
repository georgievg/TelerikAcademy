using System;

namespace FreeContentCatalog
{
    public interface IContent : IComparable
    {
        /// <summary>
        /// The title of the current content
        /// </summary>
        string Title { get; set; }

        /// <summary>
        /// The author of the content
        /// </summary>
        string Author { get; set; }

        /// <summary>
        /// The size of the content
        /// </summary>
        long Size { get; set; }

        /// <summary>
        /// The url of the content
        /// </summary>
        string Url { get; set; }

        /// <summary>
        /// The command type to be executed over the content
        /// </summary>
        CommandType Type { get; set; }

        /// <summary>
        /// The text representation of the content
        /// </summary>
        string TextRepresentation { get; set; }
    }
}
