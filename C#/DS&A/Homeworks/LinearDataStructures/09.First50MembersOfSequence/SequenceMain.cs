using System;
using System.Collections.Generic;
using System.Text;

namespace _09.First50MembersOfSequence
{
    class SequenceMain
    {
        static void Main()
        {
            int m = 50;
            int n = 2;
            int current = n;
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(current);
            StringBuilder output = new StringBuilder();

            for (int i = 1; i <= m; i++)
            {
                current = queue.Dequeue();

                queue.Enqueue(current + 1);
                queue.Enqueue((current * 2) + 1);
                queue.Enqueue(current + 2);

                output.AppendFormat("{0} ,", current);
            }

            Console.WriteLine(output);

        }
    }
}
