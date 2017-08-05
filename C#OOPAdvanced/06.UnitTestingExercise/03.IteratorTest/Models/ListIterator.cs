using _03.IteratorTest.Contracts;
using System;
using System.Collections.Generic;

namespace _03.IteratorTest.Models
{
    public class ListIterator : IListIterator
    {
        private IList<string> data;
        private IWriter writer;
        private int currentIndex;

        public ListIterator(IWriter writer, params string[] elements)
        {
            this.currentIndex = 0;
            this.writer = writer;
            this.SetData(elements);
        }

        public int Count()
        {
            return this.data.Count;
        }
        private void SetData(params string[] elements)
        {
            if (elements.Length == 0)
            {
                throw new ArgumentNullException();
            }

            this.data = elements;
        }

        public bool Move()
        {
            if (this.currentIndex < this.data.Count - 1)
            {
                currentIndex++;
                return true;
            }

            return false;
        }

        public bool HasNext()
        {
            if (this.currentIndex == this.data.Count - 1)
            {
                return false;
            }

            return true;
        }

        public void Print(int index)
        {
            if (index > this.data.Count - 1)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            var element = this.data[index];
            writer.WriteLine(element);
        }
    }
}