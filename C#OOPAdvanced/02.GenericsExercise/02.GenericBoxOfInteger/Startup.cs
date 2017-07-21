using System;

namespace _02.GenericBoxOfInteger
{
    public class Startup
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var inputInt = int.Parse(Console.ReadLine());
                var box = new Box<int>(inputInt);
                Console.WriteLine(box);
            }
        }
    }
}