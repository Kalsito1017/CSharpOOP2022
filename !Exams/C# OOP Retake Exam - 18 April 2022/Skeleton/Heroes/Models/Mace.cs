﻿
namespace Heroes.Models
{
    public class Mace : Weapon
    {
        private const int MaceDamage = 25;
        public Mace(string name, int durability) : base(name, durability)
        {

        }
        public override int DoDamage()
        {
            if (Durability == 0)
            {
                return 0;
            }
            Durability--;
            return MaceDamage;
        }
    }
}
