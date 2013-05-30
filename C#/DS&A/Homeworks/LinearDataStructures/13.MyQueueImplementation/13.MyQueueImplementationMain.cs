using System;
using System.Collections.Generic;

namespace _13.MyQueueImplementation
{
    class Program
    {
        static void Main()
        {
            MyQueue<int> qu = new MyQueue<int>();
            qu.Enqueue(5);
            qu.Enqueue(5);
            qu.Enqueue(5);
            var d = qu.Dequeue();                
        }
    }
}
