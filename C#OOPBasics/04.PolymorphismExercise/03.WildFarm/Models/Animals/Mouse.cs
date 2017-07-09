namespace _03.WildFarm
{
    public class Mouse : Mammal
    {
        public Mouse(string name, string type, double weight, string region)
            : base(name, type, weight, region)
        {
        }

        public override string MakeSound()
        {
            return "SQUEEEAAAK!";
        }
    }
}