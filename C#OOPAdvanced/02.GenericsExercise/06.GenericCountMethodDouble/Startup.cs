using System;

namespace _06.GenericCountMethodDouble
{
    public class Startup
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var box = new Box<double>();
            for (int i = 0; i < n; i++)
            {
                var doubles = double.Parse(Console.ReadLine());
                box.Add(doubles);
            }

            var compareDouble = double.Parse(Console.ReadLine());

            var result = box.CompareTo(compareDouble);
            Console.WriteLine(result);
        }
    }
}