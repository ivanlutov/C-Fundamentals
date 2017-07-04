using System;
using System.Linq;

namespace _05.RubiksMatrix
{
    public class StartUp
    {
        public static void Main()
        {
            var matrixSize = Console.ReadLine().Split(new char[] { ' ' }).Select(int.Parse).ToArray();
            var row = matrixSize[0];
            var col = matrixSize[1];

            var matrix = new string[row][];

            int countNum = 1;
            for (int i = 0; i < row; i++)
            {
                string line = Console.ReadLine().Trim();
                var currentColumn = new string[line.Length];
                for (int j = 0; j < line.Length; j++)
                {
                    currentColumn[j] = line[j].ToString();
                }
                matrix[i] = currentColumn;
            }
            //for (int rowIndex = 0; rowIndex < row; rowIndex++)
            //{
            //    matrix[rowIndex] = new int[col];

            //    for (int colIndex = 0; colIndex < matrix[0].Length; colIndex++)
            //    {
            //        matrix[rowIndex][colIndex] = countNum;
            //        countNum++;
            //    }
            //}

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var column = int.Parse(line[0]);
                var command = line[1];
                var count = int.Parse(line[2]);

                if (command == "up")
                {
                    for (int rowIndex = 0; rowIndex < row; rowIndex++)
                    {
                        for (int colIndex = 0; colIndex < matrix[0].Length; colIndex++)
                        {
                            if (colIndex == column)
                            {
                                for (int j = 0; j < count; j++)
                                {
                                }
                            }
                        }
                    }
                }
                else if (command == "down")
                {
                }
                else if (command == "right")
                {
                }
                else if (command == "left")
                {
                }
            }
            //foreach (var rowe in matrix)
            //{
            //    Console.WriteLine(string.Join(" ",rowe));
            //}
        }
    }
}