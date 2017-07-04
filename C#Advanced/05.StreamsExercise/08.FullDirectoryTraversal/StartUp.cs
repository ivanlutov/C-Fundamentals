using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _08.FullDirectoryTraversal
{
    public class StartUp
    {
        private static readonly string[] SizeSuffixes =
            { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };

        private static List<string> files = new List<string>();

        public static void Main()
        {
            var filesDictionary = new Dictionary<string, Dictionary<string, long>>();
            Console.Write("Моля въведете началната директория от която искате да започнете: ");
            var input = Console.ReadLine();

            var fileNames = Directory.GetFiles($"{input}", "*.*", SearchOption.AllDirectories);
            files.AddRange(fileNames);

            foreach (var file in files)
            {
                FileInfo f = new FileInfo(file);
                var extension = Path.GetExtension(file);
                var name = Path.GetFileName(file);
                var size = f.Length;

                if (!filesDictionary.ContainsKey(extension))
                {
                    filesDictionary[extension] = new Dictionary<string, long>();
                }
                if (!filesDictionary[extension].ContainsKey(name))
                {
                    filesDictionary[extension][name] = 0;
                }
                filesDictionary[extension][name] = size;
            }

            var orderedDictionary = filesDictionary.OrderByDescending(x => x.Value.Count()).ThenBy(x => x.Key);

            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            using (StreamWriter fs = new StreamWriter($"{desktopPath}/report.txt"))
            {
                foreach (var extension in orderedDictionary)
                {
                    fs.WriteLine(extension.Key);
                    foreach (var file in extension.Value.OrderBy(x => x.Value).ThenBy(x => x.Key))
                    {
                        var sizeToString = SizeSuffix(file.Value);
                        fs.WriteLine($"--{file.Key} - {sizeToString}");
                    }
                }
            }

            Console.WriteLine("Информацията за файловете се намира на Вашият десктоп във файл \"report\".");
        }

        private static string SizeSuffix(Int64 value)
        {
            if (value < 0) { return "-" + SizeSuffix(-value); }

            int i = 0;
            decimal dValue = (decimal)value;
            while (Math.Round(dValue / 1024) >= 1)
            {
                dValue /= 1024;
                i++;
            }
            return $"{dValue:N} {SizeSuffixes[i]}";
        }
    }
}