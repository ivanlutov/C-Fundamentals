using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.RectangleIntersection
{
    public class Startup
    {
        public static void Main()
        {
            var counts = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var numberOfRectangles = counts[0];
            var numberOfIntersection = counts[1];
            var rectangles = new List<Rectangle>();

            for (int i = 0; i < numberOfRectangles; i++)
            {
                var tokens = Console.ReadLine().Split();
                var id = tokens[0];
                var width = double.Parse(tokens[1]);
                var height = double.Parse(tokens[2]);
                var topLeftX = double.Parse(tokens[3]);
                var topLeftY = double.Parse(tokens[4]);
                var rectangle = new Rectangle(id, width, height, topLeftX, topLeftY);
                rectangles.Add(rectangle);
            }

            for (int i = 0; i < numberOfIntersection; i++)
            {
                var tokens = Console.ReadLine().Split();
                var id1 = tokens[0];
                var id2 = tokens[1];
                var firstRectangle = rectangles.Where(r => r.Id == id1).FirstOrDefault();
                var secondRectangle = rectangles.Where(r => r.Id == id2).FirstOrDefault();

                var intersect = firstRectangle.Intersect(secondRectangle);

                if (intersect)
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }
            }
        }
    }
}