using System;

namespace _03.ParseTags
{
    public class StartUp
    {
        public static void Main()
        {
            var text = Console.ReadLine();

            var openTag = "<upcase>";
            var closeTag = "</upcase>";

            int startIndex = text.IndexOf(openTag);

            while (startIndex != -1)
            {
                int endIndex = text.IndexOf(closeTag);
                if (endIndex == -1)
                {
                    break;
                }

                var part = text.Substring(startIndex, endIndex + closeTag.Length - startIndex);
                var replaced = part.Remove(0, openTag.Length);
                replaced = replaced.Remove(replaced.Length - closeTag.Length).ToUpper();

                text = text.Replace(part, replaced);

                startIndex = text.IndexOf("<upcase>");
                endIndex = text.IndexOf("</upcase>");
            }

            Console.WriteLine(text);
        }
    }
}