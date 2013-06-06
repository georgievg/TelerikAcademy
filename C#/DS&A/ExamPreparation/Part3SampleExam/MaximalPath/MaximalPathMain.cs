using System;
using System.Collections.Generic;

namespace MaximalPath
{
    public class MaximalPathMain
    {
        private static long maxSum = 0;
        private static HashSet<Node> usedNodes = new HashSet<Node>();

        private static void TraverseForMaxSum(Node node, long sum)
        {
            sum += node.Value;
            usedNodes.Add(node);

            foreach (var child in node.Children)
            {
                if (!usedNodes.Contains(child))
                {
                    TraverseForMaxSum(child, sum);
                }
            }

            if (sum > maxSum)
            {
                maxSum = sum;
            }
        }

        public static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            Dictionary<int, Node> nodesList = ReadInput(N);

            foreach (var node in nodesList)
            {
                if (node.Value.Children.Count == 1)
                {
                    usedNodes.Clear();
                    TraverseForMaxSum(node.Value, 0);
                }
            }

            Console.WriteLine(maxSum);
        }

        private static Dictionary<int, Node> ReadInput(int N)
        {
            Dictionary<int, Node> nodesResult = new Dictionary<int, Node>();

            for (int i = 0; i < N - 1; i++)
            {
                string input = Console.ReadLine();

                string[] splitted = input.Split(new char[] { '(', ')', '<', '-' },
                    StringSplitOptions.RemoveEmptyEntries);

                int parentKey = int.Parse(splitted[0]);
                int childKey = int.Parse(splitted[1]);

                Node parentNode;
                Node childNode;
                if (!nodesResult.ContainsKey(childKey))
                {
                    childNode = new Node(childKey);
                    nodesResult.Add(childKey, childNode);
                }
                else
                {
                    childNode = nodesResult[childKey];
                }

                if (!nodesResult.ContainsKey(parentKey))
                {
                    parentNode = new Node(parentKey);
                    nodesResult.Add(parentKey, parentNode);
                }
                else
                {
                    parentNode = nodesResult[parentKey];
                }

                parentNode.Children.Add(childNode);
                childNode.Children.Add(parentNode);
            }

            return nodesResult;
        }
    }

    public class Node
    {
        public int Value { get; private set; }

        public List<Node> Children { get; set; }

        public Node(int value)
        {
            this.Children = new List<Node>();
            this.Value = value;
        }
    }
}