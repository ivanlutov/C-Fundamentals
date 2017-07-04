using System;
using System.Text.RegularExpressions;

namespace _03.NonDigitCount
{
    public class StartUp
    {
        public static void Main()
        {
            var text = Console.ReadLine();
            var pattern = @"[\D]";

            var count = Regex.Matches(text, pattern).Count;

            Console.WriteLine($"Non-digits: {count}");
        }
    }
}