using System;
using System.Collections.Generic;
using System.Text;

namespace _05._Birthday_Celebrations
{
    public class Citizen : IIdentifiable, IBirthdable
    {
        public string Id { get; 
        }
        public string Name { get; }
        public string Birthdate { get; }
        public int Age { get;
        }
        public Citizen(string id, string name, int age, string birthdate)
        {
            Id = id;
            Name = name;
            Age = age;
            Birthdate = birthdate;
        }
    }
}
