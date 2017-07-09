using System;

public abstract class Vehicle
{
    private double fuelQuantity;
    private double fuelConsumptionPerKm;
    private double drivenDistance;

    protected Vehicle(double fuelQuantity, double fuelConsumptionPerKm)
    {
        this.FuelQuantity = fuelQuantity;
        this.FuelConsumptionPerKm = fuelConsumptionPerKm;
        this.DrivenDistance = 0;
    }

    public double DrivenDistance
    {
        get { return drivenDistance; }
        set { drivenDistance = value; }
    }

    public virtual double FuelConsumptionPerKm
    {
        get { return this.fuelConsumptionPerKm; }
        set { this.fuelConsumptionPerKm = value; }
    }

    public double FuelQuantity
    {
        get { return this.fuelQuantity; }
        set { this.fuelQuantity = value; }
    }

    public virtual void Drive(double distance)
    {
        if (this.FuelQuantity / this.FuelConsumptionPerKm < distance)
        {
            throw new InvalidOperationException($"{this.GetType().Name} needs refueling");
        }

        this.FuelQuantity -= distance * this.FuelConsumptionPerKm;
        this.DrivenDistance += distance;
    }

    public virtual void Refuel(double amount)
    {
        this.FuelQuantity += amount;
    }

    public override string ToString()
    {
        return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
    }
}