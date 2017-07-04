using System;

namespace _02.ParseURLs
{
    public class StartUp
    {
        public static void Main()
        {
            var url = Console.ReadLine();

            var urlTokens = url.Split(new[] { "://" }, StringSplitOptions.RemoveEmptyEntries);

            if (urlTokens.Length != 2 || urlTokens[1].IndexOf('/') == -1)
            {
                Console.WriteLine("Invalid URL");
                return;
            }
            else
            {
                var protocol = urlTokens[0];
                var indexOfSlash = urlTokens[1].IndexOf('/');
                var server = urlTokens[1].Substring(0, indexOfSlash);
                var resources = urlTokens[1].Substring(indexOfSlash + 1);

                Console.WriteLine($"Protocol = {protocol}");
                Console.WriteLine($"Server = {server}");
                Console.WriteLine($"Resources = {resources}");
            }
        }
    }
}