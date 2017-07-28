using System;
using System.Linq;

namespace _01.ListyIterator
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
                }

                cmd = Console.ReadLine();
            }
        }
    }
}