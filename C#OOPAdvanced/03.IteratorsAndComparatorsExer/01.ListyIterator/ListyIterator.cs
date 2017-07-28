using System;
using System.Collections.Generic;

namespace _01.ListyIterator
{
    public class ListyIterator<T>
    {
        private readonly List<T> data;

        public ListyIterator(params T[] elements)
        {
            this.data = new List<T>(elements);
            this.CurrentIndex = 0;
        }

        public int CurrentIndex { get; set; }

        public ListyIterator(List<T> collection)
        {
            this.data = collection;
        }

        public bool Move()
        {
            if (this.data.Count - 1 > CurrentIndex)
            {
                this.CurrentIndex++;
                return true;
            }

            return false;
        }

        public bool HasNext()
        {
            if (this.data.Count - 1 > CurrentIndex)
            {
                return true;
            }

            return false;
        }

        public T Print()
        {
            if (this.data.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            return this.data[CurrentIndex];
        }
    }
}