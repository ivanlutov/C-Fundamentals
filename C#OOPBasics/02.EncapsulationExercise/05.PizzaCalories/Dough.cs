using System;

namespace _05.PizzaCalories
{
    public class Dough
    {
        private const int MinWeight = 1;
        private const int MaxWeight = 200;
        private const double BaseCalloriesPerGram = 2;
        private string type;
        private double weight;
        private string technique;

        public Dough(string type, string technique, double weight)
        {
            this.Type = type;
            this.Technique = technique;
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
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
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
                    throw new ArgumentException($"Dough weight should be in the range [{MinWeight}..{MaxWeight}].");
                }
                this.weight = value;
            }
        }

        public string Technique
        {
            get
            {
                return this.technique;
            }

            set
            {
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.technique = value;
            }
        }

        public double CalculateCalories()
        {
            var type = 0d;
            var technique = 0d;
            if (this.Type.ToLower() == "white")
            {
                type = 1.5;
            }
            else if (this.Type.ToLower() == "wholegrain")
            {
                type = 1.0;
            }
            if (this.Technique.ToLower() == "crispy")
            {
                technique = 0.9;
            }
            else if (this.Technique.ToLower() == "chewy")
            {
                technique = 1.1;
            }
            else if (this.Technique.ToLower() == "homemade")
            {
                technique = 1.0;
            }

            var result = BaseCalloriesPerGram * weight * type * technique;
            return result;
        }
    }
}