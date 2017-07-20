using System;
using System.Linq;

namespace _04.Telephony
{
    public class Startup
    {
        public static void Main()
        {
            var smartphone = new Smartphone();

            var phoneNumbers = Console.ReadLine().Split().ToArray();
            foreach (var phone in phoneNumbers)
            {
                try
                {
                    Console.WriteLine(smartphone.Call(phone));
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            var sites = Console.ReadLine().Split().ToArray();
            foreach (var site in sites)
            {
                try
                {
                    Console.WriteLine(smartphone.Browse(site));
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
        }
    }
}