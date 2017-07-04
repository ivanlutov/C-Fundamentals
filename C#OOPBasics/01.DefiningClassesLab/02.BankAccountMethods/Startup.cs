using System;

namespace _02.BankAccountMethods
{
    public class Startup
    {
        public static void Main()
        {
            BankAccount acc = new BankAccount();

            acc.ID = 1;
            acc.Deposit(15);
            acc.Withdraw(5);

            Console.WriteLine(acc);
        }
    }
}