using System.Collections.Generic;
using System.Text;

public class Engineer : SpecialisedSoldier, IEngineer
{
    public IList<IRepair> Repairs { get; }
    public Engineer(string id, string firstName, string lastName, double salary, string corps, IList<IRepair> repairs) : base(id, firstName, lastName, salary, corps)
    {
        Repairs = repairs;
    }
    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine(base.ToString());
        sb.AppendLine("Repairs:");
        for (int i = 0; i < this.Repairs.Count; i++)
        {
            sb.AppendLine(this.Repairs[i].ToString());
        }
        return sb.ToString().Trim();
    }
}
