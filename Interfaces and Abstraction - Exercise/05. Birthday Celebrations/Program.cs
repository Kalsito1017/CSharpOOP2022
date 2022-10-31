using System;
using System.Collections.Generic;

namespace _05._Birthday_Celebrations
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IBirthdable> list = new List<IBirthdable>();
            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] comand = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (comand[0] == "Citizen")
                {
                    string name = comand[1];
                    int age = int.Parse(comand[2]);
                    string id = comand[3];
                    string birthdate = comand[4];
                    Citizen citizen = new Citizen(id, name, age, birthdate);
                    list.Add(citizen);
                }
                else if (comand[0] == "Pet")
                {
                    string name = comand[1];
                    string birthdate = comand[2];
                    Pet pet = new Pet(name, birthdate);
                    list.Add(pet);
                }
            }
            string year = Console.ReadLine();
            foreach (var birthable in list)
            {
                if (birthable.Birthdate.Substring(birthable.Birthdate.Length - year.Length, year.Length) == year)
                {
                    Console.WriteLine(birthable.Birthdate);
                }
            }
        }
    }
}
