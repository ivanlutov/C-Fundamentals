using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.SoftUniParty
{
    public class StartUp
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            var regular = new SortedSet<string>();
            var vip = new SortedSet<string>();

            while (input != "PARTY")
            {
                var firstDigit = input.Substring(0,1);
                int number;
                if (int.TryParse(firstDigit, out number))
                {
                    vip.Add(input);
                }
                else
                {
                    regular.Add(input);
                }
                input = Console.ReadLine();
            }

            string gostCome = Console.ReadLine();
            while (gostCome != "END")
            {
                var firstDigit = gostCome.Substring(0, 1);
                int number;
                if (int.TryParse(firstDigit, out number))
                {
                    if (vip.Contains(gostCome))
                    {
                        vip.Remove(gostCome);
                    }
                }
                else
                {
                    if (regular.Contains(gostCome))
                    {
                        regular.Remove(gostCome);
                    }
                }
                gostCome = Console.ReadLine();
            }

            Console.WriteLine(vip.Count+regular.Count);
            foreach (var gost in vip)
            {
                Console.WriteLine(gost);
            }
            foreach (var gost in regular)
            {
                Console.WriteLine(gost);
            }
        }
    }
}
