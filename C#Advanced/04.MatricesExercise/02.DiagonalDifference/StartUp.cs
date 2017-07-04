using System;
using System.Linq;

namespace _02.DiagonalDifference
{
    public class StartUp
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var matrix = new int[n][];

            for (int i = 0; i < n; i++)
            {
                matrix[i] = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            }

            var secondDiagonal = 0;
            var firstDiagonal = 0;

            for (int rowIndex = 0; rowIndex < n; rowIndex++)
            {
                for (int colIndex = 0; colIndex < matrix[0].Length; colIndex++)
                {
                    if (rowIndex == colIndex)
                    {
                        firstDiagonal += matrix[rowIndex][colIndex];
                    }
                }
            }

            for (int rowIndex = 0; rowIndex < n; rowIndex++)
            {
                for (int colIndex = 0; colIndex < matrix[0].Length; colIndex++)
                {
                    if (rowIndex + colIndex == n - 1)
                    {
                        secondDiagonal += matrix[rowIndex][colIndex];
                    }
                }
            }

            var result = Math.Abs(firstDiagonal - secondDiagonal);
            Console.WriteLine(result);
        }
    }
}