using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _05.ExtractTags
{
    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var sb = new StringBuilder();
            while (input != "END")
            {
                sb.AppendLine(input);
                input = Console.ReadLine();
            }

            input = sb.ToString();

            var pattern = @"<.+?>";
            var matches = Regex.Matches(input, pattern);

            foreach (var match in matches)
            {
                Console.WriteLine(match);
            }
        }
    }
}