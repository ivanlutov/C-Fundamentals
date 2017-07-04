using System.Collections.Generic;
using System.Linq;

namespace _03.OldestFamilyMember
{
    public class Family
    {
        private List<Person> peoples;

        public Family()
        {
            this.peoples = new List<Person>();
        }

        public List<Person> Peoples
        {
            get
            {
                return peoples;
            }
            set
            {
                peoples = value;
            }
        }

        public void AddMember(Person member)
        {
            this.Peoples.Add(member);
        }

        public Person GetOldestMember()
        {
            return peoples.OrderByDescending(x => x.Age).FirstOrDefault();
        }
    }
}