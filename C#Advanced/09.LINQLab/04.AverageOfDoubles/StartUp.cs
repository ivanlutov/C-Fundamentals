using System;
using System.Linq;

namespace _04.AverageOfDoubles
{
    public class StartUp
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse);

            Console.WriteLine($"{numbers.Average():F2}");
        }
    }
}