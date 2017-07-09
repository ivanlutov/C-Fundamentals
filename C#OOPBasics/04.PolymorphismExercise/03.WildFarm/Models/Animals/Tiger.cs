using System;

namespace _03.WildFarm
{
    public class Tiger : Felime
    {
        public Tiger(string name, string type, double weight, string region)
            : base(name, type, weight, region)
        {
        }
        public override void Eat(Food food)
        {
            if (food.GetType().Name != "Meat")
            {
                throw new ArgumentException($"{this.GetType().Name}s are not eating that type of food!");
            }

            this.FoodEaten += food.Quantity;
        }
        public override string MakeSound()
        {
            return "ROAAR!!!";
        }
    }
}