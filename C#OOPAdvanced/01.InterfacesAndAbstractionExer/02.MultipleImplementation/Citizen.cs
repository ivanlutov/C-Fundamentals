using _01.DefineAnInterfaceIPerson;

public class Citizen : IPerson, IBirthable, IIdentifiable
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Birthdate { get; }
    public string Id { get; }

    public Citizen(string name, int age, string birthdate, string id)
    {
        Name = name;
        Age = age;
        Birthdate = birthdate;
        Id = id;
    }
}