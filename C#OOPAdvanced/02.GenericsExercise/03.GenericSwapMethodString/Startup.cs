using System;
using System.Linq;

namespace _03.GenericSwapMethodString
{
    public class Startup
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var box = new Box<string>();
            for (int i = 0; i < n; i++)
            {
                var currentString = Console.ReadLine();
                box.Add(currentString);
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