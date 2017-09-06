public abstract class Driver
{
    private string name;
    private double totalTime;
    private Car car;
    private double fuelConsumptionPerKm;

    protected Driver(string name, Car car, double fuelConsumptionPerKm)
    {
        this.Name = name;
        this.Car = car;
        this.FuelConsumptionPerKm = fuelConsumptionPerKm;
        this.totalTime = 0;
    }
    public string Name { get; }
    public double TotalTime
    {
        get { return this.totalTime; }
        set { this.totalTime = value; }
    }

    public Car Car
    {
        get { return this.car; }
        private set { this.car = value; }
    }

    public double FuelConsumptionPerKm
    {
        get { return this.fuelConsumptionPerKm; }
        private set { this.fuelConsumptionPerKm = value; }
    }

    public virtual double Speed
    {
        get { return (this.Car.Hp + this.Car.Tyre.Degradation) / this.Car.FuelAmount; }
    }

    public virtual void ReduceFuelAmount(int length)
    {
        this.Car.ReduceFuel(length, this.FuelConsumptionPerKm);
    }
}