using System;
using System.Collections.Generic;
using System.Linq;

public class PerformanceCar : Car
{
    private const int HorsepowerIncrease = 50;
    private const int SuspensionDecrease = 25;

    private List<string> addOns;

    public PerformanceCar(string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability)
        : base(brand, model, yearOfProduction, horsepower + (horsepower * HorsepowerIncrease) / 100, acceleration, suspension - (suspension * SuspensionDecrease) / 100, durability)
    {
        this.AddOns = new List<string>();
    }

    public List<string> AddOns
    {
        get { return addOns; }
        set { addOns = value; }
    }

    public override string ToString()
    {
        var result = base.ToString() + Environment.NewLine;

        if (this.AddOns.Any())
        {
            result += $"Add-ons: {string.Join(", ", this.AddOns)}";
        }
        else
        {
            result += $"Add-ons: None";
        }

        return result;
    }
}
