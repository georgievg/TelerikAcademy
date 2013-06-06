using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Tree
{
    class TreeMain
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            List<TreeNode<int>> treeNodes = FillNodes(n);
            MakeConnections(n, treeNodes);
            //1. The root
            TreeNode<int> root = FindRoot(treeNodes);
            Console.WriteLine("The root of the tree is: {0}", root.Value);

            //2. Leaf nodes
            List<TreeNode<int>> leafs = FindLeafs(treeNodes);
            Console.Write("The leafs in the tree are: ");
            foreach (var leaf in leafs)
            {
                Console.Write("{0} ", leaf.Value);
            }
            Console.WriteLine();

            //3.Longest Path
            int longestPath = FindLongestPath(root, 1);
            Console.WriteLine("The longest path in the tree is : {0}", longestPath);

            //4. All paths with sum S
            int s = 9;
            List<List<TreeNode<int>>> paths = new List<List<TreeNode<int>>>();
            Stack<TreeNode<int>> pathCombinations = new Stack<TreeNode<int>>();
            pathCombinations.Push(root);
            FindPathsCombinations(root, paths, pathCombinations);
            List<List<TreeNode<int>>> finalPaths = new List<List<TreeNode<int>>>();
            foreach (var pathList in paths)
            {
                int sum = 0;
                foreach (var node in pathList)
                {
                    sum += node.Value;
                }

                if (sum == s)
                {
                    finalPaths.Add(pathList);
                }
            }

            Console.WriteLine("All paths with sum {0} are: ", s);
            foreach (var path in finalPaths)
            {
                foreach (var node in path)
                {
                    Console.Write("{0} ,", node.Value);
                }
                Console.WriteLine();
            }
            
            //5. All Subtrees with sum S
            s = 4;
            List<TreeNode<int>> subtrees = new List<TreeNode<int>>();
            subtrees.Add(root);
            FindAllSubTrees(root, subtrees);
            int[] sums = new int[subtrees.Count];
            List<TreeNode<int>> results = new List<TreeNode<int>>();
            for (int i = 0; i < subtrees.Count; i++)
            {
                //CalcSumOfNodes(subtrees[i], ref sums[i]);
                sums[i] = subtrees[i].SumOfChildren();
                if (sums[i] == s)
                {
                    results.Add(subtrees[i]);
                }
            }

            Console.WriteLine("The subtrees with sum {0} are: ", s);
            foreach (var tree in results)
            {
                Console.Write("Root: {0} ,", tree.Value);
                foreach (var child in tree.Children)
                {
                    Console.Write("Child: {0}, ", child.Value);
                }
                Console.WriteLine();
            }
        }

        private static void FindAllSubTrees(TreeNode<int> root, List<TreeNode<int>> subtrees)
        {
            Queue<TreeNode<int>> qu = new Queue<TreeNode<int>>();
            qu.Enqueue(root);
            subtrees.Add(root);
            while (qu.Count > 0)
            {
                TreeNode<int> currentNode = qu.Dequeue();
                foreach (var ch in currentNode.Children)
                {
                    subtrees.Add(ch);
                    qu.Enqueue(ch);
                }
            }
        }

        private static void CalcSumOfNodes(TreeNode<int> treeNode, ref int sum)
        {
            foreach (var node in treeNode.Children)
            {
                sum += node.Value;
                if (node.Children.Count > 0)
                {
                    int newSum = sum;
                    CalcSumOfNodes(node, ref newSum);
                }
            }
        }

        private static void FindPathsCombinations(TreeNode<int> root, List<List<TreeNode<int>>> paths,
            Stack<TreeNode<int>> path)
        {
            foreach (var child in root.Children)
            {
                path.Push(child);
                FindPathsCombinations(child, paths, path);
                paths.Add(path.ToList());
                path.Pop();
            }
        }

        private static int FindLongestPath(TreeNode<int> root, int counter)
        {
            foreach (var child in root.Children)
            {
                return Math.Max(counter, FindLongestPath(child, counter + 1));
            }

            return 0;
        }

        private static List<TreeNode<int>> FindLeafs(List<TreeNode<int>> treeNodes)
        {
            List<TreeNode<int>> leafs = new List<TreeNode<int>>();
            foreach (var node in treeNodes)
            {
                if (node.Parent != null && node.Children.Count == 0)
                {
                    leafs.Add(node);
                }
            }

            return leafs;
        }

        private static TreeNode<int> FindRoot(List<TreeNode<int>> treeNodes)
        {
            foreach (var node in treeNodes)
            {
                if (node.Parent == null)
                {
                    return node;
                }
            }

            throw new ArgumentException("Root could not be found, maybe invalid tree");
        }
  
        private static void MakeConnections(int n, List<TreeNode<int>> treeNodes)
        {
            for (int i = 0; i < n - 1; i++)
            {
                string nodesAsStr = Console.ReadLine();
                var splitNodes = nodesAsStr.Split(' ');
                int parent = int.Parse(splitNodes[0]);
                int child = int.Parse(splitNodes[1]);

                treeNodes[parent].Children.Add(treeNodes[child]);
                treeNodes[child].Parent = treeNodes[parent];
            }
        }
  
        private static List<TreeNode<int>> FillNodes(int n)
        {
            List<TreeNode<int>> nodesResult = new List<TreeNode<int>>();
            for (int i = 0; i < n; i++)
            {
                nodesResult.Add(new TreeNode<int>(i));
            }

            return nodesResult;
        }
    }
}