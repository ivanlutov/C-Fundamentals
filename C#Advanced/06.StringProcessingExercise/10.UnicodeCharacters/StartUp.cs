using System;
using System.Text;

namespace _10.UnicodeCharacters
{
    public class StartUp
    {
        public static void Main()
        {
            var word = Console.ReadLine();

            var sb = new StringBuilder();

            foreach (var character in word)
            {
                var unicode = GetEscapeSequence(character);
                sb.Append(unicode);
            }

            Console.WriteLine(sb);
        }

        private static string GetEscapeSequence(char c)
        {
            return "\\u" + ((int)c).ToString("X4").ToLower();
        }
    }
}