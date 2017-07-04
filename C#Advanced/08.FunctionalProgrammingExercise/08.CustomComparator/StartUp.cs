using System;
using System.Linq;

namespace _08.CustomComparator
{
    public class StartUp
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Array.Sort(numbers, Comparison);

            Console.WriteLine(string.Join(" ", numbers));
        }

        private static int Comparison(int a, int b)
        {
            var first = Math.Abs(a) % 2;
            var second = Math.Abs(b) % 2;

            if (first != second)
            {
                return first.CompareTo(second);
            }

            return a.CompareTo(b);
        }
    }
}