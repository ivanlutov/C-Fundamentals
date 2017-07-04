using System;
using System.Linq;

namespace _01.MatrixOfPalindromes
{
    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var row = input[0];
            var col = input[1];

            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            string[,] matrix = new string[row, col];

            for (int rowIndex = 0; rowIndex < row; rowIndex++)
            {
                for (int colIndex = 0; colIndex < col; colIndex++)
                {
                    matrix[rowIndex, colIndex] = $"{alphabet[rowIndex]}{alphabet[rowIndex + colIndex]}{alphabet[rowIndex]}";
                }
            }

            for (int rowIndex = 0; rowIndex < row; rowIndex++)
            {
                for (int colIndex = 0; colIndex < col; colIndex++)
                {
                    Console.Write(matrix[rowIndex, colIndex] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}