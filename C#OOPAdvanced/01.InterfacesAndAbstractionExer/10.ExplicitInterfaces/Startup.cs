using System;
using System.Collections.Generic;

namespace _10.ExplicitInterfaces
{
    public class Startup
    {
        public static void Main()
        {
            var peoples = new List<Citizen>();

            var input = Console.ReadLine();
            while (input != "End")
            {
                var personTokens = input.Split();
                var name = personTokens[0];
                var country = personTokens[1];
                var age = int.Parse(personTokens[2]);
                var currentPerson = new Citizen(name, country, age);
                peoples.Add(currentPerson);

                input = Console.ReadLine();
            }
        }
    }
}