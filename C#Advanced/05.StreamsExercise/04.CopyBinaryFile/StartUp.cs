using System;
using System.IO;

namespace _04.CopyBinaryFile
{
    public class StartUp
    {
        public static void Main()
        {
            Console.Write("Моля въведете пътя до файла, който искате да копирате: ");
            var inputPath = Console.ReadLine();

            var fileName = Path.GetFileNameWithoutExtension(inputPath);
            var fileExtension = Path.GetExtension(inputPath);

            var destinationPath = $"../../ResultDirectory/{fileName}{fileExtension}";

            if (!Directory.Exists("../../ResultDirectory"))
            {
                Directory.CreateDirectory("../../ResultDirectory/");
            }

            using (var source = new FileStream(inputPath, FileMode.Open))
            {
                using (var destination = new FileStream(destinationPath, FileMode.Create))
                {
                    byte[] buffer = new byte[4096];
                    while (true)
                    {
                        int readBytes = source.Read(buffer, 0, buffer.Length);
                        if (readBytes == 0)
                        {
                            break;
                        }

                        destination.Write(buffer, 0, readBytes);
                    }
                }
            }

            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("Файлът се намира в папката \"ResultDirectory\"");
        }
    }
}