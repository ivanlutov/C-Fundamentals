using System;

namespace _05.GenericCountMethodString
{
    public class Startup
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var box = new Box<string>();
            for (int i = 0; i < n; i++)
            {
                var inputString = Console.ReadLine();
                box.Add(inputString);
            }

            var compareString = Console.ReadLine();

            var result = box.CompareTo(compareString);
            Console.WriteLine(result);
        }
    }
}