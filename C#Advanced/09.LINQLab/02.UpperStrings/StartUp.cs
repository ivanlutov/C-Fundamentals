using System;
using System.Linq;

namespace _02.UpperStrings
{
    public class StartUp
    {
        public static void Main()
        {
            var names = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(w => w.ToUpper());

            Console.WriteLine(string.Join(" ", names));
        }
    }
}