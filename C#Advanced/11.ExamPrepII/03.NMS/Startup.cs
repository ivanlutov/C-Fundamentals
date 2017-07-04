using System;
using System.Text;

namespace _03.NMS
{
    public class Startup
    {
        public static void Main()
        {
            var inputLine = Console.ReadLine();
            var sb = new StringBuilder();

            while (inputLine != "---NMS SEND---")
            {
                sb.Append(inputLine);

                inputLine = Console.ReadLine();
            }
            var delimiter = Console.ReadLine();

            var result = new StringBuilder();
            for (int i = 0; i < sb.Length - 1; i++)
            {
                char currentCharacter = char.ToLower(sb[i]);
                char nextCharacter = char.ToLower(sb[i + 1]);

                result.Append(sb[i]);

                if (currentCharacter > nextCharacter)
                {
                    result.Append(delimiter);
                }
            }
            result.Append(sb[sb.Length - 1]);

            Console.WriteLine(result);
        }
    }
}