using System;
using System.Linq;

namespace _04.GenericSwapMethodInteger
{
    public class Startup
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var box = new Box<int>();
            for (int i = 0; i < n; i++)
            {
                var currentInt = int.Parse(Console.ReadLine());
                box.Add(currentInt);
            }

            var indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var firstIndex = indexes[0];
            var secondIndex = indexes[1];

            box.Swap(firstIndex, secondIndex);

            for (int i = 0; i < box.GetList().Count; i++)
            {
                Console.WriteLine($"{box} {box.GetList()[i]}");
            }
        }
    }
}