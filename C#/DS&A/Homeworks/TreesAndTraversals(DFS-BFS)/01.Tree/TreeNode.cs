using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Tree
{
    public class TreeNode<T>
    {
        public List<TreeNode<T>> Children { get; set; }

        public TreeNode<T> Parent { get; set; }

        public T Value { get; set; }

        public TreeNode()
        {
            this.Children = new List<TreeNode<T>>();
            this.Parent = null;
        }

        public TreeNode(T value) : this()
        {
            this.Value = value;
        }

        public int SumOfChildren()
        {
            int sum = 0;
            Queue<List<TreeNode<T>>> qu = new Queue<List<TreeNode<T>>>();
            qu.Enqueue(Children);
            while (qu.Count > 0)
            {
                List<TreeNode<T>> currChildren = qu.Dequeue();
                foreach (var ch in currChildren)
                {
                    sum += int.Parse(ch.Value.ToString());
                    qu.Enqueue(ch.Children);
                }
            }

            return sum;
        }
    }
}