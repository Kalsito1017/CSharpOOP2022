using System;
using System.Collections.Generic;
using BorderControl.Models;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
		    List<IIdentifiable> identifiers = new List<IIdentifiable>();
            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] comand = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (comand.Length > 2)
                {
                    string name = comand[0];
                    int age = int.Parse(comand[1]);
                    string id = comand[2];
                    Citizen citizen = new Citizen(id, name, age);
                    identifiers.Add(citizen);
                }
                else
                {
                    string model = comand[0];
                    string id = comand[1];
                    Robot robot = new Robot(model, id);
                    identifiers.Add(robot);
                }
            }
            string lastOfFakeId = Console.ReadLine();
            foreach (var item in identifiers)
            {
                if (item.Id.Substring(item.Id.Length - lastOfFakeId.Length, lastOfFakeId.Length) == lastOfFakeId)
                {
                    Console.WriteLine(item.Id);
                }
            }
        }
    }
}
