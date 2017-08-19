namespace Emergency_Skeleton.Models.Writers
{
    using Emergency_Skeleton.Contracts;
    using System;

    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}