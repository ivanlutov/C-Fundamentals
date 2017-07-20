public class Mission : IMission
{
    public Mission(string name, string state)
    {
        Name = name;
        State = state;
    }

    public string Name { get; set; }
    public string State { get; set; }

    public override string ToString()
    {
        return $"Code Name: {this.Name} State: {this.State}";
    }
}