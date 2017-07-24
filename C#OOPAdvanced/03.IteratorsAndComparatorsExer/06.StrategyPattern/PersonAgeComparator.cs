using System.Collections.Generic;

namespace _06.StrategyPattern
{
    public class PersonAgeComparator : IComparer<Person>
    {
        public int Compare(Person first, Person second)
        {
            return first.Age.CompareTo(second.Age);
        }
    }
}