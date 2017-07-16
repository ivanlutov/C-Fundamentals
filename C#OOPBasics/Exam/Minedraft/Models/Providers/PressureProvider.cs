public class PressureProvider : Provider
{
    public PressureProvider(string id, double energyOutput) 
        : base(id, energyOutput)
    {
        base.EnergyOutput += (this.EnergyOutput * 50) / 100;
    }
}
