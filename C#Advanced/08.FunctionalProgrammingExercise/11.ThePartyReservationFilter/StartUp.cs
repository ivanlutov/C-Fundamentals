using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.ThePartyReservationFilter
{
    public class StartUp
    {
        public static void Main()
        {
            var names = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var predicates = new Dictionary<string, Func<string, string, bool>>
            {
                { "Starts with", (name, substring) => name.StartsWith(substring) },
                { "Ends with", (name, substring) => name.EndsWith(substring) },
                { "Length", (name, length) => name.Length.ToString().Equals(length) },
                { "Contains", (name, substring)  => name.Contains(substring) }
            };

            string command = Console.ReadLine();
            var commands = new List<string>();

            while (command != "Print")
            {
                var indexOfFirstDot = command.IndexOf(';');
                var firstPart = command.Substring(0, indexOfFirstDot);
                var secondPart = command.Substring(indexOfFirstDot + 1);

                if (firstPart == "Add filter")
                {
                    commands.Add(secondPart);
                }
                else
                {
                    if (commands.Contains(secondPart))
                    {
                        commands.Remove(secondPart);
                    }
                }

                command = Console.ReadLine();
            }

            for (int i = 0; i < commands.Count; i++)
            {
                var currentCommand = commands[i];

                if (names.Count == 0)
                {
                    break;
                }

                var tokens = currentCommand.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                var operation = tokens[0];
                var substring = tokens[1];

                var filteredNames = new List<string>();

                foreach (string name in names)
                {
                    if (!predicates[operation](name, substring))
                    {
                        filteredNames.Add(name);
                    }
                }

                names = filteredNames.ToList();
            }

            Console.WriteLine($"{string.Join(" ", names)}");
        }
    }
}