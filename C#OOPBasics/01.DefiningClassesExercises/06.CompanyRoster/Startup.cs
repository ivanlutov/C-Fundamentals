using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.CompanyRoster
{
    public class Startup
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var employees = new List<Employee>();

            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split();
                var name = tokens[0];
                var salary = decimal.Parse(tokens[1]);
                var position = tokens[2];
                var departament = tokens[3];
                int age;

                var employee = new Employee(name, salary, position, departament);

                if (tokens.Length == 5 && Int32.TryParse(tokens[4], out age))
                {
                    employee.Age = age;
                }
                else if (tokens.Length == 5)
                {
                    var email = tokens[4];
                    employee.Email = email;
                }
                else if (tokens.Length == 6)
                {
                    var email = tokens[4];
                    age = int.Parse(tokens[5]);
                    employee.Email = email;
                    employee.Age = age;
                }

                employees.Add(employee);
            }

            var highestDepartament = employees
                .GroupBy(e => e.Department)
                .Select(e => new
                {
                    Department = e.Key,
                    AverageSalary = e.Average(emp => emp.Salary),
                    Employees = e.OrderByDescending(emp => emp.Salary)
                })
                .OrderByDescending(x => x.AverageSalary)
                .FirstOrDefault();

            Console.WriteLine($"Highest Average Salary: {highestDepartament.Department}");

            foreach (var employee in highestDepartament.Employees)
            {
                Console.WriteLine($"{employee.Name} {employee.Salary:F2} {employee.Email} {employee.Age}");
            }
        }
    }
}