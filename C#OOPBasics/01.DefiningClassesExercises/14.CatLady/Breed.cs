namespace _14.CatLady
{
    public abstract class Breed
    {
        private string type;
        private double specificate;

        protected Breed(string type, double specificate)
        {
            this.Type = type;
            this.Specificate = specificate;
        }

        public double Specificate
        {
            get
            {
                return specificate;
            }

            set
            {
                specificate = value;
            }
        }

        public string Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
            }
        }

        public override string ToString()
        {
            return $"{this.Specificate}";
        }
    }
}