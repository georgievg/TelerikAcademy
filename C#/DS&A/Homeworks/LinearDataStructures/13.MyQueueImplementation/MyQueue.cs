using System;

namespace _13.MyQueueImplementation
{
    public class MyQueue<T>
    {
        private QueueItem<T>[] innerArr = new QueueItem<T>[10];
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
        
        public void Enqueue(T itemToAdd)
        {
            if (this.Count == this.BufferSize-1)
            {
                DoubleInnerArrSize();
            }

            QueueItem<T> listItemToAdd = new QueueItem<T>(itemToAdd);
            this.innerArr[this.Count] = listItemToAdd;
            this.count++;
        }

        public void Enqueue(QueueItem<T> listItemToAdd)
        {
            this.Enqueue(listItemToAdd.Value);
        }

        public QueueItem<T> Dequeue()
        {
            this.count--;
            var itemToReturn = this.innerArr[0];
            this.MoveAllElementsByOneLeft();

            return itemToReturn;
        }

        public void Clear()
        {
            for (int i = 0; i < this.Count; i++)
            {
                this.innerArr[i] = null;
            }

            this.count = 0;
        }

        private void MoveAllElementsByOneLeft()
        {
            int innerCount = this.Count;
            QueueItem<T>[] newArr = new QueueItem<T>[this.BufferSize];

            for (int i = innerCount; i > 0; i--)
            {
                QueueItem<T> currArrItem = this.innerArr[i];
                newArr[i - 1] = currArrItem;
            }

            this.innerArr = newArr;
        }

        private void DoubleInnerArrSize()
        {
            QueueItem<T>[] newArr = new QueueItem<T>[this.BufferSize * 2];
            for (int i = 0; i < this.BufferSize; i++)
            {
                newArr[i] = this.innerArr[i];
            }

            this.innerArr = newArr;
        }
    }
}