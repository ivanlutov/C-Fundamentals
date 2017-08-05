using _02.ExtendedDatabase.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.ExtendedDatabase.Models
{
    public class Database : IDatabase
    {
        private readonly IList<IPeople> persons;

        public Database()
        {
            this.persons = new List<IPeople>();
        }

        public int CurrentIndex { get; set; }

        public int Count()
        {
            return this.persons.Count;
        }

        public void Add(IPeople people)
        {
            if (this.persons.FirstOrDefault(p => p.Name == people.Name) != null)
            {
                throw new InvalidOperationException();
            }

            if (this.persons.FirstOrDefault(p => p.Id == people.Id) != null)
            {
                throw new InvalidOperationException();
            }

            this.persons.Add(people);
        }

        public IPeople Remove()
        {
            if (this.persons.Count == 0)
            {
                throw new InvalidOperationException("Database is empty");
            }

            var lastIndex = this.persons.Count - 1;
            var personForReturn = this.persons[lastIndex];
            this.persons.RemoveAt(lastIndex);

            return personForReturn;
        }

        public IPeople FindByUsername(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException();
            }

            var currentUser = this.persons.FirstOrDefault(p => p.Name == name);
            if (currentUser == null)
            {
                throw new InvalidOperationException();
            }

            return currentUser;
        }

        public IPeople FindById(int id)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            var currentUser = this.persons.FirstOrDefault(p => p.Id == id);
            if (currentUser == null)
            {
                throw new InvalidOperationException();
            }

            return currentUser;
        }
    }
}