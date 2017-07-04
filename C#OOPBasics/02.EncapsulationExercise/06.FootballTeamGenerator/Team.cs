using System;
using System.Collections.Generic;

namespace _06.FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private double rating;
        private Dictionary<string, Player> players;

        public Team(string name)
        {
            this.Name = name;
            this.rating = 0;
            this.players = new Dictionary<string, Player>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"A {nameof(this.name)} should not be empty.");
                }

                this.name = value;
            }
        }

        public double Rating
        {
            get
            {
                return this.rating;
            }

            set
            {
                this.rating = value;
            }
        }

        public Dictionary<string, Player> Players
        {
            get
            {
                return this.players;
            }

            set
            {
                this.players = value;
            }
        }

        public void AddPlayer(Player player)
        {
            players.Add(player.Name, player);
            rating += player.OveralSkillLevel;
        }

        public void RemovePlayer(string name)
        {
            if (!this.players.ContainsKey(name))
            {
                throw new ArgumentException($"Player {name} is not in {this.Name} team. ");
            }

            var player = players[name];
            this.rating -= player.OveralSkillLevel;
            players.Remove(player.Name);
        }

        public override string ToString()
        {
            string result = $"{this.Name} - {this.rating}";
            return result;
        }
    }
}