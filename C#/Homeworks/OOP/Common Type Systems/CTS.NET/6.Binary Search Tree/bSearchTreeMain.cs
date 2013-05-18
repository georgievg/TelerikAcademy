using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _6.Binary_Search_Tree
{
    class bSearchTreeMain
    {
        
        static void Main()
        {
            Random rnd = new Random();
            BinarySearchTree bs = new BinarySearchTree(50);
            bs.AddElement(66);
            bs.AddElement(44);
            bs.AddElement(77);
            bs.AddElement(33);
            bs.AddElement(88);
            bs.AddElement(11);
            int pos = bs.FindElement(11);
            bs.RemoveElement(66);
        }
    }
}
