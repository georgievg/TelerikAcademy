using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class Extensions
{
    public static bool Contains(this int[,] arr, int numToFind)
    {
        bool containsNum = false;
        foreach (var num in arr)
        {
            if (num == numToFind)
            {
                containsNum = true;
            }
        }

        return containsNum;
    }
}

