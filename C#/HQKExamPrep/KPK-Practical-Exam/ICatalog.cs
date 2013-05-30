using System;
using System.Collections.Generic;
using System.Linq;

namespace FreeContentCatalog
{
    public interface ICatalog
    {
        /// <summary>
        /// Adds items of type IContent to the Catalog
        /// </summary>
        /// <param name="content">IContent item</param>
        void Add(IContent content);

        /// <summary>
        /// Returns a list of content found by title.
        /// </summary>
        /// <param name="title">Title to search for</param>
        /// <param name="numberOfContentElementsToList">Maximum number of elements to be returned</param>
        /// <returns>IEnumerable<IContent></returns>
        IEnumerable<IContent> GetListContent(string title, int numberOfContentElementsToList);

        /// <summary>
        /// Updates Content in the Catalog by finding it by url and changing it
        /// </summary>
        /// <param name="oldUrl">URL to search for</param>
        /// <param name="newUrl">URL to replace with</param>
        /// <returns></returns>
        int UpdateContent(string oldUrl, string newUrl);
    }
}
