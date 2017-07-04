using System.Collections.Generic;
using System.Linq;

public class StackOfStrings
{
    private List<string> data;

    public StackOfStrings()
    {
        this.data = new List<string>();
    }

    public void Push(string item)
    {
        this.data.Add(item);
    }

    public string Pop()
    {
        var element = this.data[data.Count - 1];
        this.data.RemoveAt(data.Count - 1);
        return element;
    }

    public string Peek()
    {
        return this.data[data.Count - 1];
    }

    public bool IsEmpty()
    {
        return this.data.Any();
    }
}