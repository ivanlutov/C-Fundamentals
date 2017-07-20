using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.BirthdayCelebrations
{
    public class Startup
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var entities = new List<IBirthtable>();

            while (input != "End")
            {
                var tokens = input.Split();
                var type = tokens[0];
                if (type == "Citizen")
                {
                    var name = tokens[1];
                    var age = int.Parse(tokens[2]);
                    var id = tokens[3];
                    var birthdate = tokens[4];

                    Citizen citizen = new Citizen(name, age, id, birthdate);
                    entities.Add(citizen);
                }
                else if (type == "Pet")
                {
                    var name = tokens[1];
                    var birthdate = tokens[2];

                    Pet pet = new Pet(name, birthdate);
                    entities.Add(pet);
                }

                input = Console.ReadLine();
            }

            var year = Console.ReadLine();

            entities.Where(e => e.Birthdate.EndsWith(year)).ToList().ForEach(e => Console.WriteLine(e.Birthdate));
        }
    }
}