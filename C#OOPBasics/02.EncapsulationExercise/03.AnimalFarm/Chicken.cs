using System;

namespace _03.AnimalFarm
{
    public class Chicken
    {
        private const int minAge = 0;
        private const int maxAge = 15;

        private string name;
        private int age;

        public Chicken(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"{nameof(this.Name)} cannot be empty.");
                }

                this.name = value;
            }
        }

        public int Age
        {
            get { return this.age; }
            set
            {
                if (value < minAge || value > maxAge)
                {
                    throw new ArgumentException($"{nameof(this.Age)} should be between {minAge} and {maxAge}.");
                }

                this.age = value;
            }
        }

        public double GetProductPerDay()
        {
            return this.CalculateProductPerDay();
        }

        private double CalculateProductPerDay()
        {
            switch (this.Age)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                    return 1.5;

                case 4:
                case 5:
                case 6:
                case 7:
                    return 2;

                case 8:
                case 9:
                case 10:
                case 11:
                    return 1;

                default:
                    return 0.75;
            }
        }
    }
}