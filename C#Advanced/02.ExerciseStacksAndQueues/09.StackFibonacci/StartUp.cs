using System;
using System.Collections.Generic;

namespace _09.StackFibonacci
{
    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Stack<ulong> fibonacci = new Stack<ulong>();
            fibonacci.Push(0);
            fibonacci.Push(1);

            for (int i = 1; i < n; i++)
            {
                ulong firstNum = fibonacci.Pop();
                ulong secondNum = fibonacci.Pop();

                fibonacci.Push(firstNum);
                fibonacci.Push(firstNum + secondNum);
            }

            Console.WriteLine(fibonacci.Peek());
        }
    }
}