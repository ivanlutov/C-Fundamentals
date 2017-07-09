public class Truck : Vehicle
{
    public Truck(double fuelQuantity, double fuelConsumptionPerKm)
        : base(fuelQuantity, fuelConsumptionPerKm)
    {
    }

    public override double FuelConsumptionPerKm
    {
        get { return base.FuelConsumptionPerKm + 1.6; }
    }

    public override void Refuel(double amount)
    {
        this.FuelQuantity += amount * 0.95;
    }
}