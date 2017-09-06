using System;
public class Car
{
    private const double MaxCapacityOfFuelTank = 160;

    private double fuelAmount;
    private Tyre tyre;

    public Car(int hp, double fuelAmount, Tyre tyre)
    {
        this.Hp = hp;
        this.FuelAmount = fuelAmount;
        this.Tyre = tyre;
    }

    public int Hp { get; }

    public Tyre Tyre
    {
        get { return this.tyre; }
        private set { this.tyre = value; }
    }

    public double FuelAmount
    {
        get { return this.fuelAmount; }

        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("Out of fuel");
            }

            if (value > MaxCapacityOfFuelTank)
            {
                this.fuelAmount = MaxCapacityOfFuelTank;
            }
            else
            {
                this.fuelAmount = value;
            }
        }
    }

    public void ReduceFuel(int length, double fuelConsumption)
    {
        this.FuelAmount = this.FuelAmount - (length * fuelConsumption);
    }
    public void Refuel(double fuel)
    {
        this.FuelAmount += fuel;
    }

    public void ChangeTyre(Tyre newTyre)
    {
        this.Tyre = newTyre;
    }
}