using System;
using System.Collections.Generic;

namespace _13.MagicExchangeableWords
{
    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(new char[] { ' ', '\n', '\t', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            var firstWord = input[0];
            var secondWord = input[1];

            var charDictionary = new Dictionary<char, char>();
            var shorterWord = string.Empty;
            var longestWord = string.Empty;

            if (firstWord.Length > secondWord.Length)
            {
                shorterWord = secondWord;
                longestWord = firstWord;
            }
            else
            {
                shorterWord = firstWord;
                longestWord = secondWord;
            }

            for (int i = 0; i < shorterWord.Length; i++)
            {
                var firstChar = shorterWord[i];
                var secondChar = longestWord[i];

                if (charDictionary.ContainsKey(firstChar))
                {
                    if (secondChar != charDictionary[firstChar])
                    {
                        Console.WriteLine("false");
                        return;
                    }
                }

                if (!charDictionary.ContainsKey(firstChar))
                {
                    if (charDictionary.ContainsValue(secondChar))
                    {
                        Console.WriteLine("false");
                        return;
                    }

                    charDictionary[firstChar] = secondChar;
                }
            }

            if (shorterWord.Length != longestWord.Length)
            {
                longestWord = longestWord.Substring(shorterWord.Length);

                for (int i = 0; i < longestWord.Length; i++)
                {
                    if (!charDictionary.ContainsValue(longestWord[i]))
                    {
                        Console.WriteLine("false");
                        return;
                    }
                }
            }

            Console.WriteLine("true");
        }
    }
}