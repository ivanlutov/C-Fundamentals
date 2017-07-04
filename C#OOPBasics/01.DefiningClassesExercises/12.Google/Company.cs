namespace _12.Google
{
    public class Company
    {
        private string name;
        private string departament;
        private double salary;

        public Company(string name, string departament, double salary)
        {
            this.Name = name;
            this.Departament = departament;
            this.Salary = salary;
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

        public string Departament
        {
            get
            {
                return departament;
            }

            set
            {
                departament = value;
            }
        }

        public double Salary
        {
            get
            {
                return salary;
            }

            set
            {
                salary = value;
            }
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Departament} {this.Salary:F2}";
        }
    }
}