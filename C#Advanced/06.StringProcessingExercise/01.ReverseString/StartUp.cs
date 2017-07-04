using System;
using System.Text;

namespace _01.ReverseString
{
    public class StartUp
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            //var array = input.ToCharArray();
            //Array.Reverse(array);
            //var reversed = string.Join("" ,array);
            //var reversed = new string(input.Reverse().ToArray());
            //Console.WriteLine(reversed);

            StringBuilder sb = new StringBuilder();
            for (int i = input.Length - 1; i >= 0; i--)
            {
                sb.Append(input[i]);
            }
            Console.WriteLine(sb);
        }
    }
}