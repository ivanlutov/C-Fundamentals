using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.ParkingLot
{
    public class StartUp
    {
        public static void Main()
        {
            var carNumber = Console.ReadLine();
            var cars = new SortedSet<string>();

            while (carNumber != "END")
            {
                var tokens = carNumber.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                var operation = tokens[0];
                var car = tokens[1];
                if (operation == "IN")
                {
                    cars.Add(car);
                }
                else
                {
                    if (cars.Contains(car))
                    {
                        cars.Remove(car);
                    }
                }

                carNumber = Console.ReadLine();
            }

            if (cars.Any())
            {
                foreach (var car in cars)
                {
                    Console.WriteLine(car);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
