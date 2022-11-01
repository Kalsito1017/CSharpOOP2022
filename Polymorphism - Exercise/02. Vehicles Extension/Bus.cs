using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclesExtension
{
    public class Bus : Vehicle
    {
        private const double ConsumptionIncrease = 1.4;
        private AirContinionerMode airContinionerMode;
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }
        protected override double AdditionalConsumption =>
            airContinionerMode == AirContinionerMode.On
            ? ConsumptionIncrease
            : 0;
        public void SwitchACon()
        {
            airContinionerMode = AirContinionerMode.On;
        }
        public void SwitchACOff()
        {
            airContinionerMode = AirContinionerMode.Off;
        }
    }
}
