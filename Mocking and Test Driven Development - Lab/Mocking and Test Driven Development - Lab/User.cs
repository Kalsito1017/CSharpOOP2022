using System;
using System.Collections.Generic;
using System.Text;

namespace Mocking_and_Test_Driven_Development___Lab
{
    public class User
    {
        public string Name { get; set; }
        public Account Account { get; set; }
        public override string ToString()
        {
            return $"{Name} : {Account.Amount} lv";
        }
    }
}
