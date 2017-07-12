using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Xml;

public class Nation
{
    private string name;
    private List<Bender> benders;
    private List<Monument> monuments;
    public Nation(string name)
    {
        this.Name = name;
        this.Benders = new List<Bender>();
        this.Monuments = new List<Monument>();
    }

    public List<Bender> Benders
    {
        get { return benders; }
        set { benders = value; }
    }

    public List<Monument> Monuments
    {
        get { return monuments; }
        set { monuments = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public double GetTotalPower()
    {
        var bendersPower = this.Benders.Sum(b => b.GetPower());
        var monumentsIncrease = this.Monuments.Sum(m => m.GetAffinity());

        var totalPower = bendersPower + (bendersPower / 100) * monumentsIncrease;
        return totalPower;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"{this.Name}");
        if (this.benders.Count == 0)
        {
            sb.AppendLine("Benders: None");
        }
        else
        {
            sb.AppendLine("Benders:");
            foreach (var bender in this.benders)
            {
                sb.AppendLine(bender.ToString());
            }
        }

        if (this.monuments.Count == 0)
        {
            sb.AppendLine("Monuments: None");
        }
        else
        {
            sb.AppendLine("Monuments:");
            foreach (var monument in this.monuments)
            {
                sb.AppendLine(monument.ToString());
            }
        }

        return sb.ToString().Trim();
    }
}
