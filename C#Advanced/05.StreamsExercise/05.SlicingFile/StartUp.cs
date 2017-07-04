using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _05.SlicingFile
{
    public class StartUp
    {
        private const string destinationPathForParts = "../../DestinationDirectory/Parts/";
        private const string destinationPathForAssemble = "../../DestinationDirectory/Assemble/";
        private const string inputPathForAssemble = "../../DestinationDirectory/Parts/";

        public static void Main()
        {
            Console.Write("Моля въведете пътя до файла, който искате да разделите: ");
            var sourceFile = Console.ReadLine();

            Console.Write("Моля въведете на колко части искате да разделите файла: ");
            int parts = int.Parse(Console.ReadLine());

            var fileName = Path.GetFileNameWithoutExtension(sourceFile);
            var fileExtension = Path.GetExtension(sourceFile);

            if (!Directory.Exists("../../DestinationDirectory/Parts/"))
            {
                Directory.CreateDirectory("../../DestinationDirectory/Parts");
            }

            if (!Directory.Exists("../../DestinationDirectory/Assemble/"))
            {
                Directory.CreateDirectory("../../DestinationDirectory/Assemble");
            }

            Slice(sourceFile, destinationPathForParts, parts, fileExtension, fileName);
            Console.WriteLine("Разделените файлове се намират в папката\"DestinationDirectory/Parts\"");

            var files = Directory.GetFiles("../../DestinationDirectory/Parts").Where(f => f.EndsWith(fileExtension))
                .ToList();

            Assemble(files, destinationPathForAssemble, inputPathForAssemble, fileExtension);
            Console.WriteLine("Съединения файл се намира в папката\"DestinationDirectory/Assemble\"");
        }

        private static void Slice(string sourceFile, string destinationPath, int parts, string fileExtension, string fileName)
        {
            using (Stream input = File.OpenRead(sourceFile))
            {
                int index = 0;
                while (input.Position < input.Length)
                {
                    using (Stream output = File.Create($"{destinationPath}/Part {index} - {fileName}{fileExtension}"))
                    {
                        int chunkBytesRead = 0;
                        while (chunkBytesRead < input.Length / parts)
                        {
                            byte[] buffer = new byte[4096];
                            int bytesRead = input.Read(buffer, 0, buffer.Length);

                            if (bytesRead == 0)
                            {
                                break;
                            }

                            chunkBytesRead += bytesRead;
                            output.Write(buffer, 0, bytesRead);
                        }
                    }
                    index++;
                }
            }
        }

        private static void Assemble(List<string> files, string destinationPath, string inputPathForAssemble, string fileExtension)
        {
            foreach (var file in files)
            {
                using (FileStream partOfFile = new FileStream($"{inputPathForAssemble}/{file}", FileMode.Open))
                {
                    using (FileStream assembledFile = new FileStream($"{destinationPath}/assembled{fileExtension}", FileMode.Append))
                    {
                        var buffer = new byte[4096];
                        int bytesRead;
                        while ((bytesRead = partOfFile.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            assembledFile.Write(buffer, 0, bytesRead);
                        }
                    }
                }
            }
        }
    }
}