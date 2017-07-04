using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.ParkingSystem
{
    public class StartUp
    {
        private static Dictionary<int, HashSet<int>> matrix;

        public static void Main()
        {
            var matrixSize = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            var rows = matrixSize[0];
            var cols = matrixSize[1];

            matrix = new Dictionary<int, HashSet<int>>();

            string command = Console.ReadLine();

            while (command != "stop")
            {
                var tokens = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                    .ToArray();
                var rowEntry = tokens[0];
                var targetRow = tokens[1];
                var targetCow = tokens[2];

                if (matrix.ContainsKey(targetRow) && matrix[targetRow].Count == cols - 1)
                {
                    Console.WriteLine($"Row {targetRow} full");
                    command = Console.ReadLine();
                    continue;
                }

                if (!IsOcuppiedPlace(targetRow, targetCow))
                {
                    ParkingCar(targetRow, targetCow);

                    PrintCarPlace(rowEntry, targetRow, targetCow);
                }
                else if (IsOcuppiedPlace(targetRow, targetCow))
                {
                    int newCol = 0;
                    var minDistance = int.MaxValue;

                    for (int colIndex = 1; colIndex < cols; colIndex++)
                    {
                        if (!IsOcuppiedPlace(targetRow, colIndex))
                        {
                            var currentDistance = Math.Abs(targetCow - colIndex);
                            if (currentDistance < minDistance)
                            {
                                minDistance = currentDistance;
                                newCol = colIndex;
                            }
                        }
                    }

                    ParkingCar(targetRow, newCol);

                    PrintCarPlace(rowEntry, targetRow, newCol);
                }

                command = Console.ReadLine();
            }
        }

        private static void PrintCarPlace(int rowEntry, int targetRow, int targetCow)
        {
            var destinationCount = Math.Abs(rowEntry - targetRow) + targetCow + 1;
            Console.WriteLine(destinationCount);
        }

        private static void ParkingCar(int targetRow, int targetCow)
        {
            if (!matrix.ContainsKey(targetRow))
            {
                matrix[targetRow] = new HashSet<int>();
            }
            matrix[targetRow].Add(targetCow);
        }

        private static bool IsOcuppiedPlace(int row, int col)
        {
            return matrix.ContainsKey(row) && matrix[row].Contains(col);
        }
    }
}