using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models
{
    public class SaltwaterFish : _Fish
    {
        private const int InitialSize = 5;
        private const int SizeIncreasment = 2;

        public SaltwaterFish(string name, string species, decimal price) : base(name, species, price)
        {
        }

        public override int Size
        => InitialSize;
        public override void Eat()
        => Size += SizeIncreasment;
    }
}
