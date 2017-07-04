using System;

namespace _08.RecursiveFibonacci
{
    public class StartUp
    {
        private static long[] numbers;

        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            numbers = new long[n];
            var result = GetFibonacci(n);
            Console.WriteLine(result);
        }

        private static long GetFibonacci(int n)
        {
            if (n <= 2)
            {
                return 1;
            }

            if (numbers[n - 1] != 0)
            {
                return numbers[n - 1];
            }
            return numbers[n - 1] = GetFibonacci(n - 1) + GetFibonacci(n - 2);
        }
    }
}