using System;

public class Car
{
    private const double MaxCapacityOfFuelTank = 160;

    private int hp;
    private double fuelAmount;
    private Tyre tyre;

    public Car(int hp, double fuelAmount, Tyre tyre)
    {
        this.Hp = hp;
        this.FuelAmount = fuelAmount;
        this.Tyre = tyre;
    }
    public int Hp
    {
        get { return this.hp; }
        private set { this.hp = value; }
    }

    public Tyre Tyre
    {
        get { return this.tyre; }
        set { this.tyre = value; }
    }

    public double FuelAmount
    {
        get { return this.fuelAmount; }

        set
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
}
