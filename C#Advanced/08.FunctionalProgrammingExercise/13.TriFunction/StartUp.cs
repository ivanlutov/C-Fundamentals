using System;
using System.Linq;

namespace _13.TriFunction
{
    public class StartUp
    {
        public static void Main()
        {
            var number = int.Parse(Console.ReadLine());

            var names = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions
                .RemoveEmptyEntries).ToList();

            Func<string, int, bool> result = Result;

            foreach (var name in names)
            {
                if (result(name, number))
                {
                    Console.WriteLine(name);
                    break;
                }
            }
        }

        private static bool Result(string name, int number)
        {
            var count = 0;

            foreach (var character in name)
            {
                count += (int)character;
            }

            if (count >= number)
            {
                return true;
            }

            return false;
        }
    }
}