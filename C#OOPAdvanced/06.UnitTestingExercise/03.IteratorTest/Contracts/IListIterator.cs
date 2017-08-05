namespace _03.IteratorTest.Contracts
{
    public interface IListIterator
    {
        bool Move();

        bool HasNext();

        void Print(int index);
    }
}