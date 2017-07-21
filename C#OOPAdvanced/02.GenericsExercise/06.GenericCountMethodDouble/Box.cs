using System;
using System.Collections.Generic;

namespace _06.GenericCountMethodDouble
{
    public class Box<T>
        where T : IComparable<T>
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

        public int CompareTo(T other)
        {
            int count = 0;

            for (int i = 0; i < this.data.Count; i++)
            {
                if (this.data[i].CompareTo(other) == 1)
                {
                    count++;
                }
            }

            return count;
        }
    }
}