using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.ListOfPredicates
{
    public class StartUp
    {
        public static void Main()
        {
            var range = int.Parse(Console.ReadLine());

            var divisorSequences = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            List<int> numbers = new List<int>();

            for (int i = 1; i <= range; i++)
            {
                numbers.Add(i);
            }

            foreach (var divisor in divisorSequences)
            {
                Predicate<int> predicate = n => n % divisor == 0;
                numbers = numbers.FindAll(predicate);
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}