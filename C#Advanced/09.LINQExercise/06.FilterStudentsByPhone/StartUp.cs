using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.FilterStudentsByPhone
{
    public class Student
    {
        public Student(string name, string phone)
        {
            this.Name = name;
            this.Phone = phone;
        }

        public string Name { get; set; }
        public string Phone { get; set; }
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
                var phone = tokens[2];
                var currentStudent = new Student(name, phone);

                students.Add(currentStudent);

                student = Console.ReadLine();
            }

            var filteredStudents = students
                .Where(s => s.Phone.StartsWith("02") || s.Phone.StartsWith("+3592"))
                .ToList();

            foreach (var printStudent in filteredStudents)
            {
                Console.WriteLine(printStudent.Name);
            }
        }
    }
}