using System;
using System.Collections.Generic;
using System.Text;

namespace _10.SimpleTextEditor
{
    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            StringBuilder text = new StringBuilder();
            Stack<string> stack = new Stack<string>();

            for (int i = 0; i < n; i++)
            {
                var operation = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                switch (operation[0])
                {
                    case "1":
                        stack.Push(text.ToString());
                        text.Append(operation[1]);
                        break;

                    case "2":
                        stack.Push(text.ToString());
                        var count = int.Parse(operation[1]);
                        text = text.Remove(text.Length - count, count);
                        break;

                    case "3":
                        var index = int.Parse(operation[1]);
                        Console.WriteLine(text[index - 1]);
                        break;

                    case "4":
                        var textToUndo = stack.Pop();
                        text.Clear();
                        text.Append(textToUndo);
                        break;
                }
            }
        }
    }
}