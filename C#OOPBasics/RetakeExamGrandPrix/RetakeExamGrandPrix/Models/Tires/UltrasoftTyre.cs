using System;

public class UltrasoftTyre : Tyre
{
    private const string UltrasoftTyreName = "Ultrasoft";
    private double degradation;

    public UltrasoftTyre(double hardness, double grip)
        : base( hardness)
    {
        this.Grip = grip;
    }
    public double Grip { get; }

    public override string Name => UltrasoftTyreName;

    public override double Degradation
    {
        get { return this.degradation; }
        protected set
        {
            if (value < 30)
            {
                throw new ArgumentException("Blown Tyre");
            }

            this.degradation = value;
        }
    }

    public override void ReduceDegradation()
    {
        this.Degradation -= this.Grip + this.Hardness;
    }
}