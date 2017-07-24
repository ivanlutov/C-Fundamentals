using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.ComparingObjects
{
    public class Startup
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var peoples = new List<Person>();

            while (input != "END")
            {
                var tokens = input.Split();
                var name = tokens[0];
                var age = int.Parse(tokens[1]);
                var town = tokens[2];
                var person = new Person(name, age, town);
                peoples.Add(person);

                input = Console.ReadLine();
            }

            var index = int.Parse(Console.ReadLine());
            var comparePeople = peoples[index - 1];

            var numberOfEqualPeople = peoples.Count(people => people.CompareTo(comparePeople) == 0);
            var numberOfNotEqualPeople = peoples.Count - numberOfEqualPeople;

            Console.WriteLine(numberOfEqualPeople < 2
                ? "No matches"
                : $"{numberOfEqualPeople} {numberOfNotEqualPeople} {peoples.Count}");
        }
    }
}