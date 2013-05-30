using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _6.Binary_Search_Tree
{
    public class TreeNode
    {
        public int? Key { get; set; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }
        public TreeNode(int key)
        {
            this.Key = key;
            Right = new TreeNode();
            Left = new TreeNode();
        }
        public TreeNode()
        {
            this.Key = 0;
        }
    }
}