using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mocking_and_Test_Driven_Development___Lab
{
    public class Bank
    {
        private IBankIRepository database;
        public List<User> Users { get; set; }
        
        public Bank(IBankIRepository db)
        {
            this.database = db;
            Users = db.ReadUsers();
        }
        public void TransferMoney(User from, User to, decimal amount)
        {
            
            from.Account.WithdrawMoney(amount);
            to.Account.DepositMoney(amount);
            database.Update(this);
        }
        public void TransferMoney(string fromName, string toName, decimal amount)
        {
            User from = Users.First(u => u.Name == fromName);
            User to = Users.First(u => u.Name == toName);
            from.Account.WithdrawMoney(amount);
            to.Account.DepositMoney(amount);
            database.Update(this);
        }
        public void AddUser(User user)
        {
            Users.Add(user);
            database.Update(this);
        }
        public void RemoveUser(User user)
        {
            Users.Remove(user);
            database.Update(this);
        }
    }
}
