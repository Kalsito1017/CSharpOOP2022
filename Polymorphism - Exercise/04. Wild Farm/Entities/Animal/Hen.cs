using _04._Wild_Farm.Entities.Food;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04._Wild_Farm.Entities.Animal
{
    public class Hen : Bird
    {
        private const double Modifier = 0.35;
        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
           
        }
        public override string ProduceSound()
        => "Cluck";
        public override void Eat(IFood food)
        {
            this.Weight += Modifier * food.Quantity;
            this.FoodEatin += food.Quantity;
        }
        
    }
}

