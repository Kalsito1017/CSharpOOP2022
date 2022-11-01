using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclesExtension
{
    public class Truck : Vehicle
    {
        private const double ConsumptionIncrease = 1.6;
        private const double PercentageOfFuelDecreased = 0.05;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        protected override double AdditionalConsumption => ConsumptionIncrease;

        public override void Refuel(double fuel)
        {
            base.Refuel(fuel);
            FuelQuantity -= fuel * PercentageOfFuelDecreased;
        }
    }
}
