using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models
{
    public class TunedCar : Car
    {
        private const double InitialFuelAvailable = 65;
        private const double InitialFuelConsumptionPerPace = 7.5;
        public TunedCar(string make, string model, string vin, int horsePower) 
            : base(make, model, vin, horsePower, InitialFuelAvailable, InitialFuelConsumptionPerPace)
        {
        }
        public override void Drive()
        {
            base.Drive();
            HorsePower = (int)Math.Round(HorsePower * 0.97);
        }

    }
}
