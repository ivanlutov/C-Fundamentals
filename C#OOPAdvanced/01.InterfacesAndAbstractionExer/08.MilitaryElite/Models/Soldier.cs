public abstract class Soldier : ISoldier
{
    protected Soldier(string id, string firstName, string lastName)
    {
        ID = id;
        FirstName = firstName;
        LastName = lastName;
    }
    public string ID { get; }
    public string FirstName { get; }
    public string LastName { get; }

    public override string ToString()
    {
        return $"Name: {this.FirstName} {this.LastName} Id: {this.ID}";
    }
}
