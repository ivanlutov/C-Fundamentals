using System;
using System.Text;

namespace _05.ConcatenateStrings
{
    public class StartUp
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            var sb = new StringBuilder();

            for (int i = 0; i < number; i++)
            {
                string word = Console.ReadLine();
                sb.Append(word);
                sb.Append(" ");
            }

            Console.WriteLine(sb);
        }
    }
}