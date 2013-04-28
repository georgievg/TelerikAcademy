using System;
using System.Collections.Generic;
using System.Threading;
using System.IO;
using System.Web;
using System.Net;
using System.Linq;
using System.Text;

namespace homework_1
{
    //
    public static class MaxMin
    {
        public static int Max(GenericList<int> list)
        {
            int maxVal = 0;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] > maxVal)
                {
                    maxVal = list[i];
                }
            }
            return maxVal;
        }
        public static int Min(GenericList<int> list)
        {
            int minVal = int.MaxValue;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] < minVal)
                {
                    minVal = list[i];
                }
            }
            return minVal;
        }
    }
}