using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FilterStudentsByEmailDomain
{
    public class Student
    {
        public Student(string name, string email)
        {
            this.Name = name;
            this.Email = email;
        }

        public string Name { get; set; }
        public string Email { get; set; }
    }

    public class StartUp
    {
        public static void Main()
        {
            var student = Console.ReadLine();

            var students = new List<Student>();
            while (student != "END")
            {
                var tokens = student.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var name = $"{tokens[0]} {tokens[1]}";
                var email = tokens[2];
                var currentStudent = new Student(name, email);

                students.Add(currentStudent);

                student = Console.ReadLine();
            }

            var filteredStudents = students
                .Where(s => s.Email.EndsWith("@gmail.com"))
                .ToList();

            foreach (var printStudent in filteredStudents)
            {
                Console.WriteLine(printStudent.Name);
            }
        }
    }
}