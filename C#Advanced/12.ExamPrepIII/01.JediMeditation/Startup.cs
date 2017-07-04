using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.JediMeditation
{
    public class Startup
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Queue<string> masterJedi = new Queue<string>();
            Queue<string> knightJedi = new Queue<string>();
            Queue<string> padawanJedi = new Queue<string>();
            Queue<string> otherJedi = new Queue<string>();
            bool yodaExisting = false;

            for (int i = 0; i < n; i++)
            {
                string inputLine = Console.ReadLine();
                var jedi = inputLine.Split().ToArray();

                for (int j = 0; j < jedi.Length; j++)
                {
                    var currentJedi = jedi[j][0];

                    if (currentJedi == 'm')
                    {
                        masterJedi.Enqueue(jedi[j]);
                    }
                    else if (currentJedi == 'k')
                    {
                        knightJedi.Enqueue(jedi[j]);
                    }
                    else if (currentJedi == 'p')
                    {
                        padawanJedi.Enqueue(jedi[j]);
                    }
                    else if (currentJedi == 't' || currentJedi == 's')
                    {
                        otherJedi.Enqueue(jedi[j]);
                    }
                    else if (currentJedi == 'y')
                    {
                        yodaExisting = true;
                    }
                }
            }

            if (yodaExisting)
            {
                if (masterJedi.Any())
                {
                    Console.Write(string.Join(" ", masterJedi) + " ");
                }
                if (knightJedi.Any())
                {
                    Console.Write(string.Join(" ", knightJedi) + " ");
                }
                if (otherJedi.Any())
                {
                    Console.Write(string.Join(" ", otherJedi) + " ");
                }
                if (padawanJedi.Any())
                {
                    Console.WriteLine(string.Join(" ", padawanJedi) + " ");
                }
            }
            else
            {
                if (otherJedi.Any())
                {
                    Console.Write(string.Join(" ", otherJedi) + " ");
                }
                if (masterJedi.Any())
                {
                    Console.Write(string.Join(" ", masterJedi) + " ");
                }
                if (knightJedi.Any())
                {
                    Console.Write(string.Join(" ", knightJedi) + " ");
                }
                if (padawanJedi.Any())
                {
                    Console.WriteLine(string.Join(" ", padawanJedi) + " ");
                }
            }
        }
    }
}