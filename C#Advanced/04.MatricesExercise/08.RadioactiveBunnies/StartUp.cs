using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.RadioactiveBunnies
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
                string line = Console.ReadLine().Trim();
                var currentColumn = new string[line.Length];
                for (int j = 0; j < line.Length; j++)
                {
                    currentColumn[j] = line[j].ToString();
                }
                matrix[i] = currentColumn;
            }

            string input = Console.ReadLine();

            for (int i = 0; i < input.Length; i++)
            {
                var currentSymbol = input[i];
                var coordinateRow = int.MinValue;
                var coordinateCol = int.MinValue;

                if (currentSymbol == 'U')
                {
                    PositionOfPerson(row, matrix, ref coordinateRow, ref coordinateCol);
                    if (coordinateRow == 0)
                    {
                        matrix[coordinateRow][coordinateCol] = ".";
                        MultiplieBunnies(row, matrix);
                        foreach (var r in matrix)
                        {
                            Console.WriteLine(string.Join("", r));
                        }
                        Console.WriteLine($"won: {coordinateRow} {coordinateCol}");
                        return;
                    }

                    coordinateRow -= 1;

                    if (matrix[coordinateRow][coordinateCol] == "B")
                    {
                        matrix[coordinateRow][coordinateCol] = ".";
                        MultiplieBunnies(row, matrix);
                        foreach (var r in matrix)
                        {
                            Console.WriteLine(string.Join("", r));
                        }
                        Console.WriteLine($"dead: {coordinateRow} {coordinateCol}");
                        return;
                    }
                    else
                    {
                        matrix[coordinateRow][coordinateCol] = "P";
                        matrix[coordinateRow + 1][coordinateCol] = ".";
                    }

                    MultiplieBunnies(row, matrix);

                    bool isDied = true;

                    for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
                    {
                        for (int colIndex = 0; colIndex < matrix[0].Length; colIndex++)
                        {
                            if (matrix[rowIndex][colIndex] == "P")
                            {
                                isDied = false;
                                break;
                            }
                        }
                    }

                    if (isDied)
                    {
                        foreach (var r in matrix)
                        {
                            Console.WriteLine(string.Join("", r));
                        }
                        Console.WriteLine($"dead: {coordinateRow} {coordinateCol}");
                        return;
                    }
                }
                else if (currentSymbol == 'D')
                {
                    PositionOfPerson(row, matrix, ref coordinateRow, ref coordinateCol);

                    if (coordinateRow == matrix.Length - 1)
                    {
                        matrix[coordinateRow][coordinateCol] = ".";
                        MultiplieBunnies(row, matrix);
                        foreach (var r in matrix)
                        {
                            Console.WriteLine(string.Join("", r));
                        }
                        Console.WriteLine($"won: {coordinateRow} {coordinateCol}");
                        return;
                    }

                    coordinateRow += 1;

                    if (matrix[coordinateRow][coordinateCol] == "B")
                    {
                        matrix[coordinateRow][coordinateCol] = ".";
                        MultiplieBunnies(row, matrix);
                        foreach (var r in matrix)
                        {
                            Console.WriteLine(string.Join("", r));
                        }
                        Console.WriteLine($"dead: {coordinateRow} {coordinateCol}");
                        return;
                    }
                    else
                    {
                        matrix[coordinateRow][coordinateCol] = "P";
                        matrix[coordinateRow - 1][coordinateCol] = ".";
                    }

                    MultiplieBunnies(row, matrix);

                    bool isDied = true;

                    for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
                    {
                        for (int colIndex = 0; colIndex < matrix[0].Length; colIndex++)
                        {
                            if (matrix[rowIndex][colIndex] == "P")
                            {
                                isDied = false;
                                break;
                            }
                        }
                    }

                    if (isDied)
                    {
                        foreach (var r in matrix)
                        {
                            Console.WriteLine(string.Join("", r));
                        }
                        Console.WriteLine($"dead: {coordinateRow} {coordinateCol}");
                        return;
                    }
                }
                else if (currentSymbol == 'L')
                {
                    PositionOfPerson(row, matrix, ref coordinateRow, ref coordinateCol);

                    if (coordinateCol == 0)
                    {
                        matrix[coordinateRow][coordinateCol] = ".";
                        MultiplieBunnies(row, matrix);
                        foreach (var r in matrix)
                        {
                            Console.WriteLine(string.Join("", r));
                        }
                        Console.WriteLine($"won: {coordinateRow} {coordinateCol}");
                        return;
                    }

                    coordinateCol -= 1;

                    if (matrix[coordinateRow][coordinateCol] == "B")
                    {
                        MultiplieBunnies(row, matrix);
                        foreach (var r in matrix)
                        {
                            Console.WriteLine(string.Join("", r));
                        }
                        Console.WriteLine($"dead: {coordinateRow} {coordinateCol}");
                        return;
                    }
                    else
                    {
                        matrix[coordinateRow][coordinateCol] = "P";
                        matrix[coordinateRow][coordinateCol + 1] = ".";
                    }

                    MultiplieBunnies(row, matrix);

                    bool isDied = true;

                    for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
                    {
                        for (int colIndex = 0; colIndex < matrix[0].Length; colIndex++)
                        {
                            if (matrix[rowIndex][colIndex] == "P")
                            {
                                isDied = false;
                                break;
                            }
                        }
                    }

                    if (isDied)
                    {
                        foreach (var r in matrix)
                        {
                            Console.WriteLine(string.Join("", r));
                        }
                        Console.WriteLine($"dead: {coordinateRow} {coordinateCol}");
                        return;
                    }
                }
                else if (currentSymbol == 'R')
                {
                    PositionOfPerson(row, matrix, ref coordinateRow, ref coordinateCol);

                    if (coordinateCol == matrix[0].Length - 1)
                    {
                        matrix[coordinateRow][coordinateCol] = ".";
                        MultiplieBunnies(row, matrix);
                        foreach (var r in matrix)
                        {
                            Console.WriteLine(string.Join("", r));
                        }
                        Console.WriteLine($"won: {coordinateRow} {coordinateCol}");
                        return;
                    }

                    coordinateCol += 1;

                    if (matrix[coordinateRow][coordinateCol] == "B")
                    {
                        MultiplieBunnies(row, matrix);
                        foreach (var r in matrix)
                        {
                            Console.WriteLine(string.Join("", r));
                        }
                        Console.WriteLine($"dead: {coordinateRow} {coordinateCol}");
                        return;
                    }
                    else
                    {
                        matrix[coordinateRow][coordinateCol] = "P";
                        matrix[coordinateRow][coordinateCol - 1] = ".";
                    }

                    MultiplieBunnies(row, matrix);

                    bool isDied = true;

                    for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
                    {
                        for (int colIndex = 0; colIndex < matrix[0].Length; colIndex++)
                        {
                            if (matrix[rowIndex][colIndex] == "P")
                            {
                                isDied = false;
                                break;
                            }
                        }
                    }

                    if (isDied)
                    {
                        foreach (var r in matrix)
                        {
                            Console.WriteLine(string.Join("", r));
                        }
                        Console.WriteLine($"dead: {coordinateRow} {coordinateCol}");
                        return;
                    }
                }
            }
        }

        private static void MultiplieBunnies(int row, string[][] matrix)
        {
            var indexOfBunniesRow = new List<int>();
            var indexOfBunniesCol = new List<int>();

            for (int rowIndex = 0; rowIndex < row; rowIndex++)
            {
                for (int colIndex = 0; colIndex < matrix[0].Length; colIndex++)
                {
                    if (matrix[rowIndex][colIndex] == "B")
                    {
                        indexOfBunniesRow.Add(rowIndex);
                        indexOfBunniesCol.Add(colIndex);
                    }
                }
            }

            for (int j = 0; j < indexOfBunniesRow.Count; j++)
            {
                if (indexOfBunniesRow[j] + 1 <= matrix.Length - 1)
                {
                    matrix[indexOfBunniesRow[j] + 1][indexOfBunniesCol[j]] = "B";
                }
                if (indexOfBunniesRow[j] - 1 >= 0)
                {
                    matrix[indexOfBunniesRow[j] - 1][indexOfBunniesCol[j]] = "B";
                }
                if (indexOfBunniesCol[j] + 1 <= matrix[0].Length - 1)
                {
                    matrix[indexOfBunniesRow[j]][indexOfBunniesCol[j] + 1] = "B";
                }
                if (indexOfBunniesCol[j] - 1 >= 0)
                {
                    matrix[indexOfBunniesRow[j]][indexOfBunniesCol[j] - 1] = "B";
                }
            }

            indexOfBunniesCol.Clear();
            indexOfBunniesRow.Clear();
        }

        private static void PositionOfPerson(int row, string[][] matrix, ref int coordinateRow, ref int coordinateCol)
        {
            for (int rowIndex = 0; rowIndex < row; rowIndex++)
            {
                for (int colIndex = 0; colIndex < matrix[0].Length; colIndex++)
                {
                    if (matrix[rowIndex][colIndex] == "P")
                    {
                        coordinateRow = rowIndex;
                        coordinateCol = colIndex;
                    }
                }
            }
        }
    }
}