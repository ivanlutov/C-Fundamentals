using System;
using System.Linq;

namespace _07.LegoBlocks
{
    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var firstMatrix = new int[n][];
            var secondMatrix = new int[n][];

            for (int i = 0; i < n; i++)
            {
                firstMatrix[i] = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
            }

            for (int i = 0; i < n; i++)
            {
                secondMatrix[i] = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
            }

            for (int i = 0; i < n; i++)
            {
                var current = secondMatrix[i];
                var reverse = current.Reverse().ToArray();
                secondMatrix[i] = reverse;
            }

            var matrixResult = new int[n][];

            for (int i = 0; i < n; i++)
            {
                var first = firstMatrix[i];
                var second = secondMatrix[i];
                var final = new int[first.Length + second.Length];
                first.CopyTo(final, 0);
                second.CopyTo(final, first.Length);
                matrixResult[i] = final;
            }

            bool isEqualLenght = true;
            var numberOfElements = 0;

            for (int rowIndex = 0; rowIndex < n - 1; rowIndex++)
            {
                var currentLenght = matrixResult[rowIndex].Length;
                if (currentLenght != matrixResult[rowIndex + 1].Length)
                {
                    isEqualLenght = false;
                    break;
                }
            }

            for (int rowIndex = 0; rowIndex < n; rowIndex++)
            {
                var currentLenght = matrixResult[rowIndex].Length;
                numberOfElements += currentLenght;
            }

            if (isEqualLenght)
            {
                foreach (var row in matrixResult)
                {
                    Console.WriteLine($"[{string.Join(", ", row)}]");
                }
            }
            else
            {
                Console.WriteLine($"The total number of cells is: {numberOfElements}");
            }
        }
    }
}