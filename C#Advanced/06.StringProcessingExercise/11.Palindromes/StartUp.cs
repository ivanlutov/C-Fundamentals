using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.Palindromes
{
    public class StartUp
    {
        public static void Main()
        {
            var text = Console.ReadLine();
            var words = text.Split(new char[] { ' ', '.', '?', ',', '!' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            var result = new SortedSet<string>();

            foreach (var word in words)
            {
                bool isPalindrome = true;

                for (int i = 0; i < word.Length / 2; i++)
                {
                    var firstChar = word[i];
                    var lastChar = word[word.Length - i - 1];

                    if (firstChar != lastChar)
                    {
                        isPalindrome = false;
                        break;
                    }
                }

                if (isPalindrome)
                {
                    result.Add(word);
                }
            }

            Console.WriteLine($"[{string.Join(", ", result)}]");
        }
    }
}