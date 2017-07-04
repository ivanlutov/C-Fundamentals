using System;
using System.Collections.Generic;

namespace _03.DecimalToBinaryConverter
{
    public class StartUp
    {
        public static void Main()
        {
            var number = int.Parse(Console.ReadLine());
            var stack = new Stack<int>();

            if (number == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                while (number > 0)
                {
                    var remainder = number % 2;
                    stack.Push(remainder);
                    number = number / 2;
                }
            }

            while (stack.Count > 0)
            {
                Console.Write(stack.Pop());
            }
            Console.WriteLine();
        }
    }
}