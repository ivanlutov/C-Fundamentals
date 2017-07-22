using System;

namespace _09.CustomListIterator
{
    public class Startup
    {
        public static void Main()
        {
            var interpretator = new CommandInterpretator();

            var input = Console.ReadLine();
            while (input != "END")
            {
                interpretator.ParseCommand(input);
                input = Console.ReadLine();
            }
        }
    }
}