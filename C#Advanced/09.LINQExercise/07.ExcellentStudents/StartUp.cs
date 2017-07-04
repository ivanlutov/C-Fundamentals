using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.ExcellentStudents
{
    public class Student
    {
        public Student(string name)
        {
            this.Name = name;
            Marks = new List<int>();
        }

        public string Name { get; set; }
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
                var tokens = student.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var name = $"{tokens[0]} {tokens[1]}";
                var marks = tokens.Skip(2).Select(int.Parse).ToList();
                var currentStudent = new Student(name);
                currentStudent.Marks = marks;
                students.Add(currentStudent);

                student = Console.ReadLine();
            }

            var filteredStudent = students
                .Where(s => s.Marks.Any(x => x == 6))
                .ToList();

            foreach (var printStudent in filteredStudent)
            {
                Console.WriteLine(printStudent.Name);
            }
        }
    }
}