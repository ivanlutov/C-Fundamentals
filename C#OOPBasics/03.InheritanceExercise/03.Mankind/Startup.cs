using System;

namespace _03.Mankind
{
    public class Startup
    {
        public static void Main()
        {
            var studentTokens = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Student student;
            try
            {
                student = new Student(studentTokens[0], studentTokens[1], studentTokens[2]);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
                return;
            }

            var workerTokens = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Worker worker;
            try
            {
                worker = new Worker(workerTokens[0], workerTokens[1], decimal.Parse(workerTokens[2]), decimal.Parse(workerTokens[3]));
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
                return;
            }

            Console.WriteLine(student);
            Console.WriteLine();
            Console.WriteLine(worker);
        }
    }
}