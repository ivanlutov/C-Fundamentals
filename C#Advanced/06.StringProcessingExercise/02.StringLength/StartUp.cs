using System;

namespace _02.StringLength
{
    public class StartUp
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            if (input.Length > 20)
            {
                input = input.Substring(0, 20);
            }

            input = input.PadRight(20, '*');

            Console.WriteLine(input);
        }
    }
}