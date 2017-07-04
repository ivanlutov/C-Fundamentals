using System;
using System.Text.RegularExpressions;

namespace _05.ExtractEmail
{
    public class StartUp
    {
        public static void Main()
        {
            var text = Console.ReadLine();

            var pattern = @"\s([0-9A-Za-z]+(-*|_*|\.*)[0-9a-zA-Z]+@[a-z]+-*[a-z]*(\.[a-z]+)+)";
            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(text);

            foreach (Match match in matches)
            {
                var emailForPrint = match.Groups[1].Value;
                Console.WriteLine(emailForPrint);
            }
        }
    }
}