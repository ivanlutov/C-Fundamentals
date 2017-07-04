using System;
using System.Collections.Generic;

namespace _03.PeriodicTable
{
    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            SortedSet<string> chemicalCompoudsSet = new SortedSet<string>();

            for (int i = 0; i < n; i++)
            {
                var chemicalCompounds = Console.ReadLine().Split();

                for (int j = 0; j < chemicalCompounds.Length; j++)
                {
                    chemicalCompoudsSet.Add(chemicalCompounds[j]);
                }
            }

            foreach (var item in chemicalCompoudsSet)
            {
                Console.Write(item + " ");
            }
        }
    }
}