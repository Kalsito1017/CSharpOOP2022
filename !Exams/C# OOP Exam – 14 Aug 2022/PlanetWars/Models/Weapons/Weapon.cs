using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.Weapons
{
    public abstract class Weapon : IWeapon
    {
        private const int MinDestrLvl = 1;
        private const int MaxDestrLvl = 10;
        private int destructionLevel;
        protected Weapon(double price, int destructionLevel)
        {
            this.destructionLevel = destructionLevel;
            Price = price;
        }
        public double Price { get; set; }
        public virtual int DestructionLevel
        {
            get { return this.destructionLevel; }
            private set
            {
                if (value < MinDestrLvl)
                {
                    throw new ArgumentException(ExceptionMessages.TooLowDestructionLevel);
                }
                else if (value > MaxDestrLvl)
                {
                    throw new ArgumentException(ExceptionMessages.TooHighDestructionLevel);
                }
                this.destructionLevel = value;
            }
        }
    }
}
