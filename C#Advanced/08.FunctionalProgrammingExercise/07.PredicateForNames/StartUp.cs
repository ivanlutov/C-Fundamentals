using System;
using System.Linq;

namespace _07.PredicateForNames
{
    public class StartUp
    {
        public static void Main()
        {
            int lenght = int.Parse(Console.ReadLine());
            var names = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Predicate<string> lenghtPredicate = w => w.Length <= lenght;
            names = names.FindAll(lenghtPredicate);

            Console.WriteLine(string.Join(Environment.NewLine, names));
        }
    }
}