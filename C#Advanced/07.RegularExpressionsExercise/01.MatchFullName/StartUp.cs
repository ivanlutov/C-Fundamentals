using System;
using System.Text.RegularExpressions;

namespace _01.MatchFullName
{
    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var pattern = @"\b[A-Z]{1}[a-z]+\s+[A-Z]{1}[a-z]+\b";

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