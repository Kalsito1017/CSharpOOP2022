using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.MilitaryUnits
{
    public abstract class MilitaryUnit : IMilitaryUnit
    {
        private const int InitialPower = 1;
        private const int MaxPower = 20;
        private int enduranceLevel;

        protected MilitaryUnit(double cost)
        {
            this.EnduranceLevel = InitialPower;
            Cost = cost;
        }

        public double Cost {  get;  }   

        public int EnduranceLevel
        {
            get { return this.enduranceLevel; }
            private set
            {
                if (value >= MaxPower)
                {
                    value = MaxPower;
                    throw new ArgumentException(ExceptionMessages.EnduranceLevelExceeded);
                }
                this.enduranceLevel = value;
            }
        }

        public void IncreaseEndurance()
        {
            this.EnduranceLevel++;
        }

    }
}
