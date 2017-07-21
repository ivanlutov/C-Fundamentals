using System.Collections.Generic;

namespace _03.GenericSwapMethodString
{
    public class Box<T>
    {
        private List<T> data;

        public Box()
        {
            this.data = new List<T>();
        }

        public void Add(T item)
        {
            this.data.Add(item);
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            var firstElement = this.data[firstIndex];
            var secondElement = this.data[secondIndex];
            this.data[firstIndex] = secondElement;
            this.data[secondIndex] = firstElement;
        }

        public IReadOnlyList<T> GetList()
        {
            return this.data;
        }

        public override string ToString()
        {
            return $"{typeof(T)}:";
        }
    }
}