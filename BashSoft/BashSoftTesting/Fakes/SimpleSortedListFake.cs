namespace BashSoftTesting.Fakes
{
    using System;
    using BashSoft.DataStructures;
    internal class SimpleSortedListFake<T> : SimpleSortedList<T>
        where T : IComparable<T>
    {
        public T[] ExposeCollection()
        {
            return base.InnerCollection;
        }
    }
}
