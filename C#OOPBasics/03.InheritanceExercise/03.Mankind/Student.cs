using System;

namespace _03.Mankind
{
    public class Student : Human
    {
        private string facultyNumber;

        public Student(string firstName, string lastName, string facultyNumber)
            : base(firstName, lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.FacultyNumber = facultyNumber;
        }

        public override string FirstName
        {
            get
            {
                return base.FirstName;
            }

            protected set
            {
                if (value.Length < 4)
                {
                    throw new ArgumentException("Expected length at least 4 symbols! Argument: firstName");
                }

                base.FirstName = value;
            }
        }

        public override string LastName
        {
            get
            {
                return base.LastName;
            }

            protected set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Expected length at least 3 symbols! Argument: lastName");
                }

                base.LastName = value;
            }
        }

        public string FacultyNumber
        {
            get
            {
                return this.facultyNumber;
            }

            set
            {
                if (value.Length < 5 || value.Length > 10 || !IsValidFacultyNumber(value))
                {
                    throw new ArgumentException("Invalid faculty number!");
                }

                this.facultyNumber = value;
            }
        }

        private bool IsValidFacultyNumber(string value)
        {
            bool isValidFacultyNumber = true;
            foreach (char ch in value)
            {
                if (!char.IsLetterOrDigit(ch))
                {
                    isValidFacultyNumber = false;
                }
            }

            return isValidFacultyNumber;
        }

        public override string ToString()
        {
            var result =
                $"First Name: {base.FirstName}" + Environment.NewLine +
                $"Last Name: {base.LastName}" + Environment.NewLine +
                $"Faculty number: {this.FacultyNumber}";

            return result;
        }
    }
}