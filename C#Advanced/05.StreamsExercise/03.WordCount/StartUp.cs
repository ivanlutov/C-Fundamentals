using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _03.WordCount
{
    public class StartUp
    {
        private const string outputFile = "../../result.txt";

        public static void Main()
        {
            Console.Write("Моля въведете пътя до файла с текста: ");
            var inputPathText = Console.ReadLine();

            Console.Write("Моля въведете пътя до файла с думите: ");
            var inputPathWords = Console.ReadLine();

            var wordsCount = new Dictionary<string, int>();
            var words = new List<string>();
            var textToString = new StringBuilder();

            using (StreamReader readerWords = new StreamReader(inputPathWords))
            {
                string lineWord = readerWords.ReadLine();
                while (lineWord != null)
                {
                    words.Add(lineWord);
                    lineWord = readerWords.ReadLine();
                }
            }

            using (StreamReader readerText = new StreamReader(inputPathText))
            {
                string lineText = readerText.ReadLine();
                while (lineText != null)
                {
                    textToString.AppendLine(lineText.ToLower());
                    lineText = readerText.ReadLine();
                }
            }

            foreach (var word in words)
            {
                var count = Regex.Matches(textToString.ToString(), $"[^a-zA-Z]{word}[^a-zA-Z]").Count;

                if (!wordsCount.ContainsKey(word))
                {
                    wordsCount[word] = 0;
                }

                wordsCount[word] = count;
            }

            var orderedWords = wordsCount.OrderByDescending(w => w.Value).ToDictionary(x => x.Key, y => y.Value);

            using (StreamWriter writer = new StreamWriter(outputFile))
            {
                foreach (var word in orderedWords)
                {
                    writer.WriteLine($"{word.Key} - {word.Value}");
                }
            }
        }
    }
}