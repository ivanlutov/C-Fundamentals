using System;

namespace _09.TextFilter
{
    public class StartUp
    {
        public static void Main()
        {
            var bannedWords = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var text = Console.ReadLine();

            foreach (var word in bannedWords)
            {
                var replaceWord = new string('*', word.Length);
                text = text.Replace(word, replaceWord);
            }

            Console.WriteLine(text);
        }
    }
}