public class EarthBender : Bender
{
    private double groundSaturation;
    public EarthBender(string name, int power, double groundSaturation)
        : base(name, power)
    {
        this.GroundSaturation = groundSaturation;
    }

    public double GroundSaturation
    {
        get { return groundSaturation; }
        set { groundSaturation = value; }
    }

    public override double GetPower()
    {
        return this.Power * this.GroundSaturation;
    }
    public override string ToString()
    {
        return $"###Earth Bender: {this.Name}, Power: {this.Power}, Ground Saturation: {this.GroundSaturation:F2}";
    }

    
}
