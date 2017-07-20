using System.Text;

public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
{
    public string Corps { get; }

    protected SpecialisedSoldier(string id, string firstName, string lastName, double salary, string corps) : base(id, firstName, lastName, salary)
    {
        Corps = corps;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine(base.ToString());
        sb.AppendLine($"Corps: {this.Corps}");
        return sb.ToString().Trim();
    }
}