using System.Collections.Generic;

public interface IDatabase
{
    void Add(int element);
    void Remove();
    int[] Fetch();
}
