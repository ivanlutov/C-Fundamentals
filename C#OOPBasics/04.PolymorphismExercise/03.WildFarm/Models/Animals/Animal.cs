namespace _03.WildFarm
{
    public abstract class Animal
    {
        private string name;
        private string type;
        private double weight;
        private int foodEaten;

        protected Animal(string name, string type, double weight)
        {
            this.Name = name;
            this.Type = type;
            this.Weight = weight;
            this.FoodEaten = 0;
        }

        protected string Type
        {
            get { return this.type; }
            set { this.type = value; }
        }

        protected double Weight
        {
            get { return this.weight; }
            set { this.weight = value; }
        }

        protected string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        protected int FoodEaten
        {
            get { return this.foodEaten; }
            set { this.foodEaten = value; }
        }

        public abstract string MakeSound();

        public abstract void Eat(Food food);
    }
}