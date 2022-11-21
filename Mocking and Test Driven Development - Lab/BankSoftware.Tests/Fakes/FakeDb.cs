using Mocking_and_Test_Driven_Development___Lab;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankSoftware.Tests.Fakes
{
    class FakeDb : IBankIRepository
    {
        public List<User> ReadUsers()
        {
            return new List<User>() {
            new User()
            {
                Name = "Peshkata",
                Account = new Account()
                {
                    Amount = 50
                }
            },
            new User()
            {
                Name = "Goshkata",
                Account = new Account()
                {
                    Amount = 50
                }
            }
            };
        }

        public void Update(Bank bank)
        {
            throw new NotImplementedException();
        }
    }
}
