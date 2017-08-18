using System.Collections.Generic;

public interface IFactory<T>
{
    T Create(IList<string> arguments);
}