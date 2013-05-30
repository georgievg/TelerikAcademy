using System;

namespace _13.MyQueueImplementation
{
    public class QueueItem<T>
    {
        public T Value { get; private set; }

        public QueueItem(T value)
        {            
            this.Value = value;
        }
    }
}
