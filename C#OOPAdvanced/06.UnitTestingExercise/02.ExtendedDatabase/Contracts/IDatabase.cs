namespace _02.ExtendedDatabase.Contracts
{
    public interface IDatabase
    {
        int CurrentIndex { get; }

        int Count();

        void Add(IPeople people);

        IPeople Remove();

        IPeople FindByUsername(string name);

        IPeople FindById(int id);
    }
}