using _05.MordorsCrueltyPlan.FoodModels;
using _05.MordorsCrueltyPlan.MoodModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _05.MordorsCrueltyPlan
{
    public class Startup
    {
        public static void Main()
        {
            var foods = new List<Food>();

            var foodTokens = Regex.Split(Console.ReadLine(), @"\s+");

            foreach (var foodToken in foodTokens)
            {
                var currentFood = FoodFactory.CreateFood(foodToken);
                foods.Add(currentFood);
            }

            Mood mood = MoodFactory.CreateMood(foods);

            Console.WriteLine(foods.Sum(f => f.PointOfHappines));
            Console.WriteLine(mood);
        }
    }
}