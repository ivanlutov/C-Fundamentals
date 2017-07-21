using System;

namespace _08.CustomListSorter
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