using System;
using System.Linq;

namespace _05.AppliedArithmetics
{
    public class StartUp
    {
        public static void Main()
        {
            var inputNumber = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var operation = Console.ReadLine();

            Func<int[], string, int[]> action = OperationAction;
            Action<int[]> printAction = n => Console.WriteLine(string.Join(" ", inputNumber));

            while (operation != "end")
            {
                if (operation == "print")
                {
                    printAction(inputNumber);
                }
                else
                {
                    inputNumber = action(inputNumber, operation);
                }

                operation = Console.ReadLine();
            }
        }

        private static int[] OperationAction(int[] inputNumber, string operation)
        {
            var collection = new int[inputNumber.Length];

            if (operation == "add")
            {
                for (int i = 0; i < inputNumber.Length; i++)
                {
                    collection[i] = inputNumber[i] + 1;
                }
            }
            else if (operation == "subtract")
            {
                for (int i = 0; i < inputNumber.Length; i++)
                {
                    collection[i] = inputNumber[i] - 1;
                }
            }
            else if (operation == "multiply")
            {
                for (int i = 0; i < inputNumber.Length; i++)
                {
                    collection[i] = inputNumber[i] * 2;
                }
            }

            return collection;
        }
    }
}