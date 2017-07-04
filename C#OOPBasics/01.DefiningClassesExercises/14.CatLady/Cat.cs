namespace _14.CatLady
{
    public class Cat
    {
        private string name;
        private Breed breed;

        public Cat(string name, Breed breed)
        {
            this.Name = name;
            this.Breed = breed;
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

        public Breed Breed
        {
            get
            {
                return breed;
            }

            set
            {
                breed = value;
            }
        }
    }
}