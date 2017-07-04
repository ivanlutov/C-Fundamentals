using System;

namespace _05.PizzaCalories
{
    public class Topping
    {
        private const int MinWeight = 1;
        private const int MaxWeight = 50;
        private const double BaseCalloriesPerGram = 2;
        private string type;
        private double weight;

        public Topping(string type, double weight)
        {
            this.Type = type;
            this.Weight = weight;
        }

        public string Type
        {
            get
            {
                return this.type;
            }

            set
            {
                if (value.ToLower() != "meat" && value.ToLower() != "veggies" && value.ToLower() != "cheese" && value.ToLower() != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }

                this.type = value;
            }
        }

        public double Weight
        {
            get
            {
                return this.weight;
            }

            set
            {
                if (value < MinWeight || value > MaxWeight)
                {
                    throw new ArgumentException($"{this.Type} weight should be in the range [{MinWeight}..{MaxWeight}].");
                }

                this.weight = value;
            }
        }

        public double CalculateCalories()
        {
            var type = 0d;

            if (this.Type.ToLower() == "meat")
            {
                type = 1.2;
            }
            else if (this.Type.ToLower() == "veggies")
            {
                type = 0.8;
            }
            else if (this.Type.ToLower() == "cheese")
            {
                type = 1.1;
            }
            else if (this.Type.ToLower() == "sauce")
            {
                type = 0.9;
            }

            var result = BaseCalloriesPerGram * this.Weight * type;
            return result;
        }
    }
}