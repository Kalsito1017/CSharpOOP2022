using FoodShortage.Models.Interfaces;
using FoodShortage.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Food_Shortage
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int countOfPeople = int.Parse(Console.ReadLine());

            List<IIdentifiable> persons = new List<IIdentifiable>();

            for (int i = 0; i < countOfPeople; i++)
            {
                string[] personInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = personInfo[0];
                int age = int.Parse(personInfo[1]);

                if (personInfo.Length > 3)
                {
                    string id = personInfo[2];
                    string birthDate = personInfo[3];

                    Citizen citizen = new Citizen(id, name, age, birthDate);
                    persons.Add(citizen);
                }
                else
                {
                    string group = personInfo[2];

                    Rebel rebel = new Rebel(name, age, group);
                    persons.Add(rebel);
                }
            }

            HashSet<IBuyer> buyers = new HashSet<IBuyer>();
            string cmd;
            while ((cmd = Console.ReadLine()) != "End")
            {
                string name = cmd;

                if (persons.Any(b => b.Name == name))
                {
                    IBuyer buyer = (IBuyer)persons.First(b => b.Name == name);
                    buyer.BuyFood();
                    buyers.Add(buyer);
                }
            }

            int totalFood = buyers.Sum(b => b.Food);

            Console.WriteLine(totalFood);
        }
    }
}
