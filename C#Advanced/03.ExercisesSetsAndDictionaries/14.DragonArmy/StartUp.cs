using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _14.DragonArmy
{
    public class Dragon
    {
        private string name;
        private double damage = 45;
        private double health = 250;
        private double armor = 10;

        public Dragon(string name)
        {
            this.Name = name;
            this.Damage = damage;
            this.Health = health;
            this.Armor = armor;
        }

        public string Name
        {
            get { return this.name; }

            set
            {
                this.name = value;
            }
        }

        public double Damage
        {
            get { return this.damage; }

            set
            {
                this.damage = value;
            }
        }

        public double Health
        {
            get { return this.health; }

            set
            {
                this.health = value;
            }
        }

        public double Armor
        {
            get { return this.armor; }

            set
            {
                this.armor = value;
            }
        }
    }

    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var dragons = new Dictionary<string, List<Dragon>>();
            var pattern = @"^([A-Z]+[a-zA-Z]+) ([A-Z]+[a-zA-Z]+) (\d+|null) (\d+|null) (\d+|null)$";

            for (int i = 0; i < n; i++)
            {
                var dragonInfo = Console.ReadLine();
                Match match = Regex.Match(dragonInfo, pattern);
                if (match.Success)
                {
                    var color = match.Groups[1].Value;
                    var name = match.Groups[2].Value;
                    var damage = match.Groups[3].Value;
                    var health = match.Groups[4].Value;
                    var armor = match.Groups[5].Value;

                    var currentDragon = new Dragon(name);
                    if (damage != "null")
                    {
                        currentDragon.Damage = double.Parse(damage);
                    }
                    if (health != "null")
                    {
                        currentDragon.Health = double.Parse(health);
                    }
                    if (armor != "null")
                    {
                        currentDragon.Armor = double.Parse(armor);
                    }

                    if (!dragons.ContainsKey(color))
                    {
                        dragons[color] = new List<Dragon>();
                    }

                    Dragon dragonForRemove = dragons[color].Where(d => d.Name == name).FirstOrDefault();
                    if (dragonForRemove != null)
                    {
                        dragons[color].Remove(dragonForRemove);
                    }

                    dragons[color].Add(currentDragon);
                }
            }

            foreach (var color in dragons)
            {
                var averageHealth = color.Value.Average(x => x.Health);
                var averageDamage = color.Value.Average(x => x.Damage);
                var averageArmor = color.Value.Average(x => x.Armor);
                Console.WriteLine($"{color.Key}::({averageDamage:F2}/{averageHealth:F2}/{averageArmor:F2})");

                foreach (var dragon in color.Value.OrderBy(x => x.Name))
                {
                    Console.WriteLine($"-{dragon.Name} -> damage: {dragon.Damage}, health: {dragon.Health}, armor: {dragon.Armor}");
                }
            }
        }
    }
}