using System;
using System.Linq;

namespace _02.CubicsRube
{
    public class Startup
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var input = Console.ReadLine();
            int populatedFields = 0;
            long sumOfPopulatedFields = 0;

            while (input != "Analyze")
            {
                var inputInts = input.Split().Select(int.Parse).ToArray();
                var firstD = inputInts[0];
                var secondD = inputInts[1];
                var thirdD = inputInts[2];
                var value = inputInts[3];

                var dimensions = new[] { firstD, secondD, thirdD };

                if (!dimensions.Any(x => x < 0 || x >= n) && value != 0)
                {
                    sumOfPopulatedFields += value;
                    populatedFields++;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(sumOfPopulatedFields);
            Console.WriteLine(Math.Pow(n, 3) - populatedFields);
        }
    }
}