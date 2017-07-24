using System;
using System.Collections.Generic;

namespace _01.ListyIterator
{
    public class ListyIterator<T>
    {
        public int CurrentIndex { get; set; }

        private List<T> data;

        public ListyIterator()
        {
            this.data = new List<T>();
            this.CurrentIndex = 0;
        }

        public ListyIterator(List<T> collection)
        {
            this.data = collection;
        }

        public bool Move()
        {
            if (this.data.Count > CurrentIndex)
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