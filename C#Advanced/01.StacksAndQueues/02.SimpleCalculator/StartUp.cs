using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SimpleCalculator
{
    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var stack = new Stack<string>(input.Reverse());

            while (stack.Count > 1)
            {
                int first = int.Parse(stack.Pop());
                string op = stack.Pop();
                int second = int.Parse(stack.Pop());

                switch (op)
                {
                    case "+":
                        stack.Push((first + second).ToString());
                        break;

                    case "-":
                        stack.Push((first - second).ToString());
                        break;
                }
            }
            Console.WriteLine(stack.Pop());
        }
    }
}