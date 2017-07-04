using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.SecondNature
{
    public class Startup
    {
        public static void Main()
        {
            Queue<int> flowers = new Queue<int>(Console.ReadLine()
                .Split(new[] { ' ', '\t', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());
            Stack<int> buckets = new Stack<int>(Console.ReadLine()
                .Split(new[] { ' ', '\t', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            var secondNature = new List<int>();

            while (true)
            {
                if (flowers.Count == 0 || buckets.Count == 0)
                {
                    break;
                }

                var firstBucket = buckets.Pop();
                var firstFlower = flowers.Dequeue();

                if (firstBucket >= firstFlower)
                {
                    if (firstBucket == firstFlower)
                    {
                        secondNature.Add(firstFlower);
                        continue;
                    }

                    firstBucket -= firstFlower;

                    if (buckets.Count >= 1)
                    {
                        var currentBucket = buckets.Pop() + firstBucket;
                        buckets.Push(currentBucket);
                    }
                    else if (buckets.Count == 0)
                    {
                        buckets.Push(firstBucket);
                    }
                }
                else
                {
                    firstFlower -= firstBucket;
                    var remainingFlowers = flowers.ToArray();
                    flowers.Clear();
                    flowers.Enqueue(firstFlower);

                    foreach (var flower in remainingFlowers)
                    {
                        flowers.Enqueue(flower);
                    }
                }
            }

            Console.WriteLine(flowers.Count > 0 ? string.Join(" ", flowers) : string.Join(" ", buckets));

            Console.WriteLine(secondNature.Count > 0 ? string.Join(" ", secondNature) : "None");
        }
    }
}