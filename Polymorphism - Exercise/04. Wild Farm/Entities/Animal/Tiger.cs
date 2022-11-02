using _04._Wild_Farm.Entities.Food;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04._Wild_Farm.Entities.Animal
{
    public class Tiger : Feline
    {
        private const double Modifier = 1;
        public Tiger(string name, double weight, string livingRegion, string breed)
          : base(name, weight, livingRegion, breed)
        {

        }

        public override string ProduceSound()
        => "ROAR!!!";
        public override void Eat(IFood food)
        {
            if (food is Meat)
            {
                this.Weight += Modifier * food.Quantity;
                this.FoodEatin += food.Quantity;
            }
            else
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
        }
    }
}
