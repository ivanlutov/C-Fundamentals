using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _04.ReplaceATag
{
    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var sb = new StringBuilder();

            while (input != "end")
            {
                sb.AppendLine(input);
                input = Console.ReadLine();
            }

            var text = sb.ToString();
            var pattern = @"<a (href=.+?)>(.+)<\/a>";

            var replaced = Regex.Replace(text, pattern, m => $"[URL {m.Groups[1]}]{m.Groups[2]}[/URL]");

            Console.WriteLine(replaced);
        }
    }
}