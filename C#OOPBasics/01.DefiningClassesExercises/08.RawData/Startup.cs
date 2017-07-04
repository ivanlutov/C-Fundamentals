using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.RawData
{
    public class Startup
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split();
                var model = tokens[0];
                var engineSpeed = int.Parse(tokens[1]);
                var enginePower = int.Parse(tokens[2]);
                var cargoWeight = int.Parse(tokens[3]);
                var cargoType = tokens[4];
                var tire1Pressure = double.Parse(tokens[5]);
                var tire1Age = int.Parse(tokens[6]);
                var tire2Pressure = double.Parse(tokens[7]);
                var tire2Age = int.Parse(tokens[8]);
                var tire3Pressure = double.Parse(tokens[9]);
                var tire3Age = int.Parse(tokens[10]);
                var tire4Pressure = double.Parse(tokens[11]);
                var tire4Age = int.Parse(tokens[12]);

                var car = new Car(model)
                {
                    Cargo = new Cargo(cargoWeight, cargoType),
                    Engine = new Engine(engineSpeed, enginePower),
                    Tires = new List<Tire>()
                    {
                        new Tire(tire1Pressure,tire1Age),
                        new Tire(tire2Pressure,tire2Age),
                        new Tire(tire3Pressure,tire3Age),
                        new Tire(tire4Pressure,tire4Age)
                    }
                };

                cars.Add(car);
            }

            string cargoTypeCmd = Console.ReadLine();
            if (cargoTypeCmd == "fragile")
            {
                cars
                   .Where(c => c.Cargo.Type == "fragile" && c.Tires.Any(t => t.Pressure < 1))
                   .ToList()
                   .ForEach(c => Console.WriteLine(c.Model));
            }
            else if (cargoTypeCmd == "flamable")
            {
                cars
                    .Where(c => c.Cargo.Type == "flamable" && c.Engine.Power > 250)
                    .ToList()
                    .ForEach(c => Console.WriteLine(c.Model));
            }
        }
    }
}