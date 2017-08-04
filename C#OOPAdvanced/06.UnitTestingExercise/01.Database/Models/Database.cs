using System;
using System.Collections.Generic;
using System.Linq;

public class Database : IDatabase
{
    private const int DefaultCapacity = 16;
    private readonly IList<int> data;
    private readonly int[] firstElements;
    private int currentElement;
    public Database(params int[] elements)
    {
        this.data = new int[DefaultCapacity];
        this.firstElements = elements;
        this.CurrentElement = 0;
        this.SetData();
    }

    public int CurrentElement
    {
        get { return this.currentElement; }
        set { this.currentElement = value; }
    }

    private void SetData()
    {
        if (firstElements == null)
        {
            throw new ArgumentNullException();
        }

        if (firstElements.Length > DefaultCapacity)
        {
            throw new InvalidOperationException();
        }

        for (int i = 0; i < this.firstElements.Length; i++)
        {
            this.data[i] = firstElements[i];
            CurrentElement++;
        }
    }
    public void Add(int element)
    {
        if (this.CurrentElement == DefaultCapacity)
        {
            throw new InvalidOperationException();
        }

        this.data[CurrentElement] = element;
        this.CurrentElement++;
    }

    public void Remove()
    {
        if (this.currentElement == 0)
        {
            throw new InvalidOperationException();
        }

        this.data[currentElement] = default(int);
        this.CurrentElement--;
    }

    public int[] Fetch()
    {
        var temp = new int[currentElement];
        Array.Copy(this.data.ToArray(), 0, temp, 0, currentElement);

        return temp;
    }

    public int Count()
    {
        return this.CurrentElement;
    }
}
