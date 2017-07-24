using System;
using System.Linq;
using System.Text;

namespace _04.Froggy
{
    public class Startup
    {
        public static void Main()
        {
            var elements = Console.ReadLine()
                .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();
            var lake = new Lake<int>(elements);

            //Console.WriteLine(string.Join(", ", lake));
            var sb = new StringBuilder();
            foreach (var element in lake)
            {
                sb.Append($"{element}, ");
            }
            Console.WriteLine(sb.ToString().TrimEnd(',', ' '));
        }
    }
}