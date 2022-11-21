using System;

namespace Mocking_and_Test_Driven_Development___Lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IBankIRepository database = new BankTextDb();
            Bank bank = new Bank(database);
            string command = Console.ReadLine();
            while (command != "End")
            {
                if (command == "new")
                {
                    Console.WriteLine("Name?");
                    string name = Console.ReadLine();
                    Console.WriteLine("Amount?");
                    int amount = int.Parse(Console.ReadLine());                   
                    User user = new User()
                    {
                        Name = name,
                        Account = new Account()
                        {
                            Amount = amount,
                        }
                    };
                    bank.AddUser(user);
                }
                if (command == "Transfer")
                {
                    string from = Console.ReadLine();
                    string to = Console.ReadLine();
                    int amount = int.Parse(Console.ReadLine());
                    bank.TransferMoney(from,to,amount);
                }
                if (command == "list")
                {
                    foreach (var item in bank.Users)
                    {
                        Console.WriteLine(item);
                    }
                }
                command = Console.ReadLine();
            }
        }
    }
}
