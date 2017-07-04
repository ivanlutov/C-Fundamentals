using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _03.CubicMessages
{
    public class Startup
    {
        public static void Main()
        {
            var sbResult = new StringBuilder();

            var inputMessage = Console.ReadLine();
            while (inputMessage != "Over!")
            {
                var countOfMessage = int.Parse(Console.ReadLine());
                string pattern = $@"^(\d+)([a-zA-Z]{{{countOfMessage}}})([^a-zA-Z]*)$";
                Match match = Regex.Match(inputMessage, pattern);

                if (match.Success)
                {
                    var firstPartAndSecondPart = match.Groups[1].Value + match.Groups[3].Value;
                    var originalMessage = match.Groups[2].Value;
                    var indexesNumbersAsString = string.Empty;
                    var messageResult = string.Empty;

                    foreach (var character in firstPartAndSecondPart)
                    {
                        if (char.IsNumber(character))
                        {
                            indexesNumbersAsString += character;
                        }
                    }

                    foreach (var number in indexesNumbersAsString)
                    {
                        var index = int.Parse(number.ToString());
                        if (index <= originalMessage.Length - 1)
                        {
                            messageResult += originalMessage[index];
                        }
                        else
                        {
                            messageResult += ' ';
                        }
                    }

                    sbResult.AppendLine($"{originalMessage} == {messageResult}");
                }

                inputMessage = Console.ReadLine();
            }

            Console.WriteLine(sbResult.ToString().Trim());
        }
    }
}