
using System;

namespace CarRacing.Models
{
    public class SuperCar : Car
    {
        private const double InitialFuelAvailable = 80;
        private const double InitialFuelConsumptionParce = 10;
        public SuperCar(string make, string model, string vin, int horsePower) 
            : base(make, model, vin, horsePower, InitialFuelAvailable, InitialFuelConsumptionParce)
        {
        }
        
    }
}
