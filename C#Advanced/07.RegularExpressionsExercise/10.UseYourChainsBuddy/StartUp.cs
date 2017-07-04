using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _10.UseYourChainsBuddy
{
    public class StartUp
    {
        public static void Main()
        {
            var html = Console.ReadLine();

            var tagPattern = @"<p>(.*?)<\/p>";
            var letterAndDigitsPattern = @"[^a-z0-9]";
            var whiteSpacePattern = @"\s+";

            Regex regex = new Regex(tagPattern);
            MatchCollection matches = regex.Matches(html);

            var sb = new StringBuilder();

            foreach (Match match in matches)
            {
                sb.Append(match.Groups[1].Value);
            }

            var replaced = Regex.Replace(sb.ToString(), letterAndDigitsPattern, " ");
            sb.Clear();

            for (int i = 0; i < replaced.Length; i++)
            {
                if (replaced[i] >= 'a' && replaced[i] <= 'm')
                {
                    char character = (char)((int)(replaced[i]) + 13);
                    sb.Append(character);
                }
                else if (replaced[i] >= 'n' && replaced[i] <= 'z')
                {
                    char character = (char)((int)(replaced[i]) - 13);
                    sb.Append(character);
                }
                else
                {
                    sb.Append(replaced[i]);
                }
            }

            var result = Regex.Replace(sb.ToString(), whiteSpacePattern, " ");
            Console.WriteLine(result);
        }
    }
}