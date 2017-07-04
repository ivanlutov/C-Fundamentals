using System;
using System.Linq;

namespace _04.AddVAT
{
    public class StartUp
    {
        public static void Main()
        {
            Console.WriteLine(string.Join(Environment.NewLine, Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Select(n => $"{(n * 1.2):F2}")));
        }
    }
}
