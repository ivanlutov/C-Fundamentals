using _01.Logger.Interfaces;
using System;

namespace _01.Logger.Models.WriterModels
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}