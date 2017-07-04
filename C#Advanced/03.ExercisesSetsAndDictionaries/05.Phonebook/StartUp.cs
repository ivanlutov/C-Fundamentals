using System;
using System.Collections.Generic;

namespace _05.Phonebook
{
    public class StartUp
    {
        public static void Main()
        {
            string nameAndNumber = Console.ReadLine();

            var phonebook = new Dictionary<string, string>();

            while (!nameAndNumber.Equals("search"))
            {
                var commandArgs = nameAndNumber.Split('-');

                string contact = commandArgs[0];
                string number = commandArgs[1];
                phonebook[contact] = number;

                nameAndNumber = Console.ReadLine();
            }

            string searchName = Console.ReadLine();
            while (searchName != "stop")
            {
                if (phonebook.ContainsKey(searchName))
                {
                    Console.WriteLine($"{searchName} -> {phonebook[searchName]}");
                }
                else
                {
                    Console.WriteLine($"Contact {searchName} does not exist.");
                }
                searchName = Console.ReadLine();
            }
        }
    }
}