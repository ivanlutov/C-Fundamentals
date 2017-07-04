using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.StudentsJoinedToSpecialties
{
    public class StudentSpecialty
    {
        public StudentSpecialty(string name, string facultyNumber)
        {
            this.Name = name;
            this.FacultyNumber = facultyNumber;
        }

        public string Name { get; set; }
        public string FacultyNumber { get; set; }
    }

    public class Student
    {
        public Student(string name, string facultyNumber)
        {
            this.Name = name;
            this.FacultyNumber = facultyNumber;
        }

        public string Name { get; set; }
        public string FacultyNumber { get; set; }
    }

    public class StartUp
    {
        public static void Main()
        {
            var inputSpecialty = Console.ReadLine();

            var specialtyList = new List<StudentSpecialty>();
            var studentList = new List<Student>();

            while (inputSpecialty != "Students:")
            {
                var tokensSpecialty = inputSpecialty.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var name = $"{tokensSpecialty[0].Trim()} {tokensSpecialty[1].Trim()}";
                var facultyNumber = tokensSpecialty[2].Trim();

                var currentSpecialty = new StudentSpecialty(name, facultyNumber);
                specialtyList.Add(currentSpecialty);

                inputSpecialty = Console.ReadLine();
            }

            var inputStudent = Console.ReadLine();

            while (inputStudent != "END")
            {
                var tokensStudent = inputStudent.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var facultyNumber = tokensStudent[0].Trim();
                var name = $"{tokensStudent[1].Trim()} {tokensStudent[2].Trim()}";
                var currentStudent = new Student(name, facultyNumber);
                studentList.Add(currentStudent);

                inputStudent = Console.ReadLine();
            }

            var joined = specialtyList
                .Join(studentList, sp => sp.FacultyNumber, st => st.FacultyNumber, (sp, st) => new
                {
                    Name = st.Name,
                    FacultyNumber = st.FacultyNumber,
                    Specialty = sp.Name
                })
                .ToList();

            foreach (var student in joined.OrderBy(s => s.Name))
            {
                Console.WriteLine($"{student.Name} {student.FacultyNumber} {student.Specialty}");
            }
        }
    }
}