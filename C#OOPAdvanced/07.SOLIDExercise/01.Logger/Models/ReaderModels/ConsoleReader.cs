using _01.Logger.Interfaces;
using System;

namespace _01.Logger.Models.ReaderModels
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}