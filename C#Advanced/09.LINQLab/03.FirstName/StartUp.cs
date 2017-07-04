using System;
using System.Linq;

namespace _03.FirstName
{
    public class StartUp
    {
        public static void Main()
        {
            var names = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var letters = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .OrderBy(l => l);

            foreach (var letter in letters)
            {
                var result = names
                    .FirstOrDefault(w => w[0].ToString().ToLower() == letter.ToLower());

                if (result != null)
                {
                    Console.WriteLine(result);
                    return;
                }
            }

            Console.WriteLine("No match");
        }
    }
}