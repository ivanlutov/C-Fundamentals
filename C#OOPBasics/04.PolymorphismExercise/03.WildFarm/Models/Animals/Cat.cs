namespace _03.WildFarm
{
    public class Cat : Felime
    {
        private string breed;

        public Cat(string name, string type, double weight, string region, string breed)
            : base(name, type, weight, region)
        {
            this.Breed = breed;
        }

        public string Breed
        {
            get { return this.breed; }
            set { this.breed = value; }
        }

        public override void Eat(Food food)
        {
            this.FoodEaten += food.Quantity;
        }

        public override string MakeSound()
        {
            return "Meowwww";
        }

        public override string ToString()
        {
            return $"{this.Type}[{this.Name}, {this.Breed}, {this.Weight}, {this.Region}, {this.FoodEaten}]";
        }
    }
}