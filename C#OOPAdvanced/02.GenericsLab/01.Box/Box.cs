using System.Collections.Generic;
using System.Linq;
public class Box<T> : IBox<T>
{
    private List<T> data;

    public Box()
    {
        this.data = new List<T>();
    }

    public int Count => this.data.Count;

    public void Add(T element)
    {
        this.data.Add(element);
    }

    public T Remove()
    {
        var elementToRemove = this.data.LastOrDefault();
        this.data.RemoveAt(this.data.Count - 1);
        return elementToRemove;
    }
}
