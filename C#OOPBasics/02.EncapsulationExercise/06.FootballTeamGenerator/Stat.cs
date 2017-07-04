using System;

namespace _06.FootballTeamGenerator
{
    public class Stat
    {
        private const int MinLevel = 0;
        private const int MaxLevel = 100;
        private string name;
        private int level;

        public Stat(string name, int level)
        {
            this.Name = name;
            this.Level = level;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
            }
        }

        public int Level
        {
            get
            {
                return this.level;
            }

            set
            {
                if (value < MinLevel || value > MaxLevel)
                {
                    throw new ArgumentException($"{this.Name} should be between {MinLevel} and {MaxLevel}.");
                }

                this.level = value;
            }
        }
    }
}