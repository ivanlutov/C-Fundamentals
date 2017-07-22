using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.GenericSwapMethodString
{
    public class Startup
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var boxes = new List<Box<string>>();

            for (int i = 0; i < n; i++)
            {
                var box = new Box<string>(Console.ReadLine());
                boxes.Add(box);
            }

            var indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var firstIndex = indexes[0];
            var secondIndex = indexes[1];

            GenericSwapMethodString(boxes, firstIndex, secondIndex);

            for (int i = 0; i < boxes.Count(); i++)
            {
                Console.WriteLine(boxes[i]);
            }
        }

        private static void GenericSwapMethodString<T>(List<Box<T>> boxes, int firstIndex, int secondIndex)
        {
            Box<T> firstBox = boxes[firstIndex];
            boxes[firstIndex] = boxes[secondIndex];
            boxes[secondIndex] = firstBox;
        }
    }
}