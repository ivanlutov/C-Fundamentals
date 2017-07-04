using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.UserLogs
{
    public class StartUp
    {
        public static void Main()
        {
            var commandLine = Console.ReadLine().Split().ToList();

            var usernameDictionary = new SortedDictionary<string, Dictionary<string, int>>();

            while (!commandLine[0].Equals("end"))
            {
                var commandIp = commandLine[0].Split('=').ToList();
                var commandUsername = commandLine[2].Split('=').ToList();
                var ip = commandIp[1];
                var username = commandUsername[1];

                if (!usernameDictionary.ContainsKey(username))
                {
                    usernameDictionary.Add(username, new Dictionary<string, int>());
                }

                if (!usernameDictionary[username].ContainsKey(ip))
                {
                    usernameDictionary[username][ip] = 0;
                }

                usernameDictionary[username][ip]++;

                commandLine = Console.ReadLine().Split().ToList();
            }

            foreach (var username in usernameDictionary)
            {
                Console.WriteLine($"{username.Key}: ");
                foreach (var kvp in username.Value)
                {
                    if (kvp.Equals(username.Value.Last()))
                    {
                        Console.WriteLine($"{kvp.Key} => {kvp.Value}.");
                        break;
                    }

                    Console.Write($"{kvp.Key} => {kvp.Value}, ");
                }
            }
        }
    }
}