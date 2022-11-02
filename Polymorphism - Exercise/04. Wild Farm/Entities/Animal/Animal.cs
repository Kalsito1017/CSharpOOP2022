using _04._Wild_Farm.Entities.Food;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04._Wild_Farm.Entities.Animal
{
    public abstract class Animal : IAnimal
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public int FoodEatin { get; set; }
        public abstract string ProduceSound();
        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }
        public abstract void Eat(IFood food);
        
        
    }
}
