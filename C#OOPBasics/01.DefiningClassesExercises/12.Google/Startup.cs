using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.Google
{
    public class Startup
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var peoples = new List<Person>();
            Person person = null;

            while (input != "End")
            {
                var tokens = input.Split();
                var name = tokens[0];
                var cmd = tokens[1];
                bool isConstains = false;

                foreach (var people in peoples)
                {
                    if (people.Name == name)
                    {
                        isConstains = true;
                        break;
                    }
                }

                if (isConstains)
                {
                    person = peoples.First(p => p.Name == name);
                }
                else
                {
                    person = new Person(name);
                }

                if (cmd == "company")
                {
                    var companyName = tokens[2];
                    var departament = tokens[3];
                    var salary = double.Parse(tokens[4]);
                    person.Company = new Company(companyName, departament, salary);
                }
                else if (cmd == "pokemon")
                {
                    var pokemonName = tokens[2];
                    var type = tokens[3];
                    person.Pokemons.Add(new Pokemon(pokemonName, type));
                }
                else if (cmd == "parents")
                {
                    var parentName = tokens[2];
                    var birthday = tokens[3];
                    person.Parents.Add(new Parent(parentName, birthday));
                }
                else if (cmd == "children")
                {
                    var childName = tokens[2];
                    var birthday = tokens[3];
                    person.Children.Add(new Child(childName, birthday));
                }
                else if (cmd == "car")
                {
                    var model = tokens[2];
                    var speed = int.Parse(tokens[3]);
                    person.Car = new Car(model, speed);
                }
                peoples.Add(person);
                input = Console.ReadLine();
            }

            var inputPerson = Console.ReadLine();
            var personForPrint = peoples.First(p => p.Name == inputPerson);

            Console.WriteLine(personForPrint);
        }
    }
}