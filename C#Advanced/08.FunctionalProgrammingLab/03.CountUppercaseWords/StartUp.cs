using System;
using System.Linq;

namespace _03.CountUppercaseWords
{
    public class StartUp
    {
        public static void Main()
        {
            Console.WriteLine(string.Join(Environment.NewLine,Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Where(w => char.IsUpper(w[0]))));
        }
    }
}
