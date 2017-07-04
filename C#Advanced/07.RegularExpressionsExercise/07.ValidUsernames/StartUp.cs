using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _07.ValidUsernames
{
    public class StartUp
    {
        public static void Main()
        {
            var usernames = Console.ReadLine();

            var pattern = @"\b[a-zA-Z][\w]{2,24}\b";
            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(usernames);

            var validUsernames = new List<string>();

            foreach (Match match in matches)
            {
                validUsernames.Add(match.Value);
            }

            var maxLenght = int.MinValue;
            var firstUsernameForPrint = string.Empty;
            var secondUsernameForPrint = string.Empty;

            for (int i = 0; i < validUsernames.Count - 1; i++)
            {
                var firstUsername = validUsernames[i];
                var secondUsername = validUsernames[i + 1];

                if (firstUsername.Length + secondUsername.Length > maxLenght)
                {
                    maxLenght = firstUsername.Length + secondUsername.Length;
                    firstUsernameForPrint = firstUsername;
                    secondUsernameForPrint = secondUsername;
                }
            }

            Console.WriteLine(firstUsernameForPrint);
            Console.WriteLine(secondUsernameForPrint);
        }
    }
}