using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.PokemonTrainer
{
    public class Startup
    {
        public static void Main()
        {
            string input;
            var trainers = new List<Trainer>();

            while ((input = Console.ReadLine().Trim()) != "Tournament")
            {
                var tokens = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var trainerName = tokens[0];
                var pokemonName = tokens[1];
                var element = tokens[2];
                var health = int.Parse(tokens[3]);
                var pokemon = new Pokemon(pokemonName, element, health);
                var IsConstainsTrainer = false;

                foreach (var tr in trainers)
                {
                    if (tr.Name == trainerName)
                    {
                        IsConstainsTrainer = true;
                        break;
                    }
                }
                if (IsConstainsTrainer)
                {
                    var currentTrainer = trainers.First(t => t.Name == trainerName);
                    currentTrainer.Pokemons.Add(pokemon);
                }
                else
                {
                    var trainer = new Trainer(trainerName);
                    trainer.Pokemons.Add(pokemon);
                    trainers.Add(trainer);
                }
            }

            string elementCmd;
            while ((elementCmd = Console.ReadLine()) != "End")
            {
                foreach (var trainer in trainers)
                {
                    var currentTrainer = trainers.First(t => t.Name == trainer.Name);

                    var countOfThisElements = currentTrainer.Pokemons.Count(p => p.Element == elementCmd);
                    if (countOfThisElements >= 1)
                    {
                        currentTrainer.NumberOfBadges++;
                    }
                    else
                    {
                        currentTrainer.Pokemons.Select(p => p.Health -= 10).ToList();
                        currentTrainer.Pokemons.RemoveAll(p => p.Health <= 0);
                    }
                }
            }

            trainers
                .OrderByDescending(t => t.NumberOfBadges)
                .ToList()
                .ForEach(t => Console.WriteLine($"{t.Name} {t.NumberOfBadges} {t.Pokemons.Count}"));
        }
    }
}