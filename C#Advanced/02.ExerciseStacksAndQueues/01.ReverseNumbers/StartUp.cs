using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.ReverseNumbers
{
    public class StartUp
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Stack<int> inputNumbers = new Stack<int>(numbers);

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write(inputNumbers.Pop() + " ");
            }

            Console.WriteLine();
        }
    }
}