using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _03.JediCode_X
{
    public class Startup
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var sb = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine();
                sb.Append(line);
            }
            var first = Console.ReadLine();
            var second = Console.ReadLine();

            var firstPattern = $"{first}([a-zA-Z]{{{first.Length}}})(?![a-zA-Z])";
            var secondPattern = $"{second}([a-zA-Z0-9]{{{second.Length}}})(?![a-zA-Z0-9])";

            var names = new Queue<string>();
            var message = new List<string>();

            MatchCollection nameMatches = Regex.Matches(sb.ToString(), firstPattern);
            MatchCollection messageMatches = Regex.Matches(sb.ToString(), secondPattern);

            foreach (Match name in nameMatches)
            {
                names.Enqueue(name.Groups[1].Value);
            }

            foreach (Match mes in messageMatches)
            {
                message.Add(mes.Groups[1].Value);
            }

            var indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var namesWithMessage = new List<string>();

            for (int i = 0; i < indexes.Length; i++)
            {
                if (names.Count == 0)
                {
                    break;
                }

                var messageIndex = indexes[i];

                if (message.Count >= messageIndex)
                {
                    var jedi = names.Dequeue();
                    var messageResult = $"{jedi} - {message[indexes[i] - 1]}";
                    namesWithMessage.Add(messageResult);
                }
            }

            foreach (var nameAndMessage in namesWithMessage)
            {
                Console.WriteLine(nameAndMessage);
            }
        }
    }
}