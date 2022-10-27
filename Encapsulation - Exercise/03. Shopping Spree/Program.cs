using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Shopping_Spree
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] peopleInput = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
            string[] productInput = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();

            try
            {
                foreach (string person in peopleInput)
                {
                    string name = person.Split('=')[0];
                    double money = double.Parse(person.Split('=')[1]);

                    Person currentPerson = new Person(name, money);
                    people.Add(currentPerson);
                }

                foreach (string product in productInput)
                {
                    string name = product.Split('=')[0];
                    double cost = double.Parse(product.Split('=')[1]);

                    Product currentProduct = new Product(name, cost);
                    products.Add(currentProduct);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }


            string cmd;
            while ((cmd = Console.ReadLine()) != "END")
            {
                string personName = cmd.Split(' ')[0];
                string productName = cmd.Split(' ')[1];

                Person currentPerson = people.First(p => p.Name == personName);
                Product currentProduct = products.First(p => p.Name == productName);

                if (currentPerson.Money >= currentProduct.Cost)
                {
                    currentPerson.BagOfProducts.Add(currentProduct);
                    currentPerson.Money -= currentProduct.Cost;
                    Console.WriteLine($"{personName} bought {productName}");
                }
                else
                {
                    Console.WriteLine($"{personName} can't afford {productName}");
                }
            }

            people.ForEach(p => Console.WriteLine(p.ToString()));
        }
    }
}
