using System;
using System.Linq;

namespace _03.StackIterator
{
    public class Startup
    {
        public static void Main()
        {
            var stack = new Stack<int>();

            var input = Console.ReadLine();
            while (input != "END")
            {
                var tokens = input.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                var cmd = tokens[0];
                tokens.RemoveAt(0);

                switch (cmd)
                {
                    case "Push":
                        foreach (var element in tokens)
                        {
                            stack.Push(int.Parse(element));
                        }
                        break;
                    case "Pop":
                        try
                        {
                            stack.Pop();
                        }
                        catch (InvalidOperationException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                }

                input = Console.ReadLine();
            }

            PrintElements(stack);
            PrintElements(stack);
        }

        private static void PrintElements<T>(Stack<T> stack)
        {
            foreach (var element in stack)
            {
                Console.WriteLine(element);
            }
        }
    }
}