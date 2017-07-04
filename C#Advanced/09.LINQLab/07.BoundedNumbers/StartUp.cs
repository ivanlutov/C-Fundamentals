using System;
using System.Linq;

namespace _07.BoundedNumbers
{
    public class StartUp
    {
        public static void Main()
        {
            var range = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse);

            var numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Where(n => n >= range.Min() && n <= range.Max());

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}