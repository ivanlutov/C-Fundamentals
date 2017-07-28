using System;
using System.Text;

namespace _09.TrafficLights
{
    public class Startup
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split();
            var n = int.Parse(Console.ReadLine());
            int count = (int)(Light)Enum.Parse(typeof(Light), input[2]);
            var sb = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (count + 1 == 3)
                    {
                        count = 0;
                    }
                }
            }

            //for (int i = 0; i < n; i++)
            //{
            //    foreach (var value in values)
            //    {
            //        Console.Write(value);
            //    }

            //    Console.WriteLine();
            //}
        }
    }
}
