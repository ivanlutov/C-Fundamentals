using System;

namespace _01.Vehicles
{
    public class Startup
    {
        public static void Main()
        {
            var carTokens = Console.ReadLine().Split();
            Vehicle car = new Car(double.Parse(carTokens[1]), double.Parse(carTokens[2]));

            var truckTokens = Console.ReadLine().Split();
            Vehicle truck = new Truck(double.Parse(truckTokens[1]), double.Parse(truckTokens[2]));

            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int index = 0; index < numberOfCommands; index++)
            {
                var tokens = Console.ReadLine().Split();
                var command = tokens[0];
                var vehicleCommand = tokens[1];

                Vehicle vehicle;
                if (vehicleCommand == "Car")
                {
                    vehicle = car;
                }
                else
                {
                    vehicle = truck;
                }

                switch (command)
                {
                    case "Drive":
                        try
                        {
                            var distance = double.Parse(tokens[2]);
                            vehicle.Drive(distance);
                            Console.WriteLine($"{vehicle.GetType().Name} travelled {distance} km");
                        }
                        catch (InvalidOperationException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;

                    case "Refuel":
                        vehicle.Refuel(double.Parse(tokens[2]));
                        break;
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
        }
    }
}