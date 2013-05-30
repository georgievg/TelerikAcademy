using System;

namespace LinearDataStructures
{
    public class ListItem<T>
    {
        public T Value { get; private set; }
        public ListItem<T> NextItem { get; private set; }

        public ListItem(ListItem<T> nextItem, T value)
        {            
            this.NextItem = nextItem;
            this.Value = value;
        }
    }
}
