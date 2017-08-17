
using System.Collections.Generic;

public interface IFactory<T>
{
    T Create(List<string> arguments);
}
