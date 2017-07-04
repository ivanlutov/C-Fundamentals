using System;
using System.Linq;

namespace _03.FormattingNumbers
{
    public class StartUp
    {
        public static void Main()
        {
            var inputNumbers = Console.ReadLine()
                .Split(new char[] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            int a = int.Parse(inputNumbers[0]);
            double b = double.Parse(inputNumbers[1]);
            double c = double.Parse(inputNumbers[2]);

            var aToBinary = Convert.ToString(a, 2);
            var bForPrint = $"{b:F2}";
            var cForPrint = $"{c:F3}";

            if (aToBinary.Length > 10)
            {
                aToBinary = aToBinary.Substring(0, 10);
            }

            Console.WriteLine($"|{a.ToString("X").PadRight(10, ' ')}|{aToBinary.PadLeft(10, '0')}|" +
                $"{bForPrint.PadLeft(10, ' ')}|{cForPrint.PadRight(10, ' ')}|");
        }
    }
}