using System;
using System.Linq;

namespace _03.CustomMinFunction
{
    public class StartUp
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Func<int[], int> minNumber = MinNumber;

            Console.WriteLine(minNumber(numbers));
        }

        public static int MinNumber(int[] array)
        {
            var min = int.MaxValue;
            foreach (var number in array)
            {
                if (number < min)
                {
                    min = number;
                }
            }

            return min;
        }
    }
}