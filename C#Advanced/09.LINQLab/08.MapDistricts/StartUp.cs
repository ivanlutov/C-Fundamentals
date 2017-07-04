using System;
using System.Linq;

namespace _08.MapDistricts
{
    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var limit = long.Parse(Console.ReadLine());

            input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(c =>
                {
                    var tokens = c.Split(':');
                    var cityCode = tokens[0];
                    var districtPopulation = long.Parse(tokens[1]);
                    return new { cityCode, districtPopulation };
                })
                .GroupBy(
                    c => c.cityCode,
                    c => c.districtPopulation,
                    (city, population) => new { CityCode = city, Populations = population.ToList() })
                .Where(x => x.Populations.Sum() >= limit)
                .OrderByDescending(x => x.Populations.Sum())
                .ToList()
                .ForEach(x => Console.WriteLine($"{x.CityCode}: {string.Join(" ", x.Populations.OrderByDescending(p => p).Take(5))}"));
        }
    }
}