using System;

namespace _05.DateModifier
{
    public class Startup
    {
        public static void Main()
        {
            var firstDate = Console.ReadLine();
            var secondDate = Console.ReadLine();

            var difference = DateModifier.CalculateDifferenceBetweenDate(firstDate, secondDate);
            Console.WriteLine(difference);
        }
    }
}