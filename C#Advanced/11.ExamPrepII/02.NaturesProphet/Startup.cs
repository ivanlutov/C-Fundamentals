using System;
using System.Linq;

namespace _02.NaturesProphet
{
    public class Startup
    {
        public static void Main()
        {
            var dimension = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var rows = dimension[0];
            var cols = dimension[1];

            var matrix = new int[rows][];

            for (int rowIndex = 0; rowIndex < rows; rowIndex++)
            {
                matrix[rowIndex] = new int[cols];

                for (int colIndex = 0; colIndex < matrix[0].Length; colIndex++)
                {
                    matrix[rowIndex][colIndex] = 0;
                }
            }

            var coordinates = Console.ReadLine();

            while (coordinates != "Bloom Bloom Plow")
            {
                var tokens = coordinates.Split().Select(int.Parse).ToArray();
                var currentRow = tokens[0];
                var currentCol = tokens[1];

                for (int rolIndex = 0; rolIndex < matrix.Length; rolIndex++)
                {
                    for (int colIndex = 0; colIndex < matrix[rolIndex].Length; colIndex++)
                    {
                        if (rolIndex == currentRow)
                        {
                            matrix[rolIndex][colIndex]++;
                        }
                        else if (colIndex == currentCol)
                        {
                            matrix[rolIndex][colIndex]++;
                        }
                    }
                }

                coordinates = Console.ReadLine();
            }

            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}