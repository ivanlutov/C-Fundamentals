using System;
using System.Linq;

namespace _01.TakeTwo
{
    public class StartUp
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Where(n => n >= 10 && n <= 20)
                .Distinct()
                .Take(2);

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}