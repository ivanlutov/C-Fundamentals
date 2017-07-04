using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _12.LegendaryFarming
{
    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var firstDict = new Dictionary<string, int>();
            var secondDict = new SortedDictionary<string, int>();
            firstDict["shards"] = 0;
            firstDict["fragments"] = 0;
            firstDict["motes"] = 0;
            var pattern = @"(?:(\d+) ([^\d| ]+))";

            while (!string.IsNullOrWhiteSpace(input))
            {
                MatchCollection collection = Regex.Matches(input, pattern);

                foreach (Match match in collection)
                {
                    var material = match.Groups[2].Value.ToLower();
                    var quantity = int.Parse(match.Groups[1].Value);

                    if (material == "shards" || material == "fragments" || material == "motes")
                    {
                        firstDict[material] += quantity;
                        if (firstDict[material] >= 250)
                        {
                            firstDict[material] -= 250;
                            if (material == "shards")
                            {
                                Console.WriteLine("Shadowmourne obtained!");
                            }
                            else if (material == "fragments")
                            {
                                Console.WriteLine("Valanyr obtained!");
                            }
                            else if (material == "motes")
                            {
                                Console.WriteLine("Dragonwrath obtained!");
                            }
                            foreach (var item in firstDict.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                            {
                                Console.WriteLine($"{item.Key}: {item.Value}");
                            }
                            foreach (var item in secondDict)
                            {
                                Console.WriteLine($"{item.Key}: {item.Value}");
                            }
                            return;
                        }
                    }
                    else
                    {
                        if (!secondDict.ContainsKey(material))
                        {
                            secondDict[material] = 0;
                        }
                        secondDict[material] += quantity;
                    }
                }

                input = Console.ReadLine();
            }
        }
    }
}