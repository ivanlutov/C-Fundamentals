namespace _14.CatLady
{
    public class Cymric : Breed
    {
        public Cymric(string type, double specificate) : base(type, specificate)
        {
        }

        public override string ToString()
        {
            return $"{this.Specificate:F2}";
        }
    }
}