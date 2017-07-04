using System;
using System.Text.RegularExpressions;

namespace _01.MatchCount
{
    public class StartUp
    {
        public static void Main()
        {
            var pattern = Console.ReadLine();
            var text = Console.ReadLine();

            var count = Regex.Matches(text, pattern).Count;

            Console.WriteLine(count);
        }
    }
}