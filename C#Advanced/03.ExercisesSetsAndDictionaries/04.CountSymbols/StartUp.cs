using System;
using System.Collections.Generic;

namespace _04.CountSymbols
{
    public class StartUp
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            SortedDictionary<char, int> charactersCount = new SortedDictionary<char, int>();

            foreach (var character in input)
            {
                if (!charactersCount.ContainsKey(character))
                {
                    charactersCount[character] = 0;
                }
                charactersCount[character]++;
            }

            foreach (var character in charactersCount)
            {
                Console.WriteLine($"{character.Key}: {character.Value} time/s");
            }
        }
    }
}