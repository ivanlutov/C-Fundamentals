namespace BashSoftTesting.Fakes
{
    using BashSoft.DataStructures;
    using System;

    internal class SimpleSortedListFake<T> : SimpleSortedList<T>
        where T : IComparable<T>
    {
        public T[] ExposeCollection()
        {
            return base.InnerCollection;
        }
    }
}