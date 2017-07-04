using System;

namespace _07.SpeedRacing
{
    public class Car
    {
        private string model;
        private double fuelAmount;
        private double consumptionFor1Km;
        private double distanceTraveled;

        public Car(string model, double fuelAmount, double consumptionFor1Km)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.ConsumptionFor1Km = consumptionFor1Km;
            this.DistanceTraveled = 0;
        }

        public string Model
        {
            get
            {
                return this.model;
            }

            set
            {
                this.model = value;
            }
        }

        public double FuelAmount
        {
            get
            {
                return this.fuelAmount;
            }

            set
            {
                this.fuelAmount = value;
            }
        }

        public double ConsumptionFor1Km
        {
            get
            {
                return this.consumptionFor1Km;
            }

            set
            {
                this.consumptionFor1Km = value;
            }
        }

        public double DistanceTraveled
        {
            get
            {
                return this.distanceTraveled;
            }

            set
            {
                this.distanceTraveled = value;
            }
        }

        private bool CanDistanceTraveled(double distance)
        {
            if (this.fuelAmount < distance * this.consumptionFor1Km)
            {
                return false;
            }
            return true;
        }

        public void Move(double distance)
        {
            if (!CanDistanceTraveled(distance))
            {
                throw new InvalidOperationException("Insufficient fuel for the drive");
            }

            this.fuelAmount -= distance * this.consumptionFor1Km;
            this.distanceTraveled += distance;
        }

        public override string ToString()
        {
            return $"{this.model} {this.fuelAmount:F2} {this.distanceTraveled}";
        }
    }
}