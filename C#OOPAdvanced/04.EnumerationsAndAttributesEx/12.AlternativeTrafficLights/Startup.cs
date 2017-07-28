using System;
using System.Collections.Generic;

namespace _12.AlternativeTrafficLights
{
    public class Startup
    {
        public static void Main()
        {
            var lightTokens = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var n = int.Parse(Console.ReadLine());
            List<Light> lights = new List<Light>();

            foreach (var light in lightTokens)
            {
                lights.Add((Light)Enum.Parse(typeof(Light), light));
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < lights.Count; j++)
                {
                    var currentLight = lights[j];

                    if ((int)currentLight + 1 > 2)
                    {
                        currentLight = 0;
                    }
                    else
                    {
                        currentLight += 1;
                    }

                    lights[j] = currentLight;
                }

                Console.WriteLine(string.Join(" ", lights));
            }
        }
    }
}