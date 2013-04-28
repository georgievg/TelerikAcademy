using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
namespace _6.Binary_Search_Tree
{
    public class BinarySearchTree
    {
        private List<TreeNode> allNodes { get; set; }
        private int InitialKey { get; set; }
        public TreeNode Tree { get; private set; }
        private TreeNode currNode;
        public int Length { get; private set; }
        public BinarySearchTree(int InitialKey)
        {
            Tree = new TreeNode(InitialKey);
            allNodes = new List<TreeNode>();
            currNode = this.Tree;
        }

        public void RemoveElement(int key)
        {
            TreeNode nodeToDel = null;
            RecursiveFind(Tree, key, out nodeToDel);
            nodeToDel.Key = null;
        }
        private void RecursiveFind(TreeNode currNode, int key,out TreeNode node)
        {
            if (currNode == null)
            {
                node = null;
                return;
            }
            if (currNode.Key == key)
            {
                node = currNode;
                return;
            }
            RecursiveFind(currNode.Left, key, out node);
            RecursiveFind(currNode.Right, key, out node);
            return;

           
        }
        public int FindElement(int key)
        {
            List<TreeNode> list = EnumerateNodes(this.Tree);
            List<TreeNode> newList = new List<TreeNode>();
            foreach (var item in list)
            {
                if (item != null)
                {
                    newList.Add(item);
                }
            }
            int counter=1;
            foreach (var item in newList)
            {
                if (item.Key == key)
                {
                    return counter; //position on the side it should be -- if the initialKey is 50 -> 11 is on position 4(on the left)
                }
                counter++;
            }
            return -1;
        }
        public void AddElement(int key)
        {
            currNode = this.Tree;
            bool right = true;
            while (true)
            {
                if (currNode == null)
                {
                    break;
                }
                if (currNode.Key == 0)
                {
                    if (right)
                    {
                        currNode.Key = key;
                        currNode.Right = new TreeNode();
                        currNode = currNode.Right;
                        Length++;
                        break;
                    }
                    else if (!right)
                    {
                        currNode.Key = key;
                        currNode.Left = new TreeNode();
                        currNode = currNode.Left;
                        Length++;
                        break;
                    }
                }
                else if (key > currNode.Key)
                {
                    currNode = currNode.Right;
                    right = true;
                }
                else if (key < currNode.Key)
                {
                    currNode = currNode.Left;
                    right = false;
                }
                else if (key == currNode.Key)
                {
                    throw new Exception("Node exists");
                }
            }

        }
        private List<TreeNode> EnumerateNodes(TreeNode currNode)
        {
            try
            {

                allNodes.Add(currNode);
                EnumerateNodes(currNode.Left);
                EnumerateNodes(currNode.Right);
            }
            catch (Exception)
            {
                return allNodes;
            }
            return allNodes;
        }
    }
}