using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _13.SrabskoUnleashed
{
    public class StartUp
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            Dictionary<string, Dictionary<string, long>> dict = new Dictionary<string, Dictionary<string, long>>();

            string pattern = @"(.*?) @(.*?) (\d+) (\d+)";
            Regex regex = new Regex(pattern);

            while (input != "End")
            {
                if (!regex.IsMatch(input))
                {
                    input = Console.ReadLine();
                    continue;
                }

                MatchCollection tokens = regex.Matches(input);
                foreach (Match token in tokens)
                {
                    var name = token.Groups[1].ToString();
                    var place = token.Groups[2].ToString();
                    var ticketPrice = int.Parse(token.Groups[3].ToString());
                    var ticketCount = int.Parse(token.Groups[4].ToString());

                    if (!dict.ContainsKey(place))
                    {
                        dict[place] = new Dictionary<string, long>();
                    }
                    if (!dict[place].ContainsKey(name))
                    {
                        dict[place][name] = 0;
                    }
                    dict[place][name] += ticketCount * ticketPrice;
                }

                input = Console.ReadLine();
            }

            foreach (var place in dict)
            {
                Console.WriteLine(place.Key);
                foreach (var singer in place.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {singer.Key} -> {singer.Value}");
                }
            }
        }
    }
}