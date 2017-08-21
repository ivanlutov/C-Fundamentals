public class Gun : Ammunition
{
    public const double WeightPoint = 1.4;

    public Gun(string name)
        : base(name, WeightPoint)
    {
    }
}