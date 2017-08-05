using _02.ExtendedDatabase.Contracts;

namespace _02.ExtendedDatabase.Models
{
    public class People : IPeople
    {
        public People(string name, int id)
        {
            Name = name;
            Id = id;
        }

        public string Name { get; set; }
        public int Id { get; set; }
    }
}