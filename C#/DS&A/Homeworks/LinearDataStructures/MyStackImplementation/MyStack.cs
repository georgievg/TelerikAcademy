using System;

namespace MyStackImplementation
{
    public class MyStack<T>
    {
        private T[] innerArr = new T[10];
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

        public T Peek
        {
            get
            {
                return this.innerArr[this.Count-1];
            }
        }

        public void Push(T itemToPush)
        {
            if (this.Count == this.BufferSize - 1)
            {
                this.DoubleInnerArrSize();
            }

            this.innerArr[this.Count] = itemToPush;
            this.count++;
        }

        public void Pop()
        {
            if (this.Count >= 0)
            {
                this.innerArr[this.Count] = default(T);
                if (this.Count > 0)
                {
                    this.count--;
                }
            }
        }

        private void DoubleInnerArrSize()
        {
            T[] newArr = new T[this.BufferSize * 2];
            for (int i = 0; i < this.BufferSize; i++)
            {
                newArr[i] = this.innerArr[i];
            }

            this.innerArr = newArr;
        }
    }
}