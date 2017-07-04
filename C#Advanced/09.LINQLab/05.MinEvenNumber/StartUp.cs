using System;
using System.Linq;

namespace _05.MinEvenNumber
{
    public class StartUp
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse);

            try
            {
                var minNumber = numbers.Where(n => n % 2 == 0).Min();
                Console.WriteLine($"{minNumber:F2}");
            }
            catch (Exception e)
            {
                Console.WriteLine("No match");
            }
        }
    }
}