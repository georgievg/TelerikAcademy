using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyStackImplementation;

namespace MyStackImplementation.Tests
{
    [TestClass]
    public class MyStackTests
    {
        [TestMethod]
        public void TestAddOneInt()
        {
            MyStack<int> stack = new MyStack<int>();
            stack.Push(5);

            var expectedCount = 1;

            Assert.AreEqual(expectedCount, stack.Count);
        }

        [TestMethod]
        public void TestAdd10Int()
        {
            MyStack<int> stack = new MyStack<int>();
            for (int i = 0; i < 10; i++)
            {                
                stack.Push(i);
            }

            var expectedCount = 10;

            Assert.AreEqual(expectedCount, stack.Count);
        }

        [TestMethod]
        public void TestAdd10IntAndTestPeek()
        {
            MyStack<int> stack = new MyStack<int>();
            for (int i = 0; i < 10; i++)
            {
                stack.Push(i);
            }

            var expectedPeek = 9;
            var actualPeek = stack.Peek;
            Assert.AreEqual(expectedPeek, actualPeek);
        }

        [TestMethod]
        public void TestAdd10IntAndTestPop()
        {
            MyStack<int> stack = new MyStack<int>();
            for (int i = 0; i < 10; i++)
            {
                stack.Push(i);
            }

            var expectedCount = 9;
            stack.Pop();
            Assert.AreEqual(expectedCount, stack.Count);
        }
    }
}
