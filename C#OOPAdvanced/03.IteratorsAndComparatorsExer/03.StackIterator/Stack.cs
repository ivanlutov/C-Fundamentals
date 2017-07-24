using System;
using System.Collections;
using System.Collections.Generic;

namespace _03.StackIterator
{
    public class Stack<T> : IEnumerable<T>
    {
        private List<T> data;

        public Stack()
        {
            this.data = new List<T>();
        }

        public void Push(T element)
        {
            this.data.Add(element);
        }

        public T Pop()
        {
            if (this.data.Count == 0)
            {
                throw new InvalidOperationException("No elements");
            }

            var element = this.data[this.data.Count - 1];
            this.data.RemoveAt(this.data.Count - 1);
            return element;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.data.Count - 1; i >= 0; i--)
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