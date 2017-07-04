using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _09.QueryMess
{
    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var firstPattern = @"(%20|\+)";
            var secondPattern = @"\s+";
            var sb = new StringBuilder();

            while (input != "END")
            {
                input = Regex.Replace(input, firstPattern, " ");
                input = Regex.Replace(input, secondPattern, " ");
                var indexOfQuestionMark = input.IndexOf('?');
                if (indexOfQuestionMark != -1)
                {
                    input = input.Substring(indexOfQuestionMark + 1);
                }

                var tokens = input.Split('&');

                var result = new Dictionary<string, List<string>>();

                foreach (var token in tokens)
                {
                    var parts = token.Split('=');
                    var key = parts[0].Trim();
                    if (!result.ContainsKey(key))
                    {
                        result[key] = new List<string>();
                    }

                    for (int i = 1; i < parts.Length; i++)
                    {
                        result[key].Add(parts[i].Trim());
                    }
                }

                foreach (var kvp in result)
                {
                    sb.Append($"{kvp.Key}=[{string.Join(", ", kvp.Value)}]");
                }
                result.Clear();
                sb.AppendLine();
                input = Console.ReadLine();
            }

            Console.WriteLine(sb.ToString().TrimEnd());
        }
    }
}