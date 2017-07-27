using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _02.Collection
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        public int CurrentIndex { get; set; }

        private readonly List<T> data;

        public ListyIterator(params T[] elements)
        {
            this.CurrentIndex = 0;
            this.data = new List<T>(elements);
        }

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

        public string PrintAll()
        {
            if (this.data.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            var sb = new StringBuilder();
            foreach (var element in this.data)
            {
                sb.Append($"{element} ");
            }

            return sb.ToString().Trim();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.data.Count; i++)
            {
                yield return this.data[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}