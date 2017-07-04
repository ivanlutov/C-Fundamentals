using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _10.GroupByGroup
{
    public class Person
    {
        public Person(string name, int group)
        {
            this.Name = name;
            this.Group = group;
        }

        public string Name { get; set; }
        public int Group { get; set; }
    }

    public class StartUp
    {
        public static void Main()
        {
            var person = Console.ReadLine();
            var persons = new List<Person>();

            while (person != "END")
            {
                var tokens = person.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var name = $"{tokens[0]} {tokens[1]}";
                var group = int.Parse(tokens[2]);
                var currentPerson = new Person(name, group);
                persons.Add(currentPerson);

                person = Console.ReadLine();
            }

            //var groupPersons = from p in persons
            //    group p.Name by p.Group into g
            //    select new { Group = g.Key, Names = g.ToList() };

            //foreach (var printPerson in groupPersons)
            //{
            //    Console.WriteLine($"{printPerson.Group} - {string.Join(", ", printPerson.Names)}");
            //}

            var groupPersons = persons
                .GroupBy(pr => pr.Group)
                .OrderBy(gr => gr.Key);

            foreach (var group in groupPersons)
            {
                Console.Write($"{group.Key} - ");
                var sb = new StringBuilder();
                foreach (var people in group)
                {
                    sb.Append(people.Name).Append(", ");
                }
                sb.Length -= 2;
                Console.WriteLine(sb);
            }
        }
    }
}