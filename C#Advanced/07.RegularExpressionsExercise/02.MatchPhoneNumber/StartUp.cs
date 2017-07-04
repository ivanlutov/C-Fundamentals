using System;
using System.Text.RegularExpressions;

namespace _02.MatchPhoneNumber
{
    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var pattern = @"^\+359( |-)\d{1}\1\d{3}\1\d{4}$";

            while (input != "end")
            {
                Regex regex = new Regex(pattern);
                MatchCollection matches = regex.Matches(input);

                foreach (var match in matches)
                {
                    Console.WriteLine(match);
                }

                input = Console.ReadLine();
            }
        }
    }
}