using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FreeContentCatalog;
using System.Linq;

namespace FreeContentCatalog.Tests
{
    [TestClass]
    public class CatalogTests
    {
        [TestMethod]
        public void TestWithSingleItem()
        {
            Catalog catalog = new Catalog();
            var commandString = "Add application: Firefox v.11.0; Mozilla; 16148072; http://www.mozilla.org ";
            Command cmd = new Command(commandString.Trim());
            string[] parameters = cmd.Parameters;
            Content book = new Content(CommandType.Application, parameters);
            catalog.Add(book);

            var expected = 1;
            var actual = catalog.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestWithTwoDifferentItems()
        {
            Catalog catalog = new Catalog();
            var appCommandString = "Add application: Firefox v.11.0; Mozilla; 16148072; http://www.mozilla.org ";
            Command appCmd = new Command(appCommandString.Trim());
            string[] applicationParamenters = appCmd.Parameters;
            string bookCommandString = "Add book: Intro C#; S.Nakov; 12763892; http://www.introprogramming.info";
            Command bookCmd = new Command(bookCommandString);
            string[] bookParameters = bookCmd.Parameters;
            Content application = new Content(CommandType.Application, applicationParamenters);
            Content book = new Content(CommandType.Book, bookParameters);
            catalog.Add(application);
            catalog.Add(book);

            var expected = 2;
            var actual = catalog.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestWithTwoAqualItems()
        {
            Catalog catalog = new Catalog();
            var appCommandString = "Add application: Firefox v.11.0; Mozilla; 16148072; http://www.mozilla.org ";
            Command appCmd = new Command(appCommandString.Trim());
            string[] applicationParamenters = appCmd.Parameters;
            Content application = new Content(CommandType.Application, applicationParamenters);
            Content secondApplication = new Content(CommandType.Application, applicationParamenters);
            catalog.Add(application);
            catalog.Add(secondApplication);

            var expected = 2;
            var actual = catalog.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestIfTwoItemsAreIdenticalAfterFind()
        {
            Catalog catalog = new Catalog();
            var appCommandString = "Add application: Firefox v.11.0; Mozilla; 16148072; http://www.mozilla.org ";
            Command appCmd = new Command(appCommandString.Trim());
            string[] applicationParamenters = appCmd.Parameters;
            Content application = new Content(CommandType.Application, applicationParamenters);
            catalog.Add(application);
            catalog.Add(application);
            var firstApp = catalog.GetListContent("Firefox v.11.0", 1).ToArray()[0];
            var secondApp = catalog.GetListContent("Firefox v.11.0", 1).ToArray()[0];

            Assert.AreSame(firstApp,secondApp);
        }

        [TestMethod]
        public void UpdateContentOfOneItem()
        {
            Catalog catalog = new Catalog();
            var commandString = "Add application: Firefox v.11.0; Mozilla; 16148072; http://www.mozilla.org ";
            Command cmd = new Command(commandString.Trim());
            string[] parameters = cmd.Parameters;
            Content book = new Content(CommandType.Application, parameters);
            catalog.Add(book);
            catalog.UpdateContent("http://www.mozilla.org", "http://yahoo.com");

            var expected = "http://yahoo.com";
            var actual = catalog.GetListContent("Firefox v.11.0", 1).ToArray()[0].Url;

            Assert.AreEqual(expected, actual);
        }
    }
}
