using System;
using System.Collections.Generic;

namespace _07.BalancedParenthesis
{
    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            Stack<string> stack = new Stack<string>();
            var isValid = true;

            for (int i = 0; i < input.Length; i++)
            {
                var currentSymbol = input[i].ToString();
                if (currentSymbol == "{")
                {
                    stack.Push(input[i].ToString());
                }
                else if (currentSymbol == "[")
                {
                    stack.Push(input[i].ToString());
                }
                else if (currentSymbol == "(")
                {
                    stack.Push(input[i].ToString());
                }
                else if (currentSymbol == "}")
                {
                    if (stack.Count > 0)
                    {
                        var popped = stack.Pop();
                        if (popped != "{")
                        {
                            isValid = false;
                            break;
                        }
                    }
                    else
                    {
                        isValid = false;
                        break;
                    }
                }
                else if (currentSymbol == "]")
                {
                    if (stack.Count > 0)
                    {
                        var popped = stack.Pop();
                        if (popped != "[")
                        {
                            isValid = false;
                            break;
                        }
                    }
                    else
                    {
                        isValid = false;
                        break;
                    }
                }
                else if (currentSymbol == ")")
                {
                    if (stack.Count > 0)
                    {
                        var popped = stack.Pop();
                        if (popped != "(")
                        {
                            isValid = false;
                            break;
                        }
                    }
                    else
                    {
                        isValid = false;
                        break;
                    }
                }
            }

            if (isValid)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}