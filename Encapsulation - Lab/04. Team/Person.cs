using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Person
    {
        private decimal salary;
        private string firstname;
        private string lastname;
        private int age;
        public string FirstName
        {
            get
            {
                return this.firstname;
            }
            private set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
                }
                this.firstname = value;
            }
        }
        public string Lastname
        {
            get
            {
                return this.lastname;
            }
            private set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");
                }
                this.lastname = value;
            }
        }

        public int Age
        {
            get { return this.age; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Age cannot be zero or a negative integer!");
                }
                this.age = value;
            }
        }
        public decimal Salary
        {
            get
            {
                return this.salary;
            }
            private set
            {
                if (value < 650)
                {
                    throw new ArgumentException("Salary cannot be less than 650 leva!");
                }
                this.salary = value;
            }
        }
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
