using System;
using System.Text.RegularExpressions;

namespace _06.SentenceExtractor
{
    public class StartUp
    {
        public static void Main()
        {
            var textPattern = Console.ReadLine();
            var text = Console.ReadLine();

            var pattern = @"(.+?(\.|\!|\?))";
            var wordPattern = $@"\b{textPattern}\b";

            var regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(text);

            foreach (Match match in matches)
            {
                //if (match.Value.Contains($" {textPattern} "))
                //{
                //    Console.WriteLine(match.Value.Trim());
                //}
                var regexWord = new Regex(wordPattern);
                Match wordMatch = regexWord.Match(match.Value);
                if (wordMatch.Success)
                {
                    Console.WriteLine(match.Value.Trim());
                }
            }
        }
    }
}