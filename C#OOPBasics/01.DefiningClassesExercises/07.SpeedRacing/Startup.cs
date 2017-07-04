using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.SpeedRacing
{
    public class Startup
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split();
                var model = tokens[0];
                var fuelAmount = double.Parse(tokens[1]);
                var consumptionFor1Km = double.Parse(tokens[2]);
                var car = new Car(model, fuelAmount, consumptionFor1Km);
                cars.Add(car);
            }

            string line;
            while ((line = Console.ReadLine()) != "End")
            {
                var tokens = line.Split();
                var model = tokens[1];
                var distance = double.Parse(tokens[2]);
                var currentCar = cars.Where(x => x.Model == model).FirstOrDefault();

                try
                {
                    currentCar.Move(distance);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}