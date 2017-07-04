using System;
using System.Linq;

namespace _03.SquaresInMatrix
{
    public class StartUp
    {
        public static void Main()
        {
            var matrixSize = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            var row = matrixSize[0];
            var col = matrixSize[1];

            var matrix = new string[row][];

            for (int i = 0; i < row; i++)
            {
                matrix[i] = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            }

            var maxEquals = 0;

            for (int rowIndex = 0; rowIndex < row - 1; rowIndex++)
            {
                for (int colIndex = 0; colIndex < matrix[0].Length - 1; colIndex++)
                {
                    var firstSymbol = matrix[rowIndex][colIndex];
                    var secondSymbol = matrix[rowIndex + 1][colIndex];
                    var thridSymbol = matrix[rowIndex][colIndex + 1];
                    var fourthSymbol = matrix[rowIndex + 1][colIndex + 1];

                    if (firstSymbol == secondSymbol && firstSymbol == thridSymbol && firstSymbol == fourthSymbol
                        && secondSymbol == thridSymbol && secondSymbol == fourthSymbol
                        && thridSymbol == fourthSymbol)
                    {
                        maxEquals++;
                    }
                }
            }

            Console.WriteLine(maxEquals);
        }
    }
}