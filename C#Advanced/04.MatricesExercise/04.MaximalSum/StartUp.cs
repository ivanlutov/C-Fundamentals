using System;
using System.Linq;

namespace _04.MaximalSum
{
    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            var matrix = new int[input[0]][];

            for (int i = 0; i < input[0]; i++)
            {
                matrix[i] = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
            }

            var maxSum = int.MinValue;
            var resultMatrix = new int[3][];

            for (int rowIndex = 0; rowIndex < input[0] - 2; rowIndex++)
            {
                for (int colIndex = 0; colIndex < matrix[0].Length - 2; colIndex++)
                {
                    var one = matrix[rowIndex][colIndex];
                    var two = matrix[rowIndex][colIndex + 1];
                    var three = matrix[rowIndex][colIndex + 2];
                    var four = matrix[rowIndex + 1][colIndex];
                    var five = matrix[rowIndex + 1][colIndex + 1];
                    var six = matrix[rowIndex + 1][colIndex + 2];
                    var seven = matrix[rowIndex + 2][colIndex];
                    var eight = matrix[rowIndex + 2][colIndex + 1];
                    var nine = matrix[rowIndex + 2][colIndex + 2];

                    var currentSum = one + two + three + four + five + six + seven + eight + nine;

                    if (maxSum < currentSum)
                    {
                        maxSum = currentSum;
                        var first = new int[] { one, two, three };
                        var second = new int[] { four, five, six };
                        var third = new int[] { seven, eight, nine };

                        resultMatrix[0] = first;
                        resultMatrix[1] = second;
                        resultMatrix[2] = third;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");
            foreach (var row in resultMatrix)
            {
                Console.WriteLine(String.Join(" ", row));
            }
        }
    }
}