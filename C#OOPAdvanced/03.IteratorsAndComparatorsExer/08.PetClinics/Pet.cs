namespace _08.PetClinics
{
    public class Pet
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Kind { get; set; }

        public Pet(string name, int age, string kind)
        {
            Name = name;
            Age = age;
            Kind = kind;
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Age} {this.Kind}";
        }
    }
}