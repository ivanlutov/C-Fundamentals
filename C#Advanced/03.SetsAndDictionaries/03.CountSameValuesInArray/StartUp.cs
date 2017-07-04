using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.CountSameValuesInArray
{
    public class StartUp
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            var numbersCount = new SortedDictionary<double, int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                var currentNumber = numbers[i];
                if (!numbersCount.ContainsKey(currentNumber))
                {
                    numbersCount[currentNumber] = 0;
                }
                numbersCount[currentNumber]++;
            }

            foreach (var kvp in numbersCount)
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value} times");
            }
        }
    }
}
