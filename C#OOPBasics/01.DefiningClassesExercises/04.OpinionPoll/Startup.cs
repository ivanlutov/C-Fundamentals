using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.OpinionPoll
{
    public class Startup
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var peoples = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                var peopleTokens = Console.ReadLine().Split();
                var name = peopleTokens[0];
                var age = int.Parse(peopleTokens[1]);
                var person = new Person(name, age);
                peoples.Add(person);
            }

            peoples
                .Where(p => p.Age > 30)
                .OrderBy(p => p.Name)
                .ToList()
                .ForEach(p => Console.WriteLine($"{p.Name} - {p.Age}"));
        }
    }
}