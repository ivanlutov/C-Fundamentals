using System;

public abstract class Tyre
{
    private const double StartPointOfDegradation = 100;

    private string name;
    private double hardness;
    private double degradation;

    protected Tyre(string name, double hardness)
    {
        this.name = name;
        this.Hardness = hardness;
        this.Degradation = StartPointOfDegradation;
    }
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

    public double Hardness
    {
        get { return this.hardness; }
        private set { this.hardness = value; }
    }

    public virtual void ReduceDegradation()
    {
        this.Degradation -= this.Hardness;
    }
}
