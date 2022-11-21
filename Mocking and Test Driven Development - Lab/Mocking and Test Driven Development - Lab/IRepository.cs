using System;
using System.Collections.Generic;
using System.Text;

namespace Mocking_and_Test_Driven_Development___Lab
{
    public interface IBankIRepository
    {
        
        void Update(Bank bank);
        List<User> ReadUsers();

    }
}
