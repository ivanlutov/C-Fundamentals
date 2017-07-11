using System;
using System.Collections.Generic;
using System.Linq;

namespace NeedForSpeed.Models.Cars
{
    public class PerformanceCar : Car
    {
        private const int HorsepowerIncrease = 50;
        private const int SuspensionDecrease = 25;

        public List<string> addOns;

        public PerformanceCar(string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability)
            : base(brand, model, yearOfProduction, horsepower + (horsepower * HorsepowerIncrease) / 100, acceleration, suspension - (suspension * SuspensionDecrease) / 100, durability)
        {
            this.addOns = new List<string>();
        }

        public override string ToString()
        {
            var result = base.ToString() + Environment.NewLine;

            if (this.addOns.Any())
            {
                result += $"Add-ons: {string.Join(", ", this.addOns)}";
            }
            else
            {
                result += $"Add-ons: None";
            }

            return result;
        }

        //protected override int Horsepower
        //{
        //    get { return base.Horsepower + (base.Horsepower * HorsepowerIncrease) / 100; }
        //}

        //protected override int Suspension
        //{
        //    get { return base.Suspension - (base.Suspension * SuspensionDecrease) / 100; }
        //}
    }
}