using System;
using System.Collections.Generic;

namespace _05.HotPotato
{
    public class StratUp
    {
        public static void Main()
        {
            var names = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var n = int.Parse(Console.ReadLine());
            var queue = new Queue<string>(names);

            while (queue.Count != 1)
            {
                for (int i = 1; i < n; i++)
                {
                    queue.Enqueue(queue.Dequeue());
                }
                Console.WriteLine($"Removed {queue.Dequeue()}");
            }
            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}