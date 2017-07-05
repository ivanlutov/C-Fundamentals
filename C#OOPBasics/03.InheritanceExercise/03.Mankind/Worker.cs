using System;

namespace _03.Mankind
{
    public class Worker : Human
    {
        private const int MinHoursePerWork = 1;
        private const int MaxHoursePerWork = 12;

        private decimal weekSalary;
        private decimal workHoursPerDay;

        public Worker(string firstName, string lastName, decimal weekSalary, decimal workHoursPerDay)
            : base(firstName, lastName)
        {
            this.LastName = lastName;
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
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

        public decimal WeekSalary
        {
            get
            {
                return this.weekSalary;
            }

            set
            {
                if (value <= 10)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
                }

                this.weekSalary = value;
            }
        }

        public decimal WorkHoursPerDay
        {
            get
            {
                return this.workHoursPerDay;
            }

            set
            {
                if (value < MinHoursePerWork || value > MaxHoursePerWork)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
                }

                this.workHoursPerDay = value;
            }
        }

        private decimal GetSalaryPerHour()
        {
            return this.WeekSalary / (this.WorkHoursPerDay * 5);
        }

        public override string ToString()
        {
            var result =
                $"First Name: {base.FirstName}" + Environment.NewLine +
                $"Last Name: {base.LastName}" + Environment.NewLine +
                $"Week Salary: {this.WeekSalary:F2}" + Environment.NewLine +
                $"Hours per day: {this.workHoursPerDay:F2}" + Environment.NewLine +
                $"Salary per hour: {(this.GetSalaryPerHour()):F2}";

            return result;
        }
    }
}