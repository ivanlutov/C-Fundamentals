using System.Collections.Generic;
using System.Text;

public class Commando : SpecialisedSoldier, ICommando
{
    public IList<IMission> Missions { get; }
    public Commando(string id, string firstName, string lastName, double salary, string corps, IList<IMission> missions) : base(id, firstName, lastName, salary, corps)
    {
        Missions = missions;
    }
    public void CompleteMission()
    {
    }
    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine(base.ToString());
        sb.AppendLine("Missions:");
        for (int i = 0; i < this.Missions.Count; i++)
        {
            sb.AppendLine(this.Missions[i].ToString());
        }
        return sb.ToString().Trim();
    }
}
