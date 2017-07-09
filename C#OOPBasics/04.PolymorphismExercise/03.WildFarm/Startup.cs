using System;

namespace _03.WildFarm
{
    public class Startup
    {
        public static void Main()
        {
            var animalInfo = Console.ReadLine();

            while (animalInfo != "End")
            {
                var animalTokens = animalInfo.Split();
                var animalType = animalTokens[0];
                var animalName = animalTokens[1];
                var animalWeight = double.Parse(animalTokens[2]);
                var animalRegion = animalTokens[3];
                Animal animal = null;
                switch (animalType)
                {
                    case "Cat":
                        var breed = animalTokens[4];
                        animal = new Cat(animalName, animalType, animalWeight, animalRegion, breed);
                        break;

                    case "Tiger":
                        animal = new Tiger(animalName, animalType, animalWeight, animalRegion);
                        break;

                    case "Zebra":
                        animal = new Zebra(animalName, animalType, animalWeight, animalRegion);
                        break;

                    case "Mouse":
                        animal = new Mouse(animalName, animalType, animalWeight, animalRegion);
                        break;
                }

                Console.WriteLine(animal.MakeSound());

                var foodInfo = Console.ReadLine().Split();
                var foodType = foodInfo[0];
                var foodQuantity = int.Parse(foodInfo[1]);
                Food food = null;
                
                if (foodType == "Vegetable")
                {
                    food = new Vegetable(foodQuantity);
                }
                else if (foodType == "Meat")
                {
                    food = new Meat(foodQuantity);
                }
                try
                {
                    animal.Eat(food);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }

                Console.WriteLine(animal);

                animalInfo = Console.ReadLine();
            }
        }
    }
}