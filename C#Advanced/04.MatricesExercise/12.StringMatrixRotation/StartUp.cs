using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _12.StringMatrixRotation
{
    public class StartUp
    {
        private static char[][] matrix;
        private static List<string> words;

        public static void Main()
        {
            var rotate = Console.ReadLine();
            var pattern = @"(\d+)";
            var degree = int.Parse(Regex.Match(rotate, pattern).Groups[1].Value);
            degree = degree % 360;

            words = new List<string>();
            var word = Console.ReadLine();

            while (word != "END")
            {
                words.Add(word);
                word = Console.ReadLine();
            }

            var rows = words.Count();
            var cols = words.Max(w => w.Length);

            matrix = new char[rows][];

            for (int rowIndex = 0; rowIndex < rows; rowIndex++)
            {
                matrix[rowIndex] = new char[cols];
                for (int colIndex = 0; colIndex < matrix[0].Length; colIndex++)
                {
                    if (colIndex <= words[rowIndex].Length - 1)
                    {
                        matrix[rowIndex][colIndex] = words[rowIndex][colIndex];
                    }
                    else
                    {
                        matrix[rowIndex][colIndex] = ' ';
                    }
                }
            }

            if (degree == 90)
            {
                matrix = MatrixRotate90(rows, cols);
            }
            if (degree == 180)
            {
                matrix = MatrixRotate180(rows, cols);
            }
            if (degree == 270)
            {
                matrix = MatrixRotate270(rows, cols);
            }

            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join("", row));
            }
        }

        private static char[][] MatrixRotate90(int rows, int cols)
        {
            var newMatrix = new char[cols][];

            for (int colIndex = cols; colIndex > 0; colIndex--)
            {
                var currentArray = new char[rows];
                for (int rowIndex = rows; rowIndex > 0; rowIndex--)
                {
                    currentArray[Math.Abs(rowIndex - rows)] = matrix[rowIndex - 1][Math.Abs(colIndex - cols)];
                }
                newMatrix[Math.Abs(colIndex - cols)] = currentArray;
            }

            return newMatrix;
        }

        private static char[][] MatrixRotate180(int rows, int cols)
        {
            var newMatrix = new char[rows][];

            for (int rowIndex = rows; rowIndex > 0; rowIndex--)
            {
                var currentArray = new char[cols];
                for (int colIndex = cols; colIndex > 0; colIndex--)
                {
                    currentArray[Math.Abs(colIndex - cols)] = matrix[rowIndex - 1][colIndex - 1];
                }
                newMatrix[Math.Abs(rowIndex - rows)] = currentArray;
            }

            return newMatrix;
        }

        private static char[][] MatrixRotate270(int rows, int cols)
        {
            var newMatrix = new char[cols][];

            for (int colIndex = cols; colIndex > 0; colIndex--)
            {
                var currentArray = new char[rows];
                for (int rowIndex = rows; rowIndex > 0; rowIndex--)
                {
                    currentArray[Math.Abs(rowIndex - rows)] = matrix[Math.Abs(rowIndex - rows)][colIndex - 1];
                }
                newMatrix[Math.Abs(colIndex - cols)] = currentArray;
            }

            return newMatrix;
        }
    }
}