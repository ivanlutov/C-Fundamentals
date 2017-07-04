using System;
using System.Collections.Generic;
using System.Linq;

namespace _13.OfficeStuff
{
    public class StartUp
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            var dict = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < number; i++)
            {
                var tokens = Console.ReadLine().Split(new[] { ' ', '-', '|' }, StringSplitOptions.RemoveEmptyEntries);
                var company = tokens[0];
                var amount = int.Parse(tokens[1]);
                var product = tokens[2];

                if (!dict.ContainsKey(company))
                {
                    dict[company] = new Dictionary<string, int>();
                }
                if (!dict[company].ContainsKey(product))
                {
                    dict[company][product] = 0;
                }

                dict[company][product] += amount;
            }

            var productAndAmount = new List<string>();
            foreach (var company in dict.OrderBy(x => x.Key))
            {
                foreach (var product in company.Value)
                {
                    productAndAmount.Add($"{product.Key}-{product.Value}");
                }
                Console.WriteLine($"{company.Key}: {string.Join(", ", productAndAmount)}");
                productAndAmount.Clear();
            }
        }
    }
}