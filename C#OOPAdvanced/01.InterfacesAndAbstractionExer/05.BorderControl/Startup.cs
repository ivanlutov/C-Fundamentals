using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.BorderControl
{
    public class Startup
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var entities = new List<IIdentifiable>();

            while (input != "End")
            {
                var tokens = input.Split();
                if (tokens.Length > 2)
                {
                    var name = tokens[0];
                    var age = int.Parse(tokens[1]);
                    var id = tokens[2];

                    Citizen citizen = new Citizen(name, age, id);
                    entities.Add(citizen);
                }
                else
                {
                    var model = tokens[0];
                    var id = tokens[1];

                    Robot robot = new Robot(model, id);
                    entities.Add(robot);
                }

                input = Console.ReadLine();
            }

            var fakeIds = Console.ReadLine();

            entities.Where(e => e.Id.EndsWith(fakeIds)).ToList().ForEach(e => Console.WriteLine(e.Id));
        }
    }
}