using System;

public class UltrasoftTyre : Tyre
{
    private const string UltrasoftTyreName = "Ultrasoft";
    private double grip;

    public UltrasoftTyre(double hardness, double grip)
        : base(UltrasoftTyreName, hardness)
    {
        this.grip = grip;
    }

    public override double Degradation
    {
        get { return base.Degradation; }
        protected set
        {
            if (value < 30)
            {
                throw new ArgumentException("Blown Tyre");
            }

            base.Degradation = value;
        }
    }

    public override void ReduceDegradation()
    {
        this.Degradation -= this.grip + this.Hardness;
    }
}
