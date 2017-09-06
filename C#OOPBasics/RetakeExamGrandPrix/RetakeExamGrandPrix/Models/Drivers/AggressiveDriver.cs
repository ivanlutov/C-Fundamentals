public class AggressiveDriver : Driver
{
    private const double FuelConsPerKm = 2.7;
    private const double SpeedMultiplier = 1.3;

    public AggressiveDriver(string name, Car car)
        : base(name, car, FuelConsPerKm)
    {
    }

    public override double Speed
    {
        get { return base.Speed * SpeedMultiplier; }
    }
}