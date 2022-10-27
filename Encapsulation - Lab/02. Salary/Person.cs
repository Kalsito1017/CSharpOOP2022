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
        public decimal Salary { get; private set; }
        public Person(string firstname, string lastname, int age, decimal salary)
        {
            this.FirstName = firstname;
            this.Lastname = lastname;
            this.Age = age;
            this.Salary = salary;
        }
        public override string ToString()
        {
            return $"{this.FirstName} {this.Lastname} receives {this.Salary:F2} leva.";
        }
        public void IncreaseSalary(decimal percentage)
        {
            if (this.Age > 30)
            {
                this.Salary += this.Salary * percentage / 100;
            }
            else
            {
                this.Salary += this.Salary * percentage / 200;
            }
        }
    }

}
