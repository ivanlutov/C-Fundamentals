using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.StudentsByAge
{
    public class Student
    {
        public Student(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }

    public class StartUp
    {
        public static void Main()
        {
            var names = Console.ReadLine();

            var students = new List<Student>();
            while (names != "END")
            {
                var tokens = names.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var firstName = tokens[0];
                var lastName = tokens[1];
                var age = int.Parse(tokens[2]);

                var currentStudent = new Student(firstName, lastName, age);
                students.Add(currentStudent);

                names = Console.ReadLine();
            }

            var filteredStudents = students
                .Where(s => s.Age >= 18 && s.Age <= 24)
                .ToList();

            foreach (var student in filteredStudents)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName} {student.Age}");
            }
        }
    }
}