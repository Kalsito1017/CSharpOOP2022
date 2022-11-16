namespace CarManager
{
     using System;
    public class Car
    {
        private string make;
        private string model;
        private double FuelConsumption;
        private double FuelAmount;
        private double FuelCapacity;
        private Car()
        {
            this.FuelAmount = 0;
        }
        public Car(string make, string model, double fuelConsumption,double fuelCapacity)
        {
            this.make = make;
            this.model = model;
            this.FuelConsumption = fuelConsumption;         
            this.FuelCapacity = fuelCapacity;
        }
        public string Make
        {
            get
            {
                return this.make;
            }
            private set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Make cannot be null or empty!");
                }
                this.make = value;
            }
        }
        

        public string Model
        {
            get
            {
                return this.model;
            }
            private set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Model cannot be null or empty!");
                }

                this.model = value;
            }
        }
        

    }
}
