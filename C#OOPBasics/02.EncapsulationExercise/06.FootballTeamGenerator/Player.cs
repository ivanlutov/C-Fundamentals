using System;

namespace _06.FootballTeamGenerator
{
    public class Player
    {
        private string name;
        private double overalSkillLevel;

        public Stat Endurance { get; }
        public Stat Sprint { get; }
        public Stat Dribble { get; }
        public Stat Passing { get; }
        public Stat Shooting { get; }

        public Player(string name, Stat endurance, Stat sprint, Stat dribble, Stat passing, Stat shooting)
        {
            this.Name = name;
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
            this.CalculateAverigeStat();
        }

        public string Name
        {
            get
            {
                return name;
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

        public void CalculateAverigeStat()
        {
            double sum = this.Endurance.Level + this.Sprint.Level + this.Dribble.Level + this.Passing.Level + this.Shooting.Level;
            this.OveralSkillLevel = Math.Round(sum / 5, 0);
        }

        public double OveralSkillLevel
        {
            get { return overalSkillLevel; }
            set { overalSkillLevel = value; }
        }
    }
}