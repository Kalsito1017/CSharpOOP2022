using System;

namespace _04._Pizza_Calories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] pizza = Console.ReadLine().Split(" ");
            string name = pizza[1];
            string[] dough = Console.ReadLine().Split(" ");
            string flour = dough[1];
            string baking = dough[2];
            double doughWeight = double.Parse(dough[3]);
            try
            {
                Dough Dough = new Dough(flour, baking, doughWeight);
                Pizza Pizza = new Pizza(name, Dough);
                string command = Console.ReadLine();
                while (command != "END")
                {
                    string[] toppingcdr = command.Split(" ");
                    string type = toppingcdr[1];
                    double weight = double.Parse(toppingcdr[2]);
                    Topping topping = new Topping(type, weight);
                    Pizza.AddTopping(topping);
                    
                }
                Console.WriteLine(Pizza);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                
            }
        }
    }
}
