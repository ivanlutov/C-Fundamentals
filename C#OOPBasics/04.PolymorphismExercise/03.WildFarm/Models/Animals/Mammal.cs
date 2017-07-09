using System;

namespace _03.WildFarm
{
    public abstract class Mammal : Animal
    {
        private string region;

        public string Region
        {
            get { return this.region; }
            set { this.region = value; }
        }

        public Mammal(string name, string type, double weight, string region)
            : base(name, type, weight)
        {
            this.Region = region;
        }

        public override void Eat(Food food)
        {
            if (food.GetType().Name != "Vegetable")
            {
                throw new ArgumentException($"{this.GetType().Name}s are not eating that type of food!");
            }

            this.FoodEaten += food.Quantity;
        }

        public override string ToString()
        {
            return $"{this.Type}[{this.Name}, {this.Weight}, {this.Region}, {this.FoodEaten}]";
        }
    }
}