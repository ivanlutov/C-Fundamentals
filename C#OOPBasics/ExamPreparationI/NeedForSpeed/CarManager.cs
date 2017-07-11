using System;
using System.Collections.Generic;
using System.Linq;
public class CarManager
{
    private Dictionary<int, Car> cars;
    private Dictionary<int, Race> races;
    private Garage garage;
    private CarFactory factory;

    public CarManager()
    {
        this.cars = new Dictionary<int, Car>();
        this.races = new Dictionary<int, Race>();
        this.garage = new Garage();
        this.factory = new CarFactory();
    }

    public void Register(int id, string type, string brand, string model, int yearOfProduction, int horsepower,
        int acceleration, int suspension, int durability)
    {
        var car = factory.CreateCar(type, brand, model, yearOfProduction, horsepower, acceleration, suspension, durability);
        cars[id] = car;
    }

    public string Check(int id)
    {
        var currentCar = cars[id];
        return currentCar.ToString();
    }

    public void Open(int id, string type, int length, string route, int prizePool)
    {
        Race race = null;
        if (type == "Casual")
        {
            race = new CasualRace(length, route, prizePool);
        }
        else if (type == "Drag")
        {
            race = new DragRace(length, route, prizePool);
        }
        else if (type == "Drift")
        {
            race = new DriftRace(length, route, prizePool);
        }

        races[id] = race;
    }

    public void Participate(int carId, int raceId)
    {
        var car = cars[carId];
        var race = races[raceId];

        if (!garage.ParkedCars.ContainsKey(carId))
        {
            race.Participants[carId] = car;
        }
    }

    public string Start(int id)
    {
        var race = races[id];
        var typeRace = race.GetType().Name;

        if (race.Participants.Count == 0)
        {
            return $"Cannot start the race with zero participants.";
        }

        var winners = new List<Car>();
        if (typeRace == "CasualRace")
        {
            winners = race.Participants.Values.OrderByDescending(c => c.GetOverallPerformance()).Take(3).ToList();
        }
        else if (typeRace == "DragRace")
        {
            winners = race.Participants.Values.OrderByDescending(c => c.GetEnginePerformance()).Take(3).ToList();
        }
        else if (typeRace == "DriftRace")
        {
            winners = race.Participants.Values.OrderByDescending(c => c.GetSuspensionPerformance()).Take(3).ToList();
        }

        var result = $"{race.Route} - {race.Length}";
        int counter = 1;
        var pp = 0;
        var money = 0;

        foreach (var winner in winners)
        {
            result += Environment.NewLine;

            if (typeRace == "CasualRace")
            {
                pp = winner.GetOverallPerformance();
            }
            else if (typeRace == "DragRace")
            {
                pp = winner.GetEnginePerformance();
            }
            else if (typeRace == "DriftRace")
            {
                pp = winner.GetSuspensionPerformance();
            }
            if (counter == 1)
            {
                money = (race.PrizePool * 50) / 100;
            }
            else if (counter == 2)
            {
                money = (race.PrizePool * 30) / 100;
            }
            else if (counter == 3)
            {
                money = (race.PrizePool * 20) / 100;
            }

            result += ($"{counter}. {winner.Brand} {winner.Model} {pp}PP - ${money}");
            counter++;
        }

        this.races.Remove(id);
        return result;
    }

    public void Park(int id)
    {
        var car = cars[id];
        bool carIsInRace = false;

        foreach (var race in this.races.Values)
        {
            foreach (var c in race.Participants)
            {
                if (c.Key == id)
                {
                    carIsInRace = true;
                    break;
                }
            }
        }

        if (!carIsInRace)
        {
            garage.ParkedCars[id] = car;
        }
    }

    public void Unpark(int id)
    {
        if (garage.ParkedCars.ContainsKey(id))
        {
            garage.ParkedCars.Remove(id);
        }
    }

    public void Tune(int tuneIndex, string addOn)
    {
        foreach (var car in this.garage.ParkedCars)
        {
            car.Value.Horsepower += tuneIndex;
            car.Value.Suspension += tuneIndex / 2;
            if (car.Value.GetType().Name == "ShowCar")
            {
                ShowCar show = (ShowCar)car.Value;
                show.Stars += tuneIndex;
            }
            else
            {
                PerformanceCar perf = (PerformanceCar)car.Value;
                perf.AddOns.Add(addOn);
            }
        }
    }
}
