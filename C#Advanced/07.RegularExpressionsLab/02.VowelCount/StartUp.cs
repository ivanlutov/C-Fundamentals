using System;
using System.Text.RegularExpressions;

namespace _02.VowelCount
{
    public class StartUp
    {
        public static void Main()
        {
            var text = Console.ReadLine();
            var pattern = "[aeiouyAEIOUY]";

            var count = Regex.Matches(text, pattern).Count;

            Console.WriteLine($"Vowels: {count}");
        }
    }
}