using System;

namespace NeedForSpeed
{
    public class Startup
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var carManager = new CarManager();

            while (input != "Cops Are Here")
            {
                var tokens = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var cmd = tokens[0];

                switch (cmd)
                {
                    case "register":
                        RegisteredCar(carManager, tokens);
                        break;

                    case "check":
                        var result = carManager.Check(int.Parse(tokens[1]));
                        Console.WriteLine(result);
                        break;

                    case "open":
                        OpenRace(carManager, tokens);
                        break;

                    case "participate":
                        carManager.Participate(int.Parse(tokens[1]), int.Parse(tokens[2]));
                        break;

                    case "start":
                        result = carManager.Start(int.Parse(tokens[1]));
                        Console.WriteLine(result);
                        break;

                    case "park":
                        carManager.Park(int.Parse(tokens[1]));
                        break;

                    case "unpark":
                        carManager.Unpark(int.Parse(tokens[1]));
                        break;

                    case "tune":
                        carManager.Tune(int.Parse(tokens[1]), tokens[2]);
                        break;
                }

                input = Console.ReadLine();
            }
        }

        private static void OpenRace(CarManager carManager, string[] tokens)
        {
            var id = int.Parse(tokens[1]);
            var type = tokens[2];
            var lenght = int.Parse(tokens[3]);
            var route = tokens[4];
            var prizePool = int.Parse(tokens[5]);
            carManager.Open(id, type, lenght, route, prizePool);
        }

        private static void RegisteredCar(CarManager carManager, string[] tokens)
        {
            var id = int.Parse(tokens[1]);
            var type = tokens[2];
            var brand = tokens[3];
            var model = tokens[4];
            var year = int.Parse(tokens[5]);
            var horsepower = int.Parse(tokens[6]);
            var acceleration = int.Parse(tokens[7]);
            var suspension = int.Parse(tokens[8]);
            var durability = int.Parse(tokens[9]);
            carManager.Register(id, type, brand, model, year, horsepower, acceleration, suspension, durability);
        }
    }
}