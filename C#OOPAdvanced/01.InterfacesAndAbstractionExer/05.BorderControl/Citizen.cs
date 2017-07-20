public class Citizen : IIdentifiable
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Id { get; set; }

    public Citizen(string name, int age, string id)
    {
        this.Name = name;
        this.Age = age;
        this.Id = id;
    }
}