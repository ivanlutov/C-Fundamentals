public class Pet : IBirthtable
{
    public string Name { get; set; }

    public string Birthdate { get; set; }

    public Pet(string name, string birthdate)
    {
        this.Name = name;
        this.Birthdate = birthdate;
    }
}