using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models
{
    public class HappyBunny : Bunny
    {
        private const int InitialEnergy = 100;
        public HappyBunny(string name) : base(name, InitialEnergy)
        {
        }
        public override void Work()
        {
            Energy -= 10;
        }
    }
}
