
using _04._Wild_Farm.Entities.Animal;
using _04._Wild_Farm.Entities.Food;
using System;
using System.Collections.Generic;

namespace _04._Wild_Farm
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<IAnimal> animals = new List<IAnimal>();
            string command = Console.ReadLine();
            while (command != "End")
            {
                try
                {
                    string[] animalInfo = command.Split();
                    string[] foodInfo = Console.ReadLine().Split();
                    string type = animalInfo[0];
                    string name = animalInfo[1];
                    double weight = double.Parse(animalInfo[2]);
                    IAnimal animal = null;
                    if (type == "Cat" || type == "Tiger")
                    {
                        string livingRegion = animalInfo[3];
                        string breed = animalInfo[4];
                        if (type == "Cat")
                        {
                            animal = new Cat(name, weight, livingRegion, breed);
                        }
                        else
                        {
                            animal = new Tiger(name, weight, livingRegion, breed);
                        }
                    }
                    else if (type == "Hen" || type == "Owl")
                    {
                        double wingSize = double.Parse(animalInfo[3]);
                        if (type == "Hen")
                        {
                            animal = new Hen(name, weight, wingSize);
                        }
                        else
                        {
                            animal = new Owl(name, weight, wingSize);
                        }
                    }
                    else
                    {
                        string livingRegion = animalInfo[3];
                        if (type == "Dog")
                        {
                            animal = new Dog(name, weight, livingRegion);
                        }
                        else
                        {
                            animal = new Mouse(name, weight, livingRegion);
                        }
                    }
                    Console.WriteLine(animal.ProduceSound());
                    animals.Add(animal);
                    string foodType = foodInfo[0];
                    int quantity = int.Parse(foodInfo[1]);
                    IFood food = null;
                    if (foodType == "Vegetable")
                    {
                        food = new Vegetable(quantity);
                    }
                    else if (foodType == "Fruit")
                    {
                        food = new Fruit(quantity);
                    }
                    else if (foodType == "Meat")
                    {
                        food = new Meat(quantity);
                    }
                    else if (foodType == "Seeds")
                    {
                        food = new Seeds(quantity);
                    }
                    animal.Eat(food);
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }

                command = Console.ReadLine();
            }
            foreach (var animal in animals)
            {
                Console.WriteLine(animal.ToString());

            }
        }
    }
}
