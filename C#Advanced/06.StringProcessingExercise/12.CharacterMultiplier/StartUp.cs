using System;

namespace _12.CharacterMultiplier
{
    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var firstWord = input[0];
            var secondWord = input[1];

            var shorterWord = string.Empty;
            var longestWord = string.Empty;
            var sum = 0;

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
                var firstNum = (int)shorterWord[i];

                var secondNum = (int)longestWord[i];

                sum += firstNum * secondNum;
            }

            if (shorterWord.Length != longestWord.Length)
            {
                longestWord = longestWord.Substring(shorterWord.Length);

                for (int i = 0; i < longestWord.Length; i++)
                {
                    sum += (int)longestWord[i];
                }
            }

            Console.WriteLine(sum);
        }
    }
}