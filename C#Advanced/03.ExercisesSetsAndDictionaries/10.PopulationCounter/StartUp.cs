using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.PopulationCounter
{
    public class StartUp
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            Dictionary<string, Dictionary<string, long>> dictPopulation = new Dictionary<string, Dictionary<string, long>>();

            while (input != "report")
            {
                var inputLine = input.Split('|').ToArray();
                if (inputLine.Length > 1)
                {
                    var city = inputLine[0];
                    var country = inputLine[1];
                    var population = long.Parse(inputLine[2]);

                    if (!dictPopulation.ContainsKey(country))
                    {
                        dictPopulation[country] = new Dictionary<string, long>();
                    }
                    if (!dictPopulation[country].ContainsKey(city))
                    {
                        dictPopulation[country][city] = 0;
                    }
                    dictPopulation[country][city] += population;
                }

                input = Console.ReadLine();
            }

            foreach (var country in dictPopulation.OrderByDescending(x => x.Value.Values.Sum()))
            {
                var totalPopulation = country.Value.Select(x => x.Value).Sum();
                Console.WriteLine($"{country.Key} (total population: {totalPopulation})");
                foreach (var city in country.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"=>{city.Key}: {city.Value}");
                }
            }
        }
    }
}