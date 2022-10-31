using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl.Models
{
    public class Citizen : IIdentifiable
    {
        public string Id { get; 
        }
        public string Name { get; }
        public int Age { get;
        }
        public Citizen(string id, string name, int age)
        {
            Id = id;
            Name = name;
            Age = age;
        }
    }
}
