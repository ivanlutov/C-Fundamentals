using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.ReverseAndExclude
{
    public class StartUp
    {
        public static void Main()
        {
            var inputNumbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            var numberForDivisible = int.Parse(Console.ReadLine());

            Predicate<int> divisiblePredicate = n => n % numberForDivisible != 0;
            inputNumbers = inputNumbers.FindAll(divisiblePredicate);

            Func<List<int>, List<int>> reverseFunc = Reverse;
            inputNumbers = reverseFunc(inputNumbers);

            Console.WriteLine(string.Join(" ", inputNumbers));
        }

        private static List<int> Reverse(List<int> collection)
        {
            var reverseCollection = new List<int>();

            for (int i = collection.Count - 1; i >= 0; i--)
            {
                reverseCollection.Add(collection[i]);
            }

            return reverseCollection;
        }
    }
}