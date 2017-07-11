using System;

public abstract class Car
{
    private string brand;
    private string model;
    private int yearOfProduction;
    private int horsepower;
    private int acceleration;
    private int suspension;
    private int durability;

    protected Car(string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability)
    {
        this.Brand = brand;
        this.Model = model;
        this.YearOfProduction = yearOfProduction;
        this.Horsepower = horsepower;
        this.Acceleration = acceleration;
        this.Suspension = suspension;
        this.Durability = durability;
    }

    public string Brand
    {
        get { return brand; }
        set { brand = value; }
    }

    public string Model
    {
        get { return model; }
        set { model = value; }
    }

    public int YearOfProduction
    {
        get { return yearOfProduction; }
        set { yearOfProduction = value; }
    }

    public virtual int Horsepower
    {
        get { return horsepower; }
        set { horsepower = value; }
    }

    public int Acceleration
    {
        get { return acceleration; }
        set { acceleration = value; }
    }

    public virtual int Suspension
    {
        get { return suspension; }
        set { suspension = value; }
    }

    public int Durability
    {
        get { return durability; }
        set { durability = value; }
    }

    public int GetOverallPerformance()
    {
        return (this.Horsepower / this.Acceleration) + (this.Suspension + this.Durability);
    }

    public int GetEnginePerformance()
    {
        return (this.Horsepower / this.Acceleration);
    }

    public int GetSuspensionPerformance()
    {
        return (this.Suspension + this.Durability);
    }

    public override string ToString()
    {
        return $"{this.Brand} {this.Model} {this.YearOfProduction}" + Environment.NewLine +
               $"{this.Horsepower} HP, 100 m/h in {this.Acceleration} s" + Environment.NewLine +
               $"{this.Suspension} Suspension force, {this.Durability} Durability";
    }
}