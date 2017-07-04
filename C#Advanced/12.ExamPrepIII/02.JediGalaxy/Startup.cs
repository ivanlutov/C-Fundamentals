using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.JediGalaxy
{
    public class Startup
    {
        public static void Main()
        {
            var dimensions = Console.ReadLine().Split().Select(long.Parse).ToArray();
            var rows = dimensions[0];
            var cols = dimensions[1];

            var matrix = new long[rows][];
            var counter = 0;

            for (int rowIndex = 0; rowIndex < rows; rowIndex++)
            {
                matrix[rowIndex] = new long[cols];

                for (int colIndex = 0; colIndex < cols; colIndex++)
                {
                    matrix[rowIndex][colIndex] = counter++;
                }
            }

            var ivoCoordinates = Console.ReadLine();
            var totalSum = 0L;

            while (ivoCoordinates != "Let the Force be with you")
            {
                var ivoTokens = ivoCoordinates
                    .Split()
                    .Select(long.Parse)
                    .ToArray();

                var evilCoordinates = Console.ReadLine()
                    .Split()
                    .Select(long.Parse)
                    .ToArray();

                var evilRow = evilCoordinates[0];
                var evilCol = evilCoordinates[1];
                var ivoRow = ivoTokens[0];
                var ivoCol = ivoTokens[1];
                KeyValuePair<long, long> ivo = new KeyValuePair<long, long>(ivoRow, ivoCol);
                KeyValuePair<long, long> evil = new KeyValuePair<long, long>(evilRow, evilCol);

                totalSum += Gather(matrix, ivo, evil);

                ivoCoordinates = Console.ReadLine();
            }

            Console.WriteLine(totalSum);
        }

        private static long Gather(long[][] stars, KeyValuePair<long, long> ivo, KeyValuePair<long, long> evil)
        {
            long ivoPoints = 0;

            while (evil.Key >= 0)
            {
                if (IsInRange(stars, evil.Key, evil.Value))
                {
                    stars[evil.Key][evil.Value] = 0;
                }

                evil = new KeyValuePair<long, long>(evil.Key - 1, evil.Value - 1);
            }

            while (ivo.Key >= 0)
            {
                if (IsInRange(stars, ivo.Key, ivo.Value))
                {
                    ivoPoints += stars[ivo.Key][ivo.Value];
                }

                ivo = new KeyValuePair<long, long>(ivo.Key - 1, ivo.Value + 1);
            }

            return ivoPoints;
        }

        private static bool IsInRange(long[][] matrix, long row, long col)
        {
            return row >= 0 && row < matrix.Length && col >= 0 && col < matrix[0].Length;
        }
    }
}