using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SetsOfElements
{
    public class StartUp
    {
        public static void Main()
        {
            var lenghtSets = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var firstSet = new HashSet<int>();
            var secondSet = new HashSet<int>();

            for (int i = 0; i < lenghtSets[0]; i++)
            {
                var number = int.Parse(Console.ReadLine());
                firstSet.Add(number);
            }
            for (int i = 0; i < lenghtSets[1]; i++)
            {
                var number = int.Parse(Console.ReadLine());
                secondSet.Add(number);
            }
            var result = firstSet.Intersect(secondSet);
            Console.WriteLine(string.Join(" ", result));
        }
    }
}