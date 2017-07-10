using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using NeedForSpeed.Models;
using NeedForSpeed.Models.Cars;
using NeedForSpeed.Models.Races;

namespace NeedForSpeed
{
    public class CarManager
    {
        private List<Car> cars;
        private List<Race> races;
        private Garage garage;

        public CarManager()
        {
            this.cars = new List<Car>();
            this.races = new List<Race>();
            this.garage = new Garage();
        }
        public void Register(int id, string type, string brand, string model, int yearOfProduction, int horsepower,
            int acceleration, int suspension, int durability)
        {
            Car car = null;
            if (type == "Performance")
            {
                car = new PerformanceCar(id, brand, model, yearOfProduction, horsepower, acceleration, suspension, durability);
            }
            else if (type == "Show")
            {
                car = new ShowCar(id, brand, model, yearOfProduction, horsepower, acceleration, suspension, durability);
            }

            cars.Add(car);
        }

        public string Check(int id)
        {
            var currentCar = cars.FirstOrDefault(c => c.ID == id);
            return currentCar.ToString();
        }

        public void Open(int id, string type, int length, string route, int prizePool)
        {
            Race race = null;
            if (type == "Casual")
            {
                race = new CasualRace(id, length, route, prizePool);
            }
            else if (type == "Drag")
            {
                race = new DragRace(id, length, route, prizePool);
            }
            else if (type == "Drift")
            {
                race = new DriftRace(id, length, route, prizePool);
            }

            races.Add(race);
        }
        public void Participate(int carId, int raceId)
        {
            var car = cars.FirstOrDefault(c => c.ID == carId);
            var race = races.FirstOrDefault(r => r.ID == raceId);
            bool isInGarage = false;

            foreach (var garageCar in garage.parkedCars)
            {
                if (garageCar.ID == car.ID)
                {
                    isInGarage = true;
                    break;
                }
            }

            if (!isInGarage)
            {
                race.participants.Add(car);
            }
        }

        public string Start(int id)
        {
            var race = races.FirstOrDefault(r => r.ID == id);
            var typeRace = race.GetType().Name;

            if (race.participants.Count == 0)
            {
                return $"Cannot start the race with zero participants.";
            }

            var winners = new List<Car>();
            if (typeRace == "CasualRace")
            {
                winners = race.participants.OrderByDescending(c => c.GetOverallPerformance()).Take(3).ToList();
            }
            else if (typeRace == "DragRace")
            {
                winners = race.participants.OrderByDescending(c => c.GetEnginePerformance()).Take(3).ToList();
            }
            else if (typeRace == "DriftRace")
            {
                winners = race.participants.OrderByDescending(c => c.GetSuspensionPerformance()).Take(3).ToList();
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

            return result;
        }

        public void Park(int id)
        {
            var car = cars.FirstOrDefault(c => c.ID == id);
            bool carIsInRace = false;

            foreach (var race in this.races)
            {
                foreach (var c in race.participants)
                {
                    if (c.ID == car.ID)
                    {
                        carIsInRace = true;
                        break;
                    }
                }
            }

            if (!carIsInRace)
            {
                garage.parkedCars.Add(car);
            }
        }

        public void Unpark(int id)
        {
            var car = cars.FirstOrDefault(c => c.ID == id);
            bool carIsInParking = false;

            foreach (var cr in this.garage.parkedCars)
            {
                if (cr.ID == car.ID)
                {
                    carIsInParking = true;
                    break;
                }
            }
            if (carIsInParking)
            {
                garage.parkedCars.Remove(car);
            }
        }

        public void Tune(int tuneIndex, string addOn)
        {
            foreach (var car in this.garage.parkedCars)
            {
                car.Horsepower += tuneIndex;
                car.Suspension += tuneIndex / 2;
                if (car.GetType().Name == "ShowCar")
                {
                    ShowCar show = (ShowCar)car;
                    show.Stars += tuneIndex;
                }
                else
                {
                    PerformanceCar perf = (PerformanceCar)car;
                    perf.addOns.Add(addOn);
                }

            }
        }
    }
}