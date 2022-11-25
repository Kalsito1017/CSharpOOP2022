using AquaShop.Models.Fish.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models
{
    public class FreshwaterFish : _Fish
    {
        private const int InitialSize = 3;
        private const int SizeIncreasment = 3;

        public FreshwaterFish(string name, string species, decimal price) : base(name, species, price)
        {
        }

        public override int Size
        => InitialSize;
        public override void Eat()
        => Size += SizeIncreasment;
    }
}
