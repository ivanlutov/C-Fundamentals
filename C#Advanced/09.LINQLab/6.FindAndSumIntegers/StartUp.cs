using System;
using System.Linq;

namespace _06.FindAndSumIntegers
{
    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var result = input.Select(w =>
            {
                long value;
                bool success = long.TryParse(w, out value);
                return new { value, success };
            })
            .Where(s => s.success)
            .Select(n => n.value)
            .ToList();

            if (result.Any())
            {
                Console.WriteLine(result.Sum());
            }
            else
            {
                Console.WriteLine("No match");
            }
        }
    }
}