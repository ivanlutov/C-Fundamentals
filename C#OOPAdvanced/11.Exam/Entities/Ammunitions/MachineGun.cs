public class MachineGun : Ammunition
{
    public const double WeightPoint = 10.6;

    public MachineGun(string name)
        : base(name, WeightPoint)
    {
    }
}