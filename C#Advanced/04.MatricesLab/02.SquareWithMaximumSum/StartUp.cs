using System;
using System.Linq;

namespace _02.SquareWithMaximumSum
{
    public class StartUp
    {
        public static void Main()
        {
            var matrixSize = Console.ReadLine().Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int[][] matrix = new int[matrixSize[0]][];

            for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
            {
                matrix[rowIndex] = Console.ReadLine().Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            }

            var maxRowIndex = 0;
            var maxColIndex = 0;
            var maxSum = int.MinValue;

            for (int rowIndex = 0; rowIndex < matrix.Length - 1; rowIndex++)
            {
                for (int colIndex = 0; colIndex < matrix[rowIndex].Length - 1; colIndex++)
                {
                    var currentSum = matrix[rowIndex][colIndex] + matrix[rowIndex][colIndex + 1] +
                                     matrix[rowIndex + 1][colIndex] + matrix[rowIndex + 1][colIndex + 1];

                    if (maxSum < currentSum)
                    {
                        maxSum = currentSum;
                        maxRowIndex = rowIndex;
                        maxColIndex = colIndex;
                    }
                }
            }

            Console.WriteLine($"{matrix[maxRowIndex][maxColIndex]} {matrix[maxRowIndex][maxColIndex + 1]}");
            Console.WriteLine($"{matrix[maxRowIndex + 1][maxColIndex]} {matrix[maxRowIndex + 1][maxColIndex + 1]}");
            Console.WriteLine(maxSum);
        }
    }
}