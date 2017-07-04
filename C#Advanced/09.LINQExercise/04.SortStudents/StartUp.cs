using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.SortStudents
{
    public class Student
    {
        public Student(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class StartUp
    {
        public static void Main()
        {
            string name = Console.ReadLine();
            var students = new List<Student>();

            while (name != "END")
            {
                var tokens = name.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var firstName = tokens[0];
                var lastName = tokens[1];
                var currentStudent = new Student(firstName, lastName);
                students.Add(currentStudent);

                name = Console.ReadLine();
            }

            var orderedStudents = students
                .OrderBy(s => s.LastName)
                .ThenByDescending(s => s.FirstName)
                .ToList();

            foreach (var student in orderedStudents)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName}");
            }
        }
    }
}