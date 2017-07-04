using System;
using System.Collections.Generic;
using System.Linq;

namespace _14.LettersChangeNumbers
{
    public class StartUp
    {
        public static void Main()
        {
            var words = Console.ReadLine()
                .Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var alphabetUpper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            var alphabetLower = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            var dictUpper = new Dictionary<char, int>();
            var dictLower = new Dictionary<char, int>();

            for (int i = 0; i < alphabetUpper.Length; i++)
            {
                dictUpper[alphabetUpper[i]] = i + 1;
                dictLower[alphabetLower[i]] = i + 1;
            }

            var totalSum = 0.0;

            foreach (var word in words)
            {
                var firstChar = char.Parse(word.Substring(0, 1));
                var secondChar = char.Parse(word.Substring(word.Length - 1));
                var number = double.Parse(word.Substring(1, word.Length - 2));

                if (char.IsUpper(firstChar))
                {
                    var position = dictUpper[firstChar];
                    number = number / position;
                }
                else
                {
                    var position = dictLower[firstChar];
                    number = number * position;
                }

                if (char.IsUpper(secondChar))
                {
                    number = number - dictUpper[secondChar];
                }
                else
                {
                    number = number + dictLower[secondChar];
                }

                totalSum += number;
            }

            Console.WriteLine($"{totalSum:F2}");
        }
    }
}