using NeedForSpeed.Models.Cars;

namespace NeedForSpeed.Factories
{
    public class CarFactory
    {
        public Car CreateCar(string type, string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability)
        {
            Car car = null;
            if (type == "Performance")
            {
                car = new PerformanceCar(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability);
            }
            else if (type == "Show")
            {
                car = new ShowCar(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability);
            }

            return car;
        }
    }
}