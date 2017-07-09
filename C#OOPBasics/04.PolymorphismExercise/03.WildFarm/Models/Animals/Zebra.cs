namespace _03.WildFarm
{
    public class Zebra : Mammal
    {
        public Zebra(string name, string type, double weight, string region)
            : base(name, type, weight, region)
        {
        }

        public override string MakeSound()
        {
            return "Zs";
        }
    }
}