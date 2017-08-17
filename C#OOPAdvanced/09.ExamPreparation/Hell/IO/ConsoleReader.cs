using System;
using Hell.Contracts;

public class ConsoleReader : IInputReader
{
    public string ReadLine()
    {
        return Console.ReadLine().Trim();
    }
}