using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.FilterByAge
{
    public class StartUp
    {
        public static void Main()
        {
            var numberOfPeople = int.Parse(Console.ReadLine());
            var people = new Dictionary<string, int>();

            for (int i = 0; i < numberOfPeople; i++)
            {
                var personTokens = Console.ReadLine()
                    .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                people.Add(personTokens[0], int.Parse(personTokens[1]));
            }

            var condition = Console.ReadLine();
            var age = int.Parse(Console.ReadLine());
            var format = Console.ReadLine();

            Func<KeyValuePair<string, int>, bool> tester = CreateTester(condition, age);

            Action<KeyValuePair<string, int>> printer = CreatePrinter(format);

            Print(people, tester, printer);

        }

        private static void Print(Dictionary<string, int> people
            , Func<KeyValuePair<string, int>, bool> tester
            , Action<KeyValuePair<string, int>> printer)
        {
            foreach (var keyValuePair in people)
            {
                if (tester(keyValuePair))
                {
                    printer(keyValuePair);
                }
            }
        }

        private static Action<KeyValuePair<string, int>> CreatePrinter(string format)
        {
            switch (format)
            {
                case "name age":
                    return n => Console.WriteLine($"{n.Key} - {n.Value}");
                case "name":
                    return n => Console.WriteLine($"{n.Key}");
                case "age":
                    return n => Console.WriteLine($"{n.Value}");
                default:
                    return null;
            }
        }

        public static Func<KeyValuePair<string, int>, bool> CreateTester(string condition, int age)
        {
            if (condition == "older")
            {
                Func<KeyValuePair<string, int>, bool> f = n => n.Value >= age;
                return f;
            }
            else
            {
                Func<KeyValuePair<string, int>, bool> f = n => n.Value < age;
                return f;
            }
        }
    }
}
