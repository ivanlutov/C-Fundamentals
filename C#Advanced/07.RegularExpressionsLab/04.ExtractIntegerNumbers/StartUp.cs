using System;
using System.Text.RegularExpressions;

namespace _04.ExtractIntegerNumbers
{
    public class StartUp
    {
        public static void Main()
        {
            var text = Console.ReadLine();

            var pattern = @"\d+";
            var matches = Regex.Matches(text, pattern);

            foreach (var match in matches)
            {
                Console.WriteLine(match);
            }
        }
    }
}