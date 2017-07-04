using System;
using System.Linq;

namespace _01.ActionPrint
{
    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            Action<string[]> names = w => Console.WriteLine(string.Join(Environment.NewLine, w));
            names(input);
        }
    }
}