using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _06.Animals
{
    public abstract class Animal
    {
        private string name;
        private int age;
        private string gender;

        protected Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid input!");
                }

                this.name = value;
            }
        }


        public string Gender
        {
            get { return this.gender; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid input!");
                }

                this.gender = value;
            }
        }

        public int Age
        {
            get { return this.age; }
            set
            {
                //var pattern = @"^\d+$";
                //var rgx = new Regex(pattern);
                //if (!rgx.IsMatch(value.ToString()))
                //{
                //    throw new FormatException("Invalid input!");
                //}
                if (value < 0)
                {
                    throw new ArgumentException("Invalid input!");
                }

                this.age = value;
            }
        }

        public abstract string ProduceSound();

        public override string ToString()
        {
            return $"{GetType().Name}" + Environment.NewLine +
                   $"{this.Name} {this.Age} {this.Gender}" + Environment.NewLine +
                   $"{this.ProduceSound()}";
        }
    }
}
