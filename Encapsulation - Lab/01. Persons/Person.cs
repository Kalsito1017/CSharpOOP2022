using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Person
    {
        public string FirstName { get; private set; }
        public string Lastname { get;private set; }
        public int Age { get; private set; }
        public Person(string firstname, string lastname, int age)
        {
            this.FirstName = firstname;
            this.Lastname = lastname;
            this.Age = age;
        }
        public override string ToString()
        {
            return $"{this.FirstName} {this.Lastname} is {this.Age} years old.";
        }
    }

}
