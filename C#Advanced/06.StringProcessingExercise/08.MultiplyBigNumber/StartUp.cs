using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _08.MultiplyBigNumber
{
    public class StartUp
    {
        public static void Main()
        {
            var firstNumber = new Stack<char>(Console.ReadLine());
            var secondNumber = int.Parse(Console.ReadLine());
            var result = new StringBuilder();

            if (firstNumber.Sum(s => (int)char.GetNumericValue(s)) == 0 || secondNumber == 0)
            {
                Console.WriteLine("0");
                return;
            }

            var multiply = 0;

            while (firstNumber.Count != 0)
            {
                var reminder = multiply / 10;
                var popped = (int)char.GetNumericValue(firstNumber.Pop());

                multiply = popped * secondNumber;

                if (reminder > 0)
                {
                    multiply = multiply + reminder;
                }

                result.Insert(0, multiply % 10);
            }

            result.Insert(0, multiply / 10);
            var print = result.ToString().TrimStart('0');

            Console.WriteLine(print);
        }
    }
}