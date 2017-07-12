public class WaterBender : Bender
{
    private double waterClarity;
    public WaterBender(string name, int power, double waterClarity)
        : base(name, power)
    {
        this.WaterClarity = waterClarity;
    }

    public double WaterClarity
    {
        get { return waterClarity; }
        set { waterClarity = value; }
    }

    public override double GetPower()
    {
        return this.Power * this.WaterClarity;
    }
    public override string ToString()
    {
        return $"###Water Bender: {this.Name}, Power: {this.Power}, Water Clarity: {this.WaterClarity:F2}";
    }
}
