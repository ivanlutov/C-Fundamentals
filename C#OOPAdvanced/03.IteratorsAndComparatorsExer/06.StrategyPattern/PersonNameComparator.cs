using System.Collections.Generic;

namespace _06.StrategyPattern
{
    public class PersonNameComparator : IComparer<Person>
    {
        public int Compare(Person first, Person second)
        {
            if (first.Name.Length.CompareTo(second.Name.Length) != 0)
            {
                return first.Name.Length.CompareTo(second.Name.Length);
            }

            return char.ToLower(first.Name[0]).CompareTo(char.ToLower(second.Name[0]));
        }
    }
}