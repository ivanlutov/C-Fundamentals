using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.StudentsByGroup
{
    public class Student
    {
        public Student(string firstName, string lastName, int @group)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Group = @group;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Group { get; set; }
    }

    public class StartUp
    {
        public static void Main()
        {
            var names = Console.ReadLine();

            var namesAndGroups = new List<Student>();
            while (names != "END")
            {
                var tokens = names.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var firstName = tokens[0];
                var lastName = tokens[1];
                var group = int.Parse(tokens[2]);

                var currentStudent = new Student(firstName, lastName, group);
                namesAndGroups.Add(currentStudent);

                names = Console.ReadLine();
            }

            var result = namesAndGroups
                .Where(s => s.Group == 2)
                .OrderBy(s => s.FirstName)
                .ToList();

            foreach (var student in result)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName}");
            }
        }
    }
}