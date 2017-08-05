using _03.IteratorTest.Contracts;
using System;

namespace _03.IteratorTest.Models
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}