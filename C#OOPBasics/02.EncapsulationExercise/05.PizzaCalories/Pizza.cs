using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.PizzaCalories
{
    public class Pizza
    {
        private const int minLenght = 1;
        private const int maxLenght = 15;
        private const int minToppingCount = 0;
        private const int maxToppingCount = 10;

        private string name;
        private Dough dough;
        private List<Topping> toppings;
        private int numberOfToppings;

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.Dough = dough;
            this.NumberOfToppings = numberOfToppings;
            this.toppings = new List<Topping>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (value == string.Empty || value.Length < minLenght || value.Length > maxLenght)
                {
                    throw new ArgumentException($"Pizza name should be between {minLenght} and {maxLenght} symbols.");
                }

                this.name = value;
            }
        }

        public Dough Dough
        {
            get
            {
                return this.dough;
            }

            set
            {
                this.dough = value;
            }
        }

        public int NumberOfToppings
        {
            get
            {
                return this.numberOfToppings;
            }

            set
            {
                if (value < minToppingCount || value > maxToppingCount)
                {
                    throw new ArgumentException("Number of toppings should be in range [0..10].");
                }

                this.numberOfToppings = value;
            }
        }

        public List<Topping> Toppings
        {
            get
            {
                return toppings;
            }
        }

        private int GetCurrentToppingsCount()
        {
            return this.toppings.Count;
        }

        public void AddTopping(Topping topping)
        {
            if (GetCurrentToppingsCount() == maxToppingCount)
            {
                throw new ArgumentException($"Number of toppings should be in range [{minToppingCount}..{maxToppingCount}].");
            }

            this.Toppings.Add(topping);
        }

        public double GetCalories()
        {
            var result = this.Dough.CalculateCalories() + this.Toppings.Sum(t => t.CalculateCalories());
            return result;
        }
    }
}