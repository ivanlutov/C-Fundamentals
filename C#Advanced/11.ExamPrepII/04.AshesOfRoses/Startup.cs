using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _04.AshesOfRoses
{
    public class Startup
    {
        public static void Main()
        {
            var pattern = @"^Grow <([A-Z]{1}[a-z]+)> <([a-zA-Z0-9]+)> (\d+)$";
            var roses = new Dictionary<string, Dictionary<string, long>>();

            var inputLine = Console.ReadLine();
            while (inputLine != "Icarus, Ignite!")
            {
                var match = Regex.Match(inputLine, pattern);

                if (match.Success)
                {
                    var region = match.Groups[1].Value;
                    var color = match.Groups[2].Value;
                    var count = int.Parse(match.Groups[3].Value);

                    if (!roses.ContainsKey(region))
                    {
                        roses[region] = new Dictionary<string, long>();
                    }
                    if (!roses[region].ContainsKey(color))
                    {
                        roses[region][color] = 0;
                    }
                    roses[region][color] += count;
                }

                inputLine = Console.ReadLine();
            }

            var orderedRoses = roses
                .OrderByDescending(x => x.Value.Sum(y => y.Value))
                .ThenBy(x => x.Key);

            foreach (var region in orderedRoses)
            {
                Console.WriteLine(region.Key);
                var orderedColors = region.Value.OrderBy(x => x.Value).ThenBy(x => x.Key);

                foreach (var color in orderedColors)
                {
                    Console.WriteLine($"*--{color.Key} | {color.Value}");
                }
            }
        }
    }
}