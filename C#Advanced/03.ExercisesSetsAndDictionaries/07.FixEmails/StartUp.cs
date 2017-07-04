using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.FixEmails
{
    public class StartUp
    {
        public static void Main()
        {
            string name = Console.ReadLine();

            var emailDictionary = new Dictionary<string, string>();

            while (!name.Equals("stop"))
            {
                string email = Console.ReadLine();
                emailDictionary.Add(name, email);
                name = Console.ReadLine();
            }

            var emeilWithUkOrUs = emailDictionary.Where(x => x.Value.EndsWith(".us") || x.Value.EndsWith(".uk")).ToList();

            foreach (var email in emeilWithUkOrUs)
            {
                emailDictionary.Remove(email.Key);
            }

            foreach (var kvp in emailDictionary)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}