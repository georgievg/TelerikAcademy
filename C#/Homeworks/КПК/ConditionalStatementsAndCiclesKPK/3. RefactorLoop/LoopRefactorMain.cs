using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.RefactorLoop
{
    class LoopRefactorMain
    {
        static void Main()
        {
            

        }
        public static bool FindValueInArr(int[] array,int expectedValue)
        {
            bool foundValue = false;
            for (int i = 0; i < 100; i++)
            {
                //Zavisi ot celta na cikula dali trqbva da e s ostatuk 0, ako trqbva da sme nai-tochni sprqmo turseneto trqba da bude bez deleneto s ostatuk
                if (i % 10 == 0)
                {
                    if (array[i] == expectedValue)
                    {
                        foundValue = true;
                        break;
                    }
                }
            }
            return foundValue;
        }
    }
}
