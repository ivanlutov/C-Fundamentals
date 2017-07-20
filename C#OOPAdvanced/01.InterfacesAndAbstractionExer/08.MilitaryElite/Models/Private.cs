public class Private : Soldier, IPrivate
{
    public double Salary { get; private set; }

    public Private(string id, string firstName, string lastName, double salary) : base(id, firstName, lastName)
    {
        Salary = salary;
    }

    public override string ToString()
    {
        return $"{base.ToString()} Salary: {this.Salary:f2}";
    }
}