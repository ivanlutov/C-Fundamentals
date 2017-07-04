using System;

namespace _01.StudentsResults
{
    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine("{0, -10}|{1, 7}|{2, 7}|{3,7}|{4, 7}|", "Name", "CAdv", "COOP", "AdvOOP", "Average");

            for (int i = 0; i < n; i++)
            {
                var student = Console.ReadLine().Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                var name = student[0].Trim();
                var grades = student[1].Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                var cadvGrade = double.Parse(grades[0]);
                var coopGrade = double.Parse(grades[1]);
                var advoopGrade = double.Parse(grades[2]);
                var allGrades = cadvGrade + coopGrade + advoopGrade;

                Console.WriteLine("{0, -10}|{1, 7:F2}|{2, 7:F2}|{3,7:F2}|{4, 7:F4}|", name, cadvGrade, coopGrade, advoopGrade, allGrades / 3);
            }
        }
    }
}