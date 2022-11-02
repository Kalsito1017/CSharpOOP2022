using _04._Wild_Farm.Entities.Food;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;

namespace _04._Wild_Farm.Entities.Animal
{
    public class Owl : Bird
    {
        private const double Modifier = 0.25;
        public Owl(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
            WingSize = wingSize;
        }
        public override string ProduceSound() => "Hoot Hoot";
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
