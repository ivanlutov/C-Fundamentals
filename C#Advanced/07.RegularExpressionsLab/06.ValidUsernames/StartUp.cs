using System;
using System.Text.RegularExpressions;

namespace _06.ValidUsernames
{
    public class StartUp
    {
        public static void Main()
        {
            var username = Console.ReadLine();

            while (username != "END")
            {
                var pattern = @"^[\w+-]{3,16}$";
                var match = Regex.Match(username, pattern);

                if (match.Success)
                {
                    Console.WriteLine("valid");
                }
                else
                {
                    Console.WriteLine("invalid");
                }

                username = Console.ReadLine();
            }
        }
    }
}