using System;
using System.Collections.Generic;
using System.Text;

namespace Mocking_and_Test_Driven_Development___Lab
{
    public class Account
    {
        public decimal Amount { get; set; } 
        public User User { get; set; }  
        public string History { get; set; }
        public void DepositMoney(decimal amount)
        {
            Amount += amount;
        }
        public void WithdrawMoney(decimal amount)
        {
            if (Amount < amount)
            {
                throw new ArgumentException("No Money");
            }
            Amount -= amount;
        }
    }
}
