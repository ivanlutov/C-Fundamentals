public class FireMonument : Monument
{
    private int fireAffinity;
    public FireMonument(string name, int fireAffinity) : base(name)
    {
        this.FireAffinity = fireAffinity;
    }

    public int FireAffinity
    {
        get { return fireAffinity; }
        set { fireAffinity = value; }
    }

    public override int GetAffinity()
    {
        return this.FireAffinity;
    }

    public override string ToString()
    {
        return $"###Fire Monument: {this.Name}, Fire Affinity: {this.FireAffinity}";
    }
}
