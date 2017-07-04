using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace _06.ZippingSlicedFiles
{
    public class StartUp
    {
        private const string destinationPathForParts = "../../DestinationDirectory/Parts/";
        private const string destinationPathForAssemble = "../../DestinationDirectory/Assemble/";
        private const string inputPathForAssemble = "../../DestinationDirectory/Parts/";

        public static void Main()
        {
            Console.Write("Моля въведете пътя до файла, който искате да разделите и компресирате: ");
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

            SliceAndCompressing(sourceFile, destinationPathForParts, parts, fileExtension, fileName);
            Console.WriteLine("Разделените файлове се намират в папката\"DestinationDirectory/Parts\"");

            var files = Directory.GetFiles("../../DestinationDirectory/Parts").Where(f => f.EndsWith(".gz"))
                .ToList();

            DecompressedAndAssemble(files, destinationPathForAssemble, inputPathForAssemble, fileExtension);
            Console.WriteLine("Съединения файл се намира в папката\"DestinationDirectory/Assemble\"");
        }

        private static void SliceAndCompressing(string sourceFile, string destinationPath, int parts, string fileExtension, string fileName)
        {
            using (FileStream input = new FileStream(sourceFile, FileMode.Open))
            {
                int index = 0;
                while (input.Position < input.Length)
                {
                    using (FileStream output = new FileStream($"{destinationPath}/Part {index} {fileName}.gz", FileMode.Create))
                    {
                        using (GZipStream gZip = new GZipStream(output, CompressionMode.Compress, false))
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
                                gZip.Write(buffer, 0, bytesRead);
                            }
                        }
                    }
                    index++;
                }
            }
        }

        private static void DecompressedAndAssemble(List<string> files, string destinationPath, string inputPathForAssemble, string fileExtension)
        {
            foreach (var file in files)
            {
                using (FileStream partOfFile = new FileStream($"{inputPathForAssemble}{file}", FileMode.Open))
                {
                    using (GZipStream gZip = new GZipStream(partOfFile, CompressionMode.Decompress))
                    {
                        using (FileStream assembledFile = new FileStream($"{destinationPath}uncompressed{fileExtension}", FileMode.Append))
                        {
                            var buffer = new byte[4096];
                            int bytesRead = gZip.Read(buffer, 0, buffer.Length);
                            while (bytesRead > 0)
                            {
                                assembledFile.Write(buffer, 0, bytesRead);
                                bytesRead = gZip.Read(buffer, 0, buffer.Length);
                            }
                        }
                    }
                }
            }
        }
    }
}