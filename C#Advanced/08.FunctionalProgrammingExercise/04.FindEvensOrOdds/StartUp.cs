using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FindEvensOrOdds
{
    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var evenOrOdd = Console.ReadLine();

            var minRange = input[0];
            var maxRange = input[1];

            var numbers = new List<long>();

            for (long i = minRange; i <= maxRange; i++)
            {
                numbers.Add(i);
            }

            Predicate<long> even = n => n % 2 == 0;
            Predicate<long> odd = n => n % 2 != 0;

            if (evenOrOdd == "even")
            {
                numbers = numbers.FindAll(even);
            }
            else
            {
                numbers = numbers.FindAll(odd);
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}