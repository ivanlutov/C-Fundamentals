using System;
using System.Numerics;

namespace _04.ConvertFromBase10ToBaseN
{
    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var baseNum = BigInteger.Parse(input[0]);
            var number = BigInteger.Parse(input[1]);

            var result = FromBase10ToAnyBase(number, baseNum);
            Console.WriteLine(result);
        }

        public static BigInteger FromBase10ToAnyBase(BigInteger num, BigInteger baseNum)
        {
            BigInteger result = 0;
            BigInteger factor = 1;

            while (num > 0)
            {
                result += num % baseNum * factor;
                num /= baseNum;
                factor *= 10;
            }

            return result;
        }
    }
}