using System.Collections;
using System.Collections.Generic;

namespace _04.Froggy
{
    public class Lake<T> : IEnumerable<T>
    {
        private readonly List<T> data;

        public Lake()
        {
            this.data = new List<T>();
        }

        public Lake(List<T> collection)
        {
            this.data = collection;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.data.Count; i += 2)
            {
                yield return this.data[i];
            }

            var lastIndex = this.data.Count - 1;
            if (lastIndex % 2 == 0)
            {
                lastIndex--;
            }

            for (int i = lastIndex; i >= 0; i -= 2)
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