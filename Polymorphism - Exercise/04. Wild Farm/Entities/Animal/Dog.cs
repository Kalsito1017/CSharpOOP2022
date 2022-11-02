using _04._Wild_Farm.Entities.Food;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04._Wild_Farm.Entities.Animal
{
    public class Dog : Mammal
    {
        private const double Modifier = 0.40;
        public Dog(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {

        }
        public override string ProduceSound()
         => "Woof!";
        public override void Eat(IFood food)
        {
            if (food is Meat)
            {
                this.Weight += Modifier + food.Quantity;

            }
            else
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
        }
        public override string ToString()
        {
            return $"{this.GetType().Name} [{Name}, {Weight}, {LivingRegion}, {FoodEatin}]";
        }
    }
}
