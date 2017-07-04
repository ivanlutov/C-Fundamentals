using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _08.ExtractHyperlinks
{
    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var sb = new StringBuilder();

            while (input != "END")
            {
                sb.Append(input);
                input = Console.ReadLine();
            }

            var text = sb.ToString();

            var pattern = @"<a\s+(?:[^>]+\s+)?href\s*=\s*(?:'([^']*)'|""([^""]*)""|([^\s>]+))[^>]*>";

            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(text);

            foreach (Match match in matches)
            {
                for (int i = 1; i <= 3; i++)
                {
                    if (match.Groups[i].Length > 0)
                    {
                        Console.WriteLine(match.Groups[i]);
                    }
                }
            }
        }
    }
}