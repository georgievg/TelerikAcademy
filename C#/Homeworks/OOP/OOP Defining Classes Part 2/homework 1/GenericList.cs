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
    public class GenericList<T>
    {
        private const int defaultCapacity = 10;
        
        private T[] elements;
        private int count = 0;

        public GenericList(int capacity)
        {
            elements = new T[capacity];
        }
        public GenericList()
            : this(defaultCapacity)
        {
            
        }

        public int Count
        {
            get
            {
                return this.count;
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < elements.Length; i++)
            {
                sb.Append(elements[i].ToString());
                sb.Append(" ,");
            }
            return sb.ToString();
        }
        public int FindByValue(T value)
        {
            int index = -1;
            for (int i = 0; i < this.elements.Length; i++)
            {
                if (int.Parse(elements[i].ToString()) == int.Parse(value.ToString()))
                {
                    index = i;
                    return index;
                }
            }
            return index;
        }
        public void Clear()
        {
            for (int i = 0; i < elements.Length;i++)
            {
                elements[i] = default(T);
            }
        }
        public void Add(T element)
        {
            CheckIfFull();
            this.elements[count] = element;
            count++;
        }
        public T[] RemoveAt(int index)
        {
            if (index < 0 || index > Count)
            {
                throw new IndexOutOfRangeException();
            }

            T[] arr = new T[this.Count-1];
            for (int i = 0; i < index; i++)
            {
                arr[i] = elements[i];
            }
            for (int i = index+1; i < arr.Length+1; i++)
            {
                arr[i - 1] = elements[i];
            }
            elements = arr.ToArray();
            return arr;
        }
        private void CheckIfFull()
        {
            T[] newArr = new T[Count * 2];
            if (Count == elements.Length)
            {
               
                for (int i = 0; i < Count; i++)
                {
                    newArr[i] = elements[i];
                }
            }
            else
                return;
            elements = newArr.ToArray();
        }
        public T[] insertAt(int index,T value)
        {
            if (index < 0 || index > Count)
            {
                throw new IndexOutOfRangeException();
            }
            CheckIfFull();
            T[] arr = new T[this.Count + 1];
            int i = 0;
            for (i=0; i < index; i++)
            {
                arr[i] = elements[i];
            }
            arr[i] = value;
            int g = i;
            for (i = g+1; i < arr.Length-1; i++)
            {
                arr[i] = elements[i - 1];
            }
            return arr;
        }
        public T this[int index]
        {
            get
            {
                if (index < 0 || index > Count)
                {
                    throw new IndexOutOfRangeException();
                }
                T result = elements[index];
                return result;
            }
        }


        
    }
}