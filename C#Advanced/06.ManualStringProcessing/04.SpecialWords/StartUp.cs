using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.SpecialWords
{
    public class StartUp
    {
        public static void Main()
        {
            var specialWords = Console.ReadLine()
                .Split(new char[] { ' ', '(', ')', '[', ']', '<', '>', ',', '-', '!', '?' },
                    StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

            var textWords = Console.ReadLine()
                .Split(new char[] { ' ', '(', ')', '[', ']', '<', '>', ',', '-', '!', '?' },
                    StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var wordsCount = new Dictionary<string, int>();

            foreach (var word in specialWords)
            {
                if (!wordsCount.ContainsKey(word))
                {
                    wordsCount[word] = 0;
                }
            }

            foreach (var currentSpecial in specialWords)
            {
                foreach (var currentText in textWords)
                {
                    if (currentSpecial == currentText)
                    {
                        wordsCount[currentSpecial]++;
                    }
                }
            }

            foreach (var countOfWords in wordsCount)
            {
                Console.WriteLine($"{countOfWords.Key} - {countOfWords.Value}");
            }
        }
    }
}