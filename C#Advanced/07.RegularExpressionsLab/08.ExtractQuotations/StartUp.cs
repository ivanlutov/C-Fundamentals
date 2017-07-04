using System;
using System.Text.RegularExpressions;

namespace _08.ExtractQuotations
{
    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var pattern = "(\'|\")(.+?)\\1";

            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(input);

            foreach (Match match in matches)
            {
                Console.WriteLine(match.Groups[2].Value);
            }
        }
    }
}