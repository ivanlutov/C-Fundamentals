using System;
using System.Collections.Generic;

namespace _03.BankAccountTest
{
    public class Startup
    {
        private static Dictionary<int, BankAccount> accounts;

        public static void Main()
        {
            var command = Console.ReadLine();
            accounts = new Dictionary<int, BankAccount>();

            while (command != "End")
            {
                var cmdArgs = command.Split();
                var cmdType = cmdArgs[0];
                switch (cmdType)
                {
                    case "Create":
                        Create(cmdArgs);
                        break;

                    case "Deposit":
                        Deposit(cmdArgs);
                        break;

                    case "Withdraw":
                        Withdraw(cmdArgs);
                        break;

                    case "Print":
                        Print(cmdArgs);
                        break;
                }
                command = Console.ReadLine();
            }
        }

        private static void Print(string[] cmdArgs)
        {
            var id = int.Parse(cmdArgs[1]);

            if (!accounts.ContainsKey(id))
            {
                Console.WriteLine("Account does not exist");
            }
            else
            {
                var currentAcc = accounts[id];
                Console.WriteLine(currentAcc);
            }
        }

        private static void Withdraw(string[] cmdArgs)
        {
            var id = int.Parse(cmdArgs[1]);
            var amount = double.Parse(cmdArgs[2]);

            if (!accounts.ContainsKey(id))
            {
                Console.WriteLine("Account does not exist");
            }
            else if (accounts.ContainsKey(id) && accounts[id].Balance < amount)
            {
                Console.WriteLine("Insufficient balance");
            }
            else
            {
                var currentAcc = accounts[id];
                currentAcc.Balance -= amount;
            }
        }

        private static void Deposit(string[] cmdArgs)
        {
            var id = int.Parse(cmdArgs[1]);
            var amount = double.Parse(cmdArgs[2]);

            if (!accounts.ContainsKey(id))
            {
                Console.WriteLine("Account does not exist");
            }
            else
            {
                var currentAcc = accounts[id];
                currentAcc.Balance += amount;
            }
        }

        private static void Create(string[] cmdArgs)
        {
            var id = int.Parse(cmdArgs[1]);

            if (accounts.ContainsKey(id))
            {
                Console.WriteLine("Account already exists");
            }
            else
            {
                var acc = new BankAccount { ID = id };
                accounts.Add(id, acc);
            }
        }
    }
}