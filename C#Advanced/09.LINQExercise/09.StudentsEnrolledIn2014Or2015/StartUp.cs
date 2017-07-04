using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.StudentsEnrolledIn2014Or2015
{
    public class Student
    {
        public Student(string facultyNumber)
        {
            this.FacultyNumber = facultyNumber;
            Marks = new List<int>();
        }

        public string FacultyNumber { get; set; }
        public List<int> Marks { get; set; }
    }

    public class StartUp
    {
        public static void Main()
        {
            var student = Console.ReadLine();
            var students = new List<Student>();

            while (student != "END")
            {
                var tokens = student
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var facultyNumber = tokens[0];
                var marks = tokens.Skip(1).Select(int.Parse).ToList();
                var currentStudent = new Student(facultyNumber);
                currentStudent.Marks = marks;
                students.Add(currentStudent);

                student = Console.ReadLine();
            }

            var filteredStudents = students
                .Where(s => s.FacultyNumber.EndsWith("14") || s.FacultyNumber.EndsWith("15"))
                .ToList();

            foreach (var printSutStudent in filteredStudents)
            {
                Console.WriteLine(string.Join(" ", printSutStudent.Marks));
            }
        }
    }
}