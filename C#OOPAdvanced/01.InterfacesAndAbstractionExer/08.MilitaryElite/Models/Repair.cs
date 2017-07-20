public class Repair : IRepair
{
    public Repair(string name, int hoursWorked)
    {
        Name = name;
        HoursWorked = hoursWorked;
    }
    public string Name { get; }
    public int HoursWorked { get; set; }
    public override string ToString()
    {
        return $"Part Name: {this.Name} Hours Worked: {this.HoursWorked}";
    }
}
