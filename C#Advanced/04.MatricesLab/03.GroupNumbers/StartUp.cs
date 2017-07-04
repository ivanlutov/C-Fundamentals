using System;
using System.Linq;

namespace _03.GroupNumbers
{
    public class StartUp
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            var remainder0 = numbers.Where(n => Math.Abs(n) % 3 == 0).ToArray();
            var remainder1 = numbers.Where(n => Math.Abs(n) % 3 == 1).ToArray();
            var remainder2 = numbers.Where(n => Math.Abs(n) % 3 == 2).ToArray();

            Console.WriteLine(string.Join(" ", remainder0));
            Console.WriteLine(string.Join(" ", remainder1));
            Console.WriteLine(string.Join(" ", remainder2));
        }
    }
}