using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _04.JediDreams
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
                sb.AppendLine(line);
            }

            var sourceCode = sb.ToString();
            var indexOfStaticMethod = sourceCode.IndexOf("static", 1);

            var methods = new Dictionary<string, List<string>>();
            var pattern = @"\s*(?:\s*|\.)(\s*[A-Z]\s*[a-zA-Z]+\s*)\s*\(";
            var staticMethod = string.Empty;

            while (indexOfStaticMethod != -1)
            {
                var part = sourceCode.Substring(0, indexOfStaticMethod);

                MatchCollection matches = Regex.Matches(part, pattern);
                staticMethod = matches[0].Groups[1].Value;

                if (!methods.ContainsKey(staticMethod))
                {
                    methods[staticMethod] = new List<string>();
                }

                for (int i = 1; i <= matches.Count - 1; i++)
                {
                    var currentMethod = matches[i].Groups[1].Value;
                    methods[staticMethod].Add(currentMethod);
                }

                sourceCode = sourceCode.Substring(part.Length);
                indexOfStaticMethod = sourceCode.IndexOf("static", 1);
            }

            MatchCollection lastMatches = Regex.Matches(sourceCode, pattern);
            staticMethod = lastMatches[0].Groups[1].Value;
            if (!methods.ContainsKey(staticMethod))
            {
                methods[staticMethod] = new List<string>();
            }

            for (int i = 1; i <= lastMatches.Count - 1; i++)
            {
                var currentMethod = lastMatches[i].Groups[1].Value;
                methods[staticMethod].Add(currentMethod);
            }

            var orderedMethods = methods
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var method in orderedMethods)
            {
                var listOfOrderedMethods = method.Value.OrderBy(x => x).ToList();
                Console.WriteLine($"{method.Key} -> {method.Value.Count} -> {string.Join(", ", listOfOrderedMethods)}");
            }
        }
    }
}