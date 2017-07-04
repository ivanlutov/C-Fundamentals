using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.CubicAssault
{
    public class Startup
    {
        private const int MeteorOverflow = 1000000;

        public static void Main()
        {
            var input = Console.ReadLine();
            var cubic = new Dictionary<string, Dictionary<string, long>>();

            while (input != "Count em all")
            {
                var tokens = input.Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);
                var region = tokens[0];
                var meteor = tokens[1];
                var count = long.Parse(tokens[2]);

                if (!cubic.ContainsKey(region))
                {
                    cubic[region] = new Dictionary<string, long>();
                    cubic[region]["Black"] = 0;
                    cubic[region]["Red"] = 0;
                    cubic[region]["Green"] = 0;
                }
                cubic[region][meteor] += count;

                if (cubic[region]["Green"] >= MeteorOverflow)
                {
                    long redCount = cubic[region]["Green"] / MeteorOverflow;
                    long greenCount = cubic[region]["Green"] % MeteorOverflow;

                    cubic[region]["Green"] = greenCount;
                    cubic[region]["Red"] += redCount;
                }

                if (cubic[region]["Red"] >= MeteorOverflow)
                {
                    long blackCount = cubic[region]["Red"] / MeteorOverflow;
                    long redCount = cubic[region]["Red"] % MeteorOverflow;

                    cubic[region]["Red"] = redCount;
                    cubic[region]["Black"] += blackCount;
                }

                input = Console.ReadLine();
            }

            var orderedRegions = cubic
                .OrderByDescending(x => x.Value["Black"])
                .ThenBy(y => y.Key.Length)
                .ThenBy(x => x.Key);

            foreach (var region in orderedRegions)
            {
                Console.WriteLine($"{region.Key}");

                var orderedMeteors = region
                    .Value
                    .OrderByDescending(x => x.Value)
                    .ThenBy(x => x.Key);
                foreach (var meteor in orderedMeteors)
                {
                    Console.WriteLine($"-> {meteor.Key} : {meteor.Value}");
                }
            }
        }
    }
}