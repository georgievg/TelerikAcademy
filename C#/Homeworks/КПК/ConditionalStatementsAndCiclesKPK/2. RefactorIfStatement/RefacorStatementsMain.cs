using ConditionalStatementsAndCiclesKPK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.RefactorIfStatement
{
    class RefacorStatementsMain
    {
        static void Main()
        {
            Potato potato = new Potato();

            if (potato != null)
            {
                if (potato.HasBeenPeeled && !potato.IsRotten)
                {
                    Chef chef = new Chef();
                    chef.Cook(potato);
                }
            }
            else
            {
                throw new NullReferenceException("Potato does not exist");
            }

            /*---------------------------------------------------------------*/
            const int MinX = 0;
            const int MaxX = 0;
            const int MinY = 0;
            const int MaxY = 0;

            int x = 0;           
            int y = 0;

            bool shouldVisitCell = true;
            bool xIsInRange =  x >= MinX && MaxX >= x;
            bool yIsInRange = y <= MaxY && MinY >= y;

            if (xIsInRange && yIsInRange && shouldVisitCell)
            {
               VisitCell();
            }


        }
        private static void VisitCell()
        {
        }

    }
}
