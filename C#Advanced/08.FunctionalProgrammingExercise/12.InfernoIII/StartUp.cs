using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.InfernoIII
{
    public class StartUp
    {
        private static List<int> filteredNumbers;

        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            Func<int, int, int> sumLeft = (x, y) => x + y;
            Func<int, int, int> sumRight = (x, y) => x + y;
            Func<int, int, int, int> sumLeftRight = (x, y, z) => x + y + z;

            var command = Console.ReadLine();

            var commands = new List<string>();

            while (command != "Forge")
            {
                var indexOfFirstDot = command.IndexOf(';');
                var firstPart = command.Substring(0, indexOfFirstDot);
                var secondPart = command.Substring(indexOfFirstDot + 1);

                if (firstPart == "Exclude")
                {
                    commands.Add(secondPart);
                }
                else
                {
                    if (commands.Contains(secondPart))
                    {
                        commands.Remove(secondPart);
                    }
                }

                command = Console.ReadLine();
            }

            var filteredNumbers = new int[numbers.Count];

            var countIndex = 0;
            for (int commandIndex = 0; commandIndex < commands.Count; commandIndex++)
            {
                var tokens = commands[commandIndex]
                    .Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                var operation = tokens[0];
                var count = int.Parse(tokens[1]);

                for (int i = 0; i < numbers.Count; i++)
                {
                    var currentNumber = numbers[i];

                    var previousNumber = 0;
                    previousNumber = i == 0 ? 0 : numbers[i - 1];

                    var nextNumber = 0;
                    nextNumber = i == numbers.Count - 1 ? 0 : numbers[i + 1];

                    switch (operation)
                    {
                        case "Sum Left":
                            if (sumLeft(currentNumber, previousNumber) == count)
                            {
                                filteredNumbers[countIndex] = 1;
                            }
                            break;

                        case "Sum Right":
                            if (sumRight(currentNumber, nextNumber) == count)
                            {
                                filteredNumbers[countIndex] = 1;
                            }
                            break;

                        case "Sum Left Right":
                            if (sumLeftRight(currentNumber, previousNumber, nextNumber) == count)
                            {
                                filteredNumbers[countIndex] = 1;
                            }
                            break;
                    }

                    countIndex++;
                }

                countIndex = 0;
            }

            for (int i = numbers.Count - 1; i >= 0; i--)
            {
                var currentNum = i;
                if (filteredNumbers[currentNum] == 1)
                {
                    numbers.RemoveAt(currentNum);
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}