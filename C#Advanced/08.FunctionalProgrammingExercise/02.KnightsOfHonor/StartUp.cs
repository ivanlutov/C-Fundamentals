using System;
using System.Linq;

namespace _02.KnightsOfHonor
{
    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            Action<string> names = w => Console.WriteLine($"Sir {w}");
            foreach (var name in input)
            {
                names(name);
            }
        }
    }
}