using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _11.SemanticHTML
{
    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var idPatternOpen = @"<div\s*.*\s*(id\s*=\s*""(\w+)"")\s*.*>";
            var classPatternOpen = @"<div\s*.*\s*(class\s*=\s*""(\w+)"")\s*.*>";
            var closedTag = @"<\/div>\s*<!--\s*(\w+)\s*-->";
            var whiteSpacePattern = @"\s+";

            var sb = new StringBuilder();

            while (input != "END")
            {
                var idRegex = new Regex(idPatternOpen);
                var classRegex = new Regex(classPatternOpen);
                var closeRegex = new Regex(closedTag);
                Match idMatch = idRegex.Match(input);
                Match classMatch = classRegex.Match(input);
                Match closeMatch = closeRegex.Match(input);

                var replaced = string.Empty;
                var tag = string.Empty;
                if (idMatch.Success)
                {
                    tag = idMatch.Groups[2].Value;

                    replaced = Regex.Replace(input, idMatch.Groups[1].Value, "");
                    replaced = replaced.Replace("div", tag);
                    replaced = Regex.Replace(replaced, whiteSpacePattern, " ");

                    //тука проверявам и махам един space, който по някаква причина понякога
                    //остава на края преди затварящия таг и не мога да разбера защо :D
                    if (replaced[replaced.Length - 2] == ' ')
                    {
                        replaced = replaced.Remove(replaced.Length - 2, 1);
                    }
                }
                else if (classMatch.Success)
                {
                    tag = classMatch.Groups[2].Value;

                    replaced = Regex.Replace(input, classMatch.Groups[1].Value, "");
                    replaced = replaced.Replace("div", tag);
                    replaced = Regex.Replace(replaced, whiteSpacePattern, " ");
                }
                else if (closeMatch.Success)
                {
                    tag = closeMatch.Groups[1].Value;
                    replaced = $"</{tag}>";
                }
                else
                {
                    replaced = input;
                }

                sb.AppendLine(replaced);

                input = Console.ReadLine();
            }

            Console.WriteLine(sb.ToString().Trim());
        }
    }
}