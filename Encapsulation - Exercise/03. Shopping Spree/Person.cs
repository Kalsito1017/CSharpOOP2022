using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03._Shopping_Spree
{
    public class Person
    {
        private string name;
        private double money;
        public Person(string name, double money)
        {
            this.Name = name;
            this.Money = money;
            BagOfProducts = new List<Product>();
        }
        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                this.name = value;
            }
        }
        public double Money
        {
            get { return this.money; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                this.money = value;
            }
        }
        public List<Product> BagOfProducts { get; set; }
        public override string ToString()
        {
            if (BagOfProducts.Any())
            {
                return $"{this.Name} - {string.Join(", ", this.BagOfProducts.Select(p => p.Name).ToArray())}";
            }
            return $"{this.Name} - Nothing bought";    
        }
    }
}
