using System;
using System.Linq;

namespace _05.RubiksMatrix
{
    public class StartUp
    {
        public static void Main()
        {
            var matrixSize = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            var row = matrixSize[0];
            var col = matrixSize[1];

            var matrix = new int[row][];
            int counter = 1;

            for (int rowIndex = 0; rowIndex < row; rowIndex++)
            {
                matrix[rowIndex] = new int[col];
                for (int colIndex = 0; colIndex < matrix[0].Length; colIndex++)
                {
                    matrix[rowIndex][colIndex] = counter;
                    counter++;
                }
            }

            int numberOfCommands = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfCommands; i++)
            {
                var currentLine = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var indexOfRowOrCol = int.Parse(currentLine[0]);
                var direction = currentLine[1];
                var moves = int.Parse(currentLine[2]);

                switch (direction)
                {
                    case "up":
                        MoveUpAndDown(matrix, indexOfRowOrCol, moves);
                        break;
                    case "down":
                        MoveUpAndDown(matrix, indexOfRowOrCol, row - moves % row);
                        break;
                    case "left":
                        MoveRightAndLeft(matrix, indexOfRowOrCol, moves);
                        break;
                    case "right":
                        MoveRightAndLeft(matrix, indexOfRowOrCol, col - moves % col);
                        break;
                }
            }
            var element = 1;

            for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
            {
                for (int colIndex = 0; colIndex < matrix[0].Length; colIndex++)
                {
                    if (matrix[rowIndex][colIndex] == element)
                    {
                        Console.WriteLine("No swap required");
                    }

                    else
                    {
                        for (int r = 0; r < matrix.Length; r++)
                        {
                            for (int c = 0; c < matrix[0].Length; c++)
                            {
                                if (matrix[r][c] == element)
                                {
                                    var currentElement = matrix[rowIndex][colIndex];
                                    matrix[rowIndex][colIndex] = element;
                                    matrix[r][c] = currentElement;
                                    Console.WriteLine($"Swap ({rowIndex}, {colIndex}) with ({r}, {c})");
                                    break;
                                }
                            }
                        }
                    }
                    element++;
                }
            }

        }
        private static void MoveRightAndLeft(int[][] matrix, int indexOfRowOrCol, int moves)
        {
            int[] temp = new int[matrix[0].Length];
            for (int colIndex = 0; colIndex < matrix[0].Length; colIndex++)
            {
                temp[colIndex] = matrix[indexOfRowOrCol][(colIndex + moves) % matrix[0].Length];
            }

            matrix[indexOfRowOrCol] = temp;
        }

        private static void MoveUpAndDown(int[][] matrix, int indexOfRowOrCol, int moves)
        {
            int[] temp = new int[matrix.Length];

            for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
            {
                temp[rowIndex] = matrix[(rowIndex + moves) % matrix.Length][indexOfRowOrCol];
            }

            for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
            {
                matrix[rowIndex][indexOfRowOrCol] = temp[rowIndex];
            }
        }
    }
}
}