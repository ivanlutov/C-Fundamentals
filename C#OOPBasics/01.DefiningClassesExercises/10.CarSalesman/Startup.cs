using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.CarSalesman
{
    public class Startup
    {
        public static void Main()
        {
            var coutnOfEngines = int.Parse(Console.ReadLine());
            var engines = new List<Engine>();
            for (int i = 0; i < coutnOfEngines; i++)
            {
                var tokensEngine = Console.ReadLine().Trim().Split();
                var model = tokensEngine[0];
                var power = double.Parse(tokensEngine[1]);
                var engine = new Engine(model, power);
                int displacementToInt;
                var efficiency = string.Empty;
                var displacement = string.Empty;
                if (tokensEngine.Length == 4)
                {
                    displacement = tokensEngine[2];
                    efficiency = tokensEngine[3];
                    engine.Displacement = displacement;
                    engine.Efficiency = efficiency;
                }
                else if (tokensEngine.Length == 3 && Int32.TryParse(tokensEngine[2], out displacementToInt))
                {
                    engine.Displacement = tokensEngine[2];
                }
                else if (tokensEngine.Length == 3)
                {
                    efficiency = tokensEngine[2];
                    engine.Efficiency = efficiency;
                }

                engines.Add(engine);
            }

            var countOfCars = int.Parse(Console.ReadLine());
            var cars = new List<Car>();

            for (int i = 0; i < countOfCars; i++)
            {
                var carTokens = Console.ReadLine().Trim().Split();
                var model = carTokens[0];
                var engineName = carTokens[1];
                var currentEngine = engines.FirstOrDefault(x => x.Model == engineName);
                var car = new Car(model, currentEngine);
                int weightToInt;
                var weight = string.Empty;
                var color = string.Empty;

                if (carTokens.Length == 4)
                {
                    weight = carTokens[2];
                    color = carTokens[3];
                    car.Weight = weight;
                    car.Color = color;
                }
                else if (carTokens.Length == 3 && Int32.TryParse(carTokens[2], out weightToInt))
                {
                    weight = carTokens[2];
                    car.Weight = weight;
                }
                else if (carTokens.Length == 3)
                {
                    color = carTokens[2];
                    car.Color = color;
                }

                cars.Add(car);
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model}:");
                Console.WriteLine($"  {car.Engine.Model}:");
                Console.WriteLine($"    Power: {car.Engine.Power}");
                Console.WriteLine($"    Displacement: {car.Engine.Displacement}");
                Console.WriteLine($"    Efficiency: {car.Engine.Efficiency}");
                Console.WriteLine($"  Weight: {car.Weight}");
                Console.WriteLine($"  Color: {car.Color}");
            }
        }
    }
}