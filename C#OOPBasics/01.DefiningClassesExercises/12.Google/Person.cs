using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _12.Google
{
    public class Person
    {
        private string name;
        private Company company;
        private Car car;
        private List<Parent> parents;
        private List<Child> children;
        private List<Pokemon> pokemons;

        public Person(string name)
        {
            this.Name = name;
            this.Company = Company;
            this.Car = Car;
            this.Parents = new List<Parent>();
            this.Children = new List<Child>();
            this.Pokemons = new List<Pokemon>();
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public Company Company
        {
            get
            {
                return company;
            }

            set
            {
                company = value;
            }
        }

        public Car Car
        {
            get
            {
                return car;
            }

            set
            {
                car = value;
            }
        }

        public List<Parent> Parents
        {
            get
            {
                return parents;
            }

            set
            {
                parents = value;
            }
        }

        public List<Child> Children
        {
            get
            {
                return children;
            }

            set
            {
                children = value;
            }
        }

        public List<Pokemon> Pokemons
        {
            get
            {
                return pokemons;
            }

            set
            {
                pokemons = value;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine(this.Name);
            result.AppendLine("Company: ");
            if (this.Company != null)
            {
                result.AppendLine($"{this.Company}");
            }
            result.AppendLine("Car: ");
            if (this.Car != null)
            {
                result.AppendLine($"{this.Car}");
            }
            result.AppendLine("Pokemon: ");
            if (this.Pokemons.Any())
            {
                this.Pokemons.ForEach(p => result.AppendLine($"{p}"));
            }
            result.AppendLine("Parents: ");
            if (this.Parents.Any())
            {
                this.Parents.ForEach(p => result.AppendLine($"{p}"));
            }
            result.AppendLine("Children: ");
            if (this.Children.Any())
            {
                this.Children.ForEach(c => result.AppendLine($"{c}"));
            }
            return result.ToString().Trim();
        }
    }
}