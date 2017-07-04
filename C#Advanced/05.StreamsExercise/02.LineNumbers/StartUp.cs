using System;
using System.IO;

namespace _02.LineNumbers
{
    public class StartUp
    {
        private const string outputFile = "../../result.txt";

        public static void Main()
        {
            Console.Write("Моля въведете път до файла, който искате да прочетете: ");
            var inputPath = Console.ReadLine();

            var lineCounter = 1;
            using (StreamReader reader = new StreamReader(inputPath))
            {
                using (StreamWriter writer = new StreamWriter(outputFile))
                {
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        writer.WriteLine($"{lineCounter} {line}");
                        lineCounter++;
                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}