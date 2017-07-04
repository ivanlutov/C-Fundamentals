using System;
using System.Text.RegularExpressions;

namespace _03.SeriesOfLetters
{
    public class StartUp
    {
        public static void Main()
        {
            var text = Console.ReadLine();
            var regex = new Regex(@"(.)\1+");

            Console.WriteLine(regex.Replace(text, "$1"));
        }
    }
}