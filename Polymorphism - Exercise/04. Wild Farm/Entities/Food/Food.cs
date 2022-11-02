using System;
using System.Collections.Generic;
using System.Text;

namespace _04._Wild_Farm.Entities.Food
{
    public abstract class Food : IFood
    {
        public Food(int quantity)
        {
            this.Quantity = quantity;
        }
        public int Quantity { get; set; }
    }
}
