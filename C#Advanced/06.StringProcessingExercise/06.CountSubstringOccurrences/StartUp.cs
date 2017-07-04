using System;

namespace _06.CountSubstringOccurrences
{
    public class StartUp
    {
        public static void Main()
        {
            var text = Console.ReadLine();
            var pattern = Console.ReadLine();

            int count = 0;
            var index = text.IndexOf(pattern, StringComparison.OrdinalIgnoreCase);

            while (index >= 0)
            {
                count++;
                index++;

                index = text.IndexOf(pattern, index, StringComparison.OrdinalIgnoreCase);
            }
            Console.WriteLine(count);
        }
    }
}