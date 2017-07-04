using System;
using System.Text.RegularExpressions;

namespace _07.ValidTime
{
    public class StartUp
    {
        public static void Main()
        {
            var time = Console.ReadLine();

            while (time != "END")
            {
                var pattern = @"^((([0][0-9]|[1][0-1]):[0-5][0-9]:[0-5][0-9] [AP]M)|12:00:00 [PA]M)$";
                var match = Regex.Match(time, pattern);

                if (match.Success)
                {
                    Console.WriteLine("valid");
                }
                else
                {
                    Console.WriteLine("invalid");
                }

                time = Console.ReadLine();
            }
        }
    }
}