using _04._Wild_Farm.Entities.Food;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04._Wild_Farm.Entities.Animal
{
    public abstract class Feline : Mammal
    {
        public Feline(string name, double weight, string livingRegion, string breed)
           : base(name, weight, livingRegion)
        {
            this.Breed = breed;
        }
        public string Breed { get; set; }
        public override void Eat(IFood food)
        {
            if (food is Vegetable || food is Meat)
            {

            }
        }
        public override string ToString()
        {
            return $"{this.GetType().Name} [{Name}, {Breed}, {Weight}, {LivingRegion}, {FoodEatin}]";
        }

    }
    
}
