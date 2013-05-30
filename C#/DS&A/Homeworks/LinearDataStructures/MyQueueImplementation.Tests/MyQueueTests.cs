using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _13.MyQueueImplementation;

namespace MyQueueImplementation.Tests
{
    [TestClass]
    public class MyQueueTests
    {
        [TestMethod]
        public void Test10ItemsAndCountWithIntQueue()
        {
            MyQueue<int> list = new MyQueue<int>();
            for (int i = 0; i < 10; i++)
            {
                list.Enqueue(i);
            }
            var expectedCount = 10;

            Assert.AreEqual(expectedCount, list.Count);
        }

        [TestMethod]
        public void Test23ItemsAndCountWithStringQueue()
        {
            MyQueue<string> list = new MyQueue<string>();
            for (int i = 0; i < 23; i++)
            {
                list.Enqueue(i.ToString());
            }

            var expectedCount = 23;

            Assert.AreEqual(expectedCount, list.Count);
        }

        [TestMethod]
        public void Test10ItemsAndBufferSizeWithIntQueue()
        {
            MyQueue<int> list = new MyQueue<int>();
            for (int i = 0; i < 10; i++)
            {
                list.Enqueue(i);
            }
            var expectedBuffer = 20;

            Assert.AreEqual(expectedBuffer, list.BufferSize);
        }

        [TestMethod]
        public void Test20ItemsAndClear()
        {
            MyQueue<string> list = new MyQueue<string>();
            for (int i = 0; i < 20; i++)
            {
                list.Enqueue(i.ToString());
            }

            list.Clear();
            var expectedCount = 0;

            Assert.AreEqual(expectedCount, list.Count);
        }

        [TestMethod]
        public void Test20ItemsAndDequeue()
        {
            MyQueue<string> list = new MyQueue<string>();
            for (int i = 0; i < 20; i++)
            {
                list.Enqueue(i.ToString());
            }

            list.Dequeue();
            var expectedCount = 19;

            Assert.AreEqual(expectedCount, list.Count);
        }
    }
}
