using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.SequenceWithQueue
{
    public class StartUp
    {
        public static void Main()
        {
            long n = long.Parse(Console.ReadLine());
            Queue<long> queue = new Queue<long>();
            Queue<long> resultQueue = new Queue<long>();

            queue.Enqueue(n);
            resultQueue.Enqueue(n);

            while (queue.Count < 50)
            {
                long currentElement = queue.Dequeue();
                long first = currentElement + 1;
                long second = 2 * currentElement + 1;
                long third = currentElement + 2;

                queue.Enqueue(first);
                queue.Enqueue(second);
                queue.Enqueue(third);

                resultQueue.Enqueue(first);
                resultQueue.Enqueue(second);
                resultQueue.Enqueue(third);
            }

            var printQueue = resultQueue.Take(50);
            Console.WriteLine(string.Join(" ", printQueue));
        }
    }
}