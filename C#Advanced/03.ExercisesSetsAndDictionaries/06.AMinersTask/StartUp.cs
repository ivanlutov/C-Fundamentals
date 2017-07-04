using System;
using System.Collections.Generic;

namespace _06.AMinersTask
{
    public class StartUp
    {
        public static void Main()
        {
            string resourceType = Console.ReadLine();

            var resource = new Dictionary<string, long>();

            while (!resourceType.Equals("stop"))
            {
                long resourceCount = long.Parse(Console.ReadLine());

                if (!resource.ContainsKey(resourceType))
                {
                    resource[resourceType] = 0;
                }
                resource[resourceType] += resourceCount;

                resourceType = Console.ReadLine();
            }

            foreach (var kvp in resource)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}