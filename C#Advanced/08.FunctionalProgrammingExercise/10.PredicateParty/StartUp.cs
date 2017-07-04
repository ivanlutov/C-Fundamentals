using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _10.PredicateParty
{
    public class StartUp
    {
        public static void Main()
        {
            var names = Regex.Split(Console.ReadLine(), "\\s+").ToList();
            var predicates = new Dictionary<string, Func<string, string, bool>>
            {
                { "StartsWith", (name, substring) => name.StartsWith(substring) },
                { "EndsWith", (name, substring) => name.EndsWith(substring) },
                { "Length", (name, length) => name.Length.ToString().Equals(length) }
            };

            string command = Console.ReadLine();
            while (command != "Party!")
            {
                if (names.Count == 0)
                {
                    break;
                }

                var parameters = Regex.Split(command, "\\s+");

                var action = parameters[0];
                var condition = parameters[1];
                var conditionOperator = parameters[2];

                var filteredNames = new List<string>();
                foreach (string name in names)
                {
                    if (predicates[condition](name, conditionOperator))
                    {
                        switch (action)
                        {
                            case "Double":
                                filteredNames.Add(name);
                                filteredNames.Add(name);
                                break;

                            case "Remove":
                                break;
                        }
                    }
                    else
                    {
                        filteredNames.Add(name);
                    }
                }

                names = filteredNames.ToList();

                command = Console.ReadLine();
            }

            if (names.Count != 0)
            {
                Console.WriteLine($"{string.Join(", ", names)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }
    }
}