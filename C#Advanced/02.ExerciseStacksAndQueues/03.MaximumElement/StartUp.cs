using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MaximumElement
{
    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();
            int maxElement = int.MinValue;

            for (int i = 0; i < n; i++)
            {
                var commandLine = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                switch (commandLine[0])
                {
                    case "1":
                        var numberToPush = int.Parse(commandLine[1]);
                        stack.Push(numberToPush);
                        if (maxElement < numberToPush)
                        {
                            maxElement = numberToPush;
                        }
                        break;

                    case "2":
                        var elementToDelete = stack.Pop();

                        if (elementToDelete == maxElement && stack.Count > 0)
                        {
                            maxElement = stack.Max();
                        }
                        else if (elementToDelete == maxElement && stack.Count == 0)
                        {
                            maxElement = int.MinValue;
                        }
                        break;

                    case "3":
                        Console.WriteLine(maxElement);
                        break;
                }
            }
        }
    }
}