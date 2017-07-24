using System.Collections;
using System.Collections.Generic;

namespace _09.LinkedListTraversal
{
    public class LinkedList<T> : IEnumerable<T>
    {
        public int Count { get; set; }

        private List<T> data;

        public LinkedList()
        {
            this.data = new List<T>();
            this.Count = 0;
        }

        public void Add(T element)
        {
            this.data.Add(element);
            this.Count++;
        }

        public bool Remove(T element)
        {
            if (!this.data.Contains(element))
            {
                return false;
            }

            this.data.Remove(element);
            this.Count--;
            return true;
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