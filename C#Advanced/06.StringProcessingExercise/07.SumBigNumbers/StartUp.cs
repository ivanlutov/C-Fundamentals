using System;
using System.Collections.Generic;
using System.Text;

namespace _07.SumBigNumbers
{
    public class StartUp
    {
        public static void Main()
        {
            var firstNumber = new Stack<char>(Console.ReadLine());
            var secondNumber = new Stack<char>(Console.ReadLine());
            var result = new StringBuilder();

            var sum = 0;
            while (firstNumber.Count != 0 || secondNumber.Count != 0)
            {
                sum = sum / 10;

                if (firstNumber.Count != 0)
                {
                    sum += (int)char.GetNumericValue(firstNumber.Pop());
                }

                if (secondNumber.Count != 0)
                {
                    sum += (int)char.GetNumericValue(secondNumber.Pop());
                }

                result.Insert(0, sum % 10);
            }

            result.Insert(0, sum / 10);
            var print = result.ToString().TrimStart('0');

            Console.WriteLine(print);
        }
    }
}