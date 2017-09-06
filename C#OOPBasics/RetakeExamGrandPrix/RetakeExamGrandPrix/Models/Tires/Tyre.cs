using System;

public abstract class Tyre
{
    private const double StartPointOfDegradation = 100;

    private double hardness;
    private double degradation;

    protected Tyre(double hardness)
    {
        this.Hardness = hardness;
        this.Degradation = StartPointOfDegradation;
    }

    public abstract string Name { get; }

    public virtual double Degradation
    {
        get { return this.degradation; }
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException("Blown Tyre");
            }

            this.degradation = value;
        }
    }

    public double Hardness { get; }

    public virtual void ReduceDegradation()
    {
        this.Degradation -= this.Hardness;
    }
}