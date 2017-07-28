using System;
using System.Linq;

namespace _02.Collection
{
    public class Startup
    {
        public static void Main()
        {
            var createCmd = Console.ReadLine().Split().ToList();
            var elements = createCmd.Skip(1).ToList();
            ListyIterator<string> listIterator = new ListyIterator<string>(elements);

            var cmd = Console.ReadLine();
            while (cmd != "END")
            {
                switch (cmd)
                {
                    case "HasNext":
                        Console.WriteLine(listIterator.HasNext());
                        break;

                    case "Move":
                        Console.WriteLine(listIterator.Move());
                        break;

                    case "Print":
                        try
                        {
                            Console.WriteLine(listIterator.Print());
                        }
                        catch (InvalidOperationException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;

                    case "PrintAll":
                        try
                        {
                            Console.WriteLine(listIterator.PrintAll());
                        }
                        catch (InvalidOperationException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                }

                cmd = Console.ReadLine();
            }
        }
    }
}