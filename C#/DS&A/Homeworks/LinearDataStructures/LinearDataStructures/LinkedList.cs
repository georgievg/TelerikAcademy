using System;

namespace LinearDataStructures
{
    public class LinkedList<T>
    {
        private ListItem<T>[] innerArr = new ListItem<T>[10];
        private int count = 0;

        public int Count 
        {
            get
            {
                return this.count;
            }
        }

        public int BufferSize
        {
            get
            {
                return this.innerArr.Length;
            }
        }

        public ListItem<T> FirstItem
        {
            get
            {
                return this.innerArr[0];
            }
        }

        public void AddFirst(T itemToAdd)
        {
            if (this.Count == this.BufferSize-1)
            {
                DoubleInnerArrSize();
            }

            if (this.Count != 0)
            {
                this.MoveAllElementsByOneRight();
            }

            ListItem<T> listItemToAdd = new ListItem<T>(this.innerArr[1], itemToAdd);
            this.innerArr[0] = listItemToAdd;
            this.count++;
        }

        public void AddFirst(ListItem<T> listItemToAdd)
        {
            this.AddFirst(listItemToAdd.Value);
        }

        public void Clear()
        {
            for (int i = 0; i < this.Count; i++)
            {
                this.innerArr[i] = null;
            }

            this.count = 0;
        }

        private void MoveAllElementsByOneRight()
        {
            int innerCount = this.Count;
            ListItem<T>[] newArr = new ListItem<T>[this.BufferSize];

            for (int i = 0; i < innerCount; i++)
            {
                ListItem<T> currArrItem = this.innerArr[i];
                newArr[i + 1] = currArrItem;
            }

            this.innerArr = newArr;
        }

        private void DoubleInnerArrSize()
        {
            ListItem<T>[] newArr = new ListItem<T>[this.BufferSize * 2];
            for (int i = 0; i < this.BufferSize; i++)
            {
                newArr[i] = this.innerArr[i];
            }

            this.innerArr = newArr;
        }
    }
}