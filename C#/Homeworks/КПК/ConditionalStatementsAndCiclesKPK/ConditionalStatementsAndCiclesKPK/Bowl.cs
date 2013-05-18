using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConditionalStatementsAndCiclesKPK
{
    public class Bowl
    {
        private List<Vegetable> content = new List<Vegetable>();

        public int Count { get; private set; }
        public BowlSize Size { get; private set; }

        

        public Bowl(BowlSize size)
        {
            this.Size = size;
        }

        public void Add(Vegetable vegetable)
        {
            bool isFull = this.Count < (int)this.Size;

            if (vegetable != null && !isFull)
            {
                this.content.Add(vegetable);
                this.Count++;
            }
            else if (isFull)
            {
                throw new BowlFullException("Can not add more vegetabels in full bowl");
            }
            else
            {
                throw new NullReferenceException("Can not add null vegetable");
            }
        }

        public List<Vegetable> GetContent()
        {
            return this.content;
        }
    }
}
