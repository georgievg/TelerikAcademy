using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LinearDataStructures;

namespace LinkedListImplementation.Tests
{
    [TestClass]
    public class LinkedListTests
    {

        [TestMethod]
        public void Test10ItemsAndCountWithInt()
        {
            LinkedList<int> list = new LinkedList<int>();
            for (int i = 0; i < 10; i++)
            {
                list.AddFirst(i);
            }
            var expectedCount = 10;

            Assert.AreEqual(expectedCount, list.Count);
        }

        [TestMethod]
        public void Test23ItemsAndCountWithString()
        {
            LinkedList<string> list = new LinkedList<string>();
            for (int i = 0; i < 23; i++)
            {
                list.AddFirst(i.ToString());
            }

            var expectedCount = 23;

            Assert.AreEqual(expectedCount, list.Count);
        }

        [TestMethod]
        public void Test10ItemsAndBufferSizeWithInt()
        {
            LinkedList<int> list = new LinkedList<int>();
            for (int i = 0; i < 10; i++)
            {
                list.AddFirst(i);
            }
            var expectedBuffer = 20;

            Assert.AreEqual(expectedBuffer, list.BufferSize);
        }

        [TestMethod]
        public void Test20ItemsAndClear()
        {
            LinkedList<string> list = new LinkedList<string>();
            for (int i = 0; i < 20; i++)
            {
                list.AddFirst(i.ToString());
            }

            list.Clear();
            var expectedCount = 0;

            Assert.AreEqual(expectedCount, list.Count);
        }
    }
}
